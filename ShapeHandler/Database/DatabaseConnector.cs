using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp.Html.Dom;
using Neo4j.Driver;
using Neo4jClient.Transactions;
using Newtonsoft.Json;
using ShapeHandler.Objects;

namespace ShapeHandler.Database
{
    public class DatabaseConnector : IDisposable
    {
        private readonly IDriver _driver;

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseConnector"/> class with the specified URI, user, and password.
        /// </summary>
        /// <param name="uri">The URI of the Neo4j database.</param>
        /// <param name="user">The username for authentication.</param>
        /// <param name="password">The password for authentication.</param>
        /// <exception cref="Exception">Thrown when authentication or connection to the database fails.</exception>
        public DatabaseConnector(string uri, string user, string password)
        {
            var auth = AuthTokens.Basic(user, password);
            _driver = GraphDatabase.Driver(uri, auth);

            if (_driver.VerifyAuthenticationAsync(auth).Result == false)
            {
                throw new Exception("Authentication to the database failed");
            }

            if (_driver.TryVerifyConnectivityAsync().Result == false)
            {
                throw new Exception("Connection to the database failed");
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseConnector"/> class with the specified driver.
        /// </summary>
        /// <param name="driver">The Neo4j driver.</param>
        /// <exception cref="Exception">Thrown when connection to the database fails.</exception>
        public DatabaseConnector(IDriver driver)
        {
            _driver = driver;

            if (_driver.TryVerifyConnectivityAsync().Result == false)
            {
                throw new Exception("Connection to the database failed");
            }
        }

        /// <summary>
        /// Disposes the database driver.
        /// </summary>
        public void Dispose()
        {
            _driver?.Dispose();
        }

        /// <summary>
        /// Writes the HTML graph to the database asynchronously.
        /// </summary>
        /// <param name="graph">The HTML graph to write.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success or failure.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the graph is null.</exception>
        /// <exception cref="Exception">Thrown when writing the graph to the database fails.</exception>
        public async Task<bool> WriteHtmlGraphAsync(HtmlGraph graph)
        {
            if (graph == null) throw new ArgumentNullException(nameof(graph));

            using (var session = _driver.AsyncSession())
            {
                var tx = await session.BeginTransactionAsync();
                try
                {
                    await WriteNodesAsync(tx, graph);

                    await tx.CommitAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    await tx.RollbackAsync();
                    throw new Exception("Failed to write graph to database", ex);
                }
            }
        }

        /// <summary>
        /// Writes the nodes of the HTML graph to the database asynchronously.
        /// </summary>
        /// <param name="tx">The transaction to use.</param>
        /// <param name="graph">The HTML graph containing the nodes.</param>
        private async Task WriteNodesAsync(IAsyncTransaction tx, HtmlGraph graph)
        {
            HashSet<FlowchartNode> visited = new HashSet<FlowchartNode>();
            HashSet<FlowchartNode> nodes = graph.GetNodes();

            foreach (var node in nodes)
            {
                if (!visited.Contains(node))
                {
                    await DFS_CreateGraphAsync(tx, graph, visited, node);
                }
            }
        }

        /// <summary>
        /// Performs a depth-first search to create the graph in the database asynchronously.
        /// </summary>
        /// <param name="tx">The transaction to use.</param>
        /// <param name="graph">The HTML graph.</param>
        /// <param name="visited">The set of visited nodes.</param>
        /// <param name="node">The current node.</param>
        private async Task DFS_CreateGraphAsync(IAsyncTransaction tx, HtmlGraph graph, HashSet<FlowchartNode> visited, FlowchartNode node)
        {
            visited.Add(node);
            await CreateNodeAsync(tx, node);

            var neighbors = graph.GetConnectedNodesFrom(node);
            foreach (var neighbor in neighbors.Keys)
            {
                if (!visited.Contains(neighbor))
                {
                    await DFS_CreateGraphAsync(tx, graph, visited, neighbor);
                }
            }

            await CreateRelationshipsAsync(tx, graph, node, neighbors);
        }

        /// <summary>
        /// Creates a node in the database asynchronously.
        /// </summary>
        /// <param name="tx">The transaction to use.</param>
        /// <param name="node">The node to create.</param>
        private async Task CreateNodeAsync(IAsyncTransaction tx, FlowchartNode node)
        {
            if (node is HtmlNode htmlNode)
            {
                var elementAttributes = htmlNode.Element.Attributes.ToDictionary(attr => attr.Name, attr => (object)attr.Value);
                elementAttributes.Remove("id");
                elementAttributes.Add("ElementId", htmlNode.Element.Id);

                if (typeof(IHtmlSelectElement).IsAssignableFrom(htmlNode.Element.GetType()))
                {
                    var selectElement = (IHtmlSelectElement)htmlNode.Element;
                    var options = selectElement.Options.Select(option => new { option.OuterHtml }).ToList();
                    elementAttributes.Add("Options", JsonConvert.SerializeObject(options));
                }

                await tx.RunAsync(@"
                        UNWIND $attributes AS attribute
                        MERGE (n:" + node.Type.ToString() + @" {id: $id})
                        ON CREATE SET n += attribute, n.Label = $label",
                new { id = htmlNode.Id, attributes = elementAttributes, label = htmlNode.Label });
            }
            else
            {
                var nodeJson = JsonConvert.SerializeObject(node, new Neo4JSerializer());
                var nodeDict = JsonConvert.DeserializeObject<Dictionary<string, object>>(nodeJson);

                await tx.RunAsync(@"
                        MERGE (n:" + node.Type.ToString() + @" {id: $id})
                        ON CREATE SET n += $nodeObj",
                    new { id = node.Id, nodeObj = nodeDict });
            }
        }

        /// <summary>
        /// Creates relationships between nodes in the database asynchronously.
        /// </summary>
        /// <param name="tx">The transaction to use.</param>
        /// <param name="graph">The HTML graph.</param>
        /// <param name="currentNode">The current node.</param>
        /// <param name="neighbors">The neighbors of the current node.</param>
        private async Task CreateRelationshipsAsync(IAsyncTransaction tx, HtmlGraph graph, FlowchartNode currentNode, Dictionary<FlowchartNode, List<Connection>> neighbors)
        {
            foreach (var neighbor in neighbors.Keys)
            {
                var connections = neighbors[neighbor];

                foreach (var connection in connections)
                {
                    var connectionJson = JsonConvert.SerializeObject(connection, new Neo4JSerializer());
                    var connectionDict = JsonConvert.DeserializeObject<Dictionary<string, object>>(connectionJson);

                    var conditions = connection.Conditions?.ToString() ?? null;

                    await tx.RunAsync(@"
                                MATCH 
                                    (a:" + currentNode.Type + @" {id: $sourceId}), 
                                    (b:" + neighbor.Type + @" {id: $targetId})
                                MERGE 
                                    (a)-[r:" + connection.Type.ToString().ToUpper() + @" {Label: COALESCE($connectionObj.label, '')}]->(b)
                                ON CREATE SET r += $connectionObj
                                SET r.Conditions = $conditions",
                        new
                        {
                            sourceId = currentNode.Id,
                            targetId = neighbor.Id,
                            connectionObj = connectionDict,
                            conditions = conditions
                        });
                }
            }
        }
    }
}
