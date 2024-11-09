using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Neo4j.Driver;
using Neo4jClient.Transactions;
using Newtonsoft.Json;
using ShapeHandler.Objects;

namespace ShapeHandler.Database
{
    public class DatabaseConnector : IDisposable
    {
        private readonly IDriver _driver;

        public DatabaseConnector(string uri, string user, string password)
        {
            _driver = GraphDatabase.Driver(uri, AuthTokens.Basic(user, password));

            if (_driver.TryVerifyConnectivityAsync().Result == false)
            {
                throw new Exception("Connection to the database failed");
            }
        }

        public DatabaseConnector(IDriver driver)
        {
            _driver = driver;

            if (_driver.TryVerifyConnectivityAsync().Result == false)
            {
                throw new Exception("Connection to the database failed");
            }
        }

        public void Dispose()
        {
            _driver?.Dispose();
        }

        public async Task<bool> WriteHtmlGraphAsync(HtmlGraph graph)
        {
            if (graph == null) throw new ArgumentNullException(nameof(graph));

            using (var session = _driver.AsyncSession())
            {
                var tx = await session.BeginTransactionAsync();
                try
                {
                    await WriteNodes(tx, graph);

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

        private async Task WriteNodes(IAsyncTransaction tx, HtmlGraph graph)
        {
            HashSet<FlowchartNode> visited = new HashSet<FlowchartNode>();
            HashSet<FlowchartNode> nodes = graph.GetNodes();

            foreach (var node in nodes)
            {
                if (!visited.Contains(node))
                {
                    await DepthFirstSearch(tx, graph, visited, node);
                }
            }
        }

        private async Task DepthFirstSearch(IAsyncTransaction tx, HtmlGraph graph, HashSet<FlowchartNode> visited, FlowchartNode node)
        {
            visited.Add(node);
            await CreateNode(tx, node);

            var neighbors = graph.GetConnectedNodesFrom(node);
            foreach (var neighbor in neighbors.Keys)
            {
                if (!visited.Contains(neighbor))
                {
                    await DepthFirstSearch(tx, graph, visited, neighbor);
                }
            }

            await CreateRelationships(tx, graph, node, neighbors);
        }

        private async Task CreateNode(IAsyncTransaction tx, FlowchartNode node)
        {
            if (node is HtmlNode htmlNode)
            {
                var elementAttributes = htmlNode.Element.Attributes.ToDictionary(attr => attr.Name, attr => (object)attr.Value);
                elementAttributes.Remove("id");
                elementAttributes.Add("ElementId", htmlNode.Element.Id);
                await tx.RunAsync(@"
                    UNWIND $attributes AS attribute
                    MERGE (n:" + node.Type.ToString() + @" {id: $id})
                    ON CREATE SET n += attribute, n.Label = $label",
                    new { id = htmlNode.Id, attributes = elementAttributes, label = htmlNode.Label });
            }
            else if (node is DecisionNode decisionNode)
            {
                var validationElements = decisionNode.DecisionElementIds.Select(ve => ve.ToString()).ToList();
                await tx.RunAsync(@"
                    MERGE (n:" + node.Type.ToString() + @" {id: $id})
                    ON CREATE SET n += { ValidationElements: CASE WHEN size($elements) > 0 THEN $elements ELSE [] END, Label: $label }",
                    new { id = decisionNode.Id, elements = validationElements, label = decisionNode.Label });
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


        private async Task CreateRelationships(IAsyncTransaction tx, HtmlGraph graph, FlowchartNode currentNode, Dictionary<FlowchartNode, List<Connection>> neighbors)
        {
            foreach (var neighbor in neighbors.Keys)
            {
                var connections = neighbors[neighbor];

                foreach (var connection in connections)
                {
                    var connectionJson = JsonConvert.SerializeObject(connection, new Neo4JSerializer());
                    var connectionDict = JsonConvert.DeserializeObject<Dictionary<string, object>>(connectionJson);

                    var conditions = connection.Conditions.Select(c => c.ToString()).ToList();

                    await tx.RunAsync(@"
                        MATCH 
                            (a:" + currentNode.Type.ToString() + @" {id: $sourceId}), 
                            (b:" + neighbor.Type.ToString() + @" {id: $targetId})
                        MERGE 
                            (a)-[r:" + connection.Type.ToString().ToUpper() + @" {Label: COALESCE($connectionObj.label, '')}]->(b)
                        ON CREATE SET r += $connectionObj
                        WITH r
                        UNWIND $conditions AS condition
                        SET r.Conditions = condition",
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
