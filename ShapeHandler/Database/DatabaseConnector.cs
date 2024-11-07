using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Neo4j.Driver;
using Neo4jClient.Transactions;
using ShapeHandler.Objects;

namespace ShapeHandler.Database
{
    public class DatabaseConnector : IDisposable
    {
        private readonly IDriver _driver;

        /// <summary>
        /// Constructor for the DatabaseConnector class
        /// </summary>
        /// <param name="uri">The URI of the database</param>
        /// <param name="user">The username to access database</param>
        /// <param name="password">The Password to access database</param>
        public DatabaseConnector(string uri, string user, string password)
        {
            _driver = GraphDatabase.Driver(uri, AuthTokens.Basic(user, password));

            // check if the connection is successful
            if (_driver.TryVerifyConnectivityAsync().Result == false)
            {
                throw new Exception("Connection to the database failed");
            }
        }

        public DatabaseConnector(IDriver driver)
        {
            _driver = driver;

            // check if the connection is successful
            if (_driver.TryVerifyConnectivityAsync().Result == false)
            {
                throw new Exception("Connection to the database failed");
            }
        }

        public void Dispose()
        {
            _driver?.Dispose();
        }

        /// <summary>
        /// Writes the graph to the database
        /// </summary>
        /// <param name="graph">The HTML Graph</param>
        /// <returns>Task of whether write was successful</returns>
        /// <exception cref="ArgumentNullException">Null if graph is null</exception>
        public async Task<bool> WriteHtmlGraphAsync(HtmlGraph graph)
        {
            if (graph == null) throw new ArgumentNullException(nameof(graph));

            // Start Session
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
                    return false;
                }
            }
        }

        /// <summary>
        /// Writes the nodes to the database
        /// </summary>
        /// <param name="tx">The Async Transaction</param>
        /// <param name="graph">The Html Graph</param>
        /// <returns></returns>
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

        /// <summary>
        /// Depth First Search to write nodes to the database
        /// </summary>
        /// <param name="tx">The Transaction</param>
        /// <param name="graph">The Html Graph</param>
        /// <param name="visited">Nodes already Visited</param>
        /// <param name="node">Current Node</param>
        /// <returns></returns>
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

        /// <summary>
        /// Runs the query to create a node in the database if it doesn't already exist
        /// </summary>
        /// <param name="tx">The Transaction</param>
        /// <param name="node">The node to write</param>
        /// <returns></returns>
        private async Task CreateNode(IAsyncTransaction tx, FlowchartNode node)
        {
            await tx.RunAsync(@"
                MERGE (n:FlowchartNode {id: $id})
                ON CREATE SET n.type = $type",
                new { id = node.Id, type = node.Type.ToString() });
        }

        /// <summary>
        /// Creates relationships between nodes in the database
        /// </summary>
        /// <param name="tx">The Async Transaction</param>
        /// <param name="graph">The Html Graph</param>
        /// <param name="currentNode">The Current Node being processed</param>
        /// <param name="neighbors">Outgoing neighbors of the current node</param>
        /// <returns></returns>
        private async Task CreateRelationships(IAsyncTransaction tx, HtmlGraph graph, FlowchartNode currentNode, Dictionary<FlowchartNode, List<Condition<Enum>>> neighbors)
        {
            foreach (var neighbor in neighbors.Keys)
            {
                var conditions = graph.GetConditions(currentNode, neighbor);
                foreach (var condition in conditions)
                {
                    await tx.RunAsync(@"
                        MATCH (a:FlowchartNode {id: $sourceId}), (b:FlowchartNode {id: $targetId})
                        MERGE (a)-[r:CONNECTED {type: $type, state: $state, matchValue: $matchValue}]->(b)
                        ON CREATE SET r.type = $type, r.state = $state, r.matchValue = $matchValue",
                        new { sourceId = currentNode.Id, targetId = neighbor.Id, type = condition.Type.ToString(), state = condition.State, matchValue = condition.MatchValue });
                }
            }
        }
    }
}
