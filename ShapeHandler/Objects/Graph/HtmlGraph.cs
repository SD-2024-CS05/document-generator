using Neo4jClient.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShapeHandler.Objects
{
    public class HtmlGraph
    {
        //<source, <target, connections>>
        private Dictionary<FlowchartNode, Dictionary<FlowchartNode, List<Connection>>> OutEdges { get; set; }

        //<target, <source, connections>>
        private Dictionary<FlowchartNode, Dictionary<FlowchartNode, List<Connection>>> InEdges { get; set; }

        // Start and End nodes are unique and may only have one of each
        private bool hasStart = false;
        private bool hasEnd = false;

        public HtmlGraph()
        {
            OutEdges = new Dictionary<FlowchartNode, Dictionary<FlowchartNode, List<Connection>>>();
            InEdges = new Dictionary<FlowchartNode, Dictionary<FlowchartNode, List<Connection>>>();
        }

        /// <summary>
        /// Adds a node to the graph.
        /// </summary>
        /// <param name="node">The node to add.</param>
        /// <exception cref="ArgumentNullException">Thrown when the node is null.</exception>
        public void AddNode(FlowchartNode node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("Node must be non-null");
            }
            if (!OutEdges.ContainsKey(node))
            {
                OutEdges[node] = new Dictionary<FlowchartNode, List<Connection>>();
            }
            if (!InEdges.ContainsKey(node))
            {
                InEdges[node] = new Dictionary<FlowchartNode, List<Connection>>();
            }

            // Check if the node is a start or end node and handle it if so
            if (node is StartEndNode seNode)
            {
                // Only one start node allowed
                if (seNode.IsStart && hasStart)
                {
                    throw new Exception("Only one start node allowed");
                }

                // Only one end node allowed
                if (!seNode.IsStart && hasEnd)
                {
                    throw new Exception("Only one end node allowed");
                }

                if (seNode.IsStart)
                {
                    hasStart = true;
                }
                else
                {
                    hasEnd = true;
                }
            }
        }

        /// <summary>
        /// Add a connection between two nodes in the graph
        /// </summary>
        /// <param name="source">The source node</param>
        /// <param name="target">The target node</param>
        /// <param name="connection">The connection between the nodes</param>
        /// <exception cref="ArgumentNullException">Thrown when source or target is null</exception>
        public void AddConnection(FlowchartNode source, FlowchartNode target, Connection connection)
        {
            if (source == null || target == null)
            {
                throw new ArgumentNullException("Source and target must be non-null");
            }

            if (!OutEdges.ContainsKey(source))
            {
                OutEdges[source] = new Dictionary<FlowchartNode, List<Connection>>();
            }
            if (!InEdges.ContainsKey(target))
            {
                InEdges[target] = new Dictionary<FlowchartNode, List<Connection>>();
            }

            if (source is DecisionNode decisionNode && connection.Conditions != null && connection.Conditions.Any())
            {
                ValidateDecisionNodeConnection(decisionNode, connection);
            }

            if (!OutEdges[source].ContainsKey(target))
            {
                OutEdges[source][target] = new List<Connection>();
            }
            if (!InEdges[target].ContainsKey(source))
            {
                InEdges[target][source] = new List<Connection>();
            }

            if (!OutEdges[source][target].Contains(connection))
            {
                OutEdges[source][target].Add(connection);
            }
            if (!InEdges[target][source].Contains(connection))
            {
                InEdges[target][source].Add(connection);
            }
        }

        private void ValidateDecisionNodeConnection(DecisionNode decisionNode, Connection connection)
        {
            var dataWrapperNodes = InEdges[decisionNode] // Get all nodes connected to the decision node with 'VALIDATES' connection
                .Where(x => x.Key is DataInputWrapperNode && x.Value.Any(c => c.Type == ConnectionType.VALIDATES))
                .Select(x => x.Key)
                .ToList();

            if (!dataWrapperNodes.Any())
            {
                if (connection.Conditions != null && connection.Conditions.Any())
                {
                    throw new Exception($"No dataWrapper node found for decision node id: {decisionNode.Id}, but conditions are present.");
                }
                return;
            }

            // Check if the dataWrapper node contains ids of the conditions
            foreach (var dataWrapperNode in dataWrapperNodes)
            {
                var dataWrapper = dataWrapperNode as DataInputWrapperNode;
                var htmlNodes = dataWrapper.DataInputNodes;

                // Check if the conditions contain the ids of the nodes in the dataWrapper node
                foreach (var condition in connection.Conditions)
                {
                    if (!htmlNodes.Any(x => x.Id == condition.NodeId))
                    {
                        throw new Exception("Node id not found in the dataWrapper node");
                    }
                }
            }
        }

        /// <summary>
        /// Get all unique nodes in the graph
        /// </summary>
        /// <returns>Set containing unique nodes</returns>
        public HashSet<FlowchartNode> GetNodes()
        {
            HashSet<FlowchartNode> nodes = OutEdges.Keys.ToHashSet();

            nodes.UnionWith(OutEdges.Values.SelectMany(x => x.Keys));

            return nodes;
        }

        /// <summary>
        /// Get Number of nodes in the graph
        /// </summary>
        /// <returns>int</returns>
        public int Count()
        {
            return this.GetNodes().Count;
        }

        /// <summary>
        /// Get all nodes connected from a given node
        /// </summary>
        /// <param name="node">The source node</param>
        /// <returns>Dictionary of connected nodes and their connections</returns>
        public Dictionary<FlowchartNode, List<Connection>> GetConnectedNodesFrom(FlowchartNode node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("Node must be non-null");
            }
            if (!OutEdges.ContainsKey(node))
            {
                return new Dictionary<FlowchartNode, List<Connection>>();
            }
            return OutEdges[node];
        }

        /// <summary>
        /// Get all nodes connected to a given node
        /// </summary>
        /// <param name="node">The target node</param>
        /// <returns>Dictionary of connected nodes and their connections</returns>
        public Dictionary<FlowchartNode, List<Connection>> GetConnectedNodesTo(FlowchartNode node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("Node must be non-null");
            }
            if (!InEdges.ContainsKey(node))
            {
                return new Dictionary<FlowchartNode, List<Connection>>();
            }
            return InEdges[node];
        }

        public List<Connection> GetConnections(FlowchartNode source, FlowchartNode target)
        {
            if (source == null || target == null)
            {
                throw new ArgumentNullException("Source and target must be non-null");
            }
            if (!OutEdges.ContainsKey(source) || !OutEdges[source].ContainsKey(target))
            {
                return new List<Connection>();
            }
            return OutEdges[source][target];
        }

        public List<Condition> GetConditions(FlowchartNode source, FlowchartNode target)
        {
            List<Connection> connections = GetConnections(source, target);
            if (connections == null || !connections.Any())
            {
                return new List<Condition>();
            }

            return connections.SelectMany(c => c.Conditions).ToList();
        }
    }

}
