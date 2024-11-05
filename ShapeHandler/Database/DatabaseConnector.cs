using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Neo4j.Driver;
using Neo4jClient;
using ShapeHandler.Objects;

namespace ShapeHandler.Database
{
    public class DatabaseConnector
    {
        private readonly GraphClient graphClient;

        /// <summary>
        /// Constructor for the DatabaseConnector class
        /// </summary>
        /// <param name="uri">The URI of the database</param>
        /// <param name="user">The username to access database</param>
        /// <param name="password">The Password to access database</param>
        public DatabaseConnector(string uri, string user, string password)
        {
            graphClient = new GraphClient(new Uri(uri), user, password);
            graphClient.ConnectAsync().Wait();
        }


        public async Task WriteHtmlGraphAsync(HtmlGraph graph)
        {
            if (graph == null) throw new ArgumentNullException(nameof(graph));

            HashSet<FlowchartNode> nodes = graph.GetNodes();

            // Write Nodes
            await graphClient.Cypher
                .Create("(n:Node {nodes})")
                .WithParams(nodes)
                .ExecuteWithoutResultsAsync();

            // Write Connection objects
            foreach (FlowchartNode node in nodes)
            {
                // get all connections from the node
                Dictionary<FlowchartNode, List<Condition<Enum>>> keyValuePairs = graph.GetConnectedNodesFrom(node);

                foreach (KeyValuePair<FlowchartNode, List<Condition<Enum>>> keyValuePair in keyValuePairs)
                {
                    FlowchartNode targetNode = keyValuePair.Key;
                    List<Condition<Enum>> conditions = keyValuePair.Value;

                    foreach (Condition<Enum> condition in conditions)
                    {
                        await graphClient.Cypher
                            .Match("(source:Node)", "(target:Node)")
                            .Where((FlowchartNode source) => source.Id == node.Id)
                            .AndWhere((FlowchartNode target) => target.Id == targetNode.Id)
                            .Create("(source)-[:CONNECTED_TO {Type: {type}, State: {state}, MatchValue: {matchValue}}]->(target)")
                            .WithParams(new
                            {
                                type = condition.Type,
                                state = condition.State,
                                matchValue = condition.MatchValue
                            })
                            .ExecuteWithoutResultsAsync();
                    }
                }
            }
        }
    }
}
