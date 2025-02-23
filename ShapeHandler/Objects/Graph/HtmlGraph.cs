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

            switch (node)
            {
                case StartEndNode seNode:
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
                    break;
                case DataInputNode diNode:
                    // check if diValidatingNodes exist, if not add them, and then add connections
                    foreach (var dataInputNode in diNode.DataInputNodes)
                    {
                        if (!OutEdges.ContainsKey(dataInputNode))
                        {
                            AddNode(dataInputNode);
                        }
                        AddConnection(dataInputNode, diNode, new Connection(dataInputNode.Element.Id ?? dataInputNode.Id, ConnectionType.INPUT_FOR));
                    }
                    break;
                case DecisionNode deNode:
                    foreach (var submissionNode in deNode.SubmissionNodes)
                    {
                        if (!OutEdges.ContainsKey(submissionNode))
                        {
                            AddNode(submissionNode);
                        }
                        AddConnection(submissionNode, deNode, new Connection(submissionNode.Element.Id ?? submissionNode.Id, ConnectionType.SUBMITS));
                    }
                    break;
                default:
                    break;
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
                throw new Exception("Source node not found in graph");
            }
            if (!InEdges.ContainsKey(target))
            {
                throw new Exception("Target node not found in graph");
            }

            if (source is DecisionNode decisionNode && connection.Conditions != null && connection.Conditions.NodeIds.Any())
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
            var diValidatingNodes = InEdges[decisionNode] // Get all nodes connected to the decision node
                .Where(x => x.Key is DataInputNode && x.Value.Any(c => c.Type == ConnectionType.VALIDATES))
                .Select(x => x.Key as DataInputNode)
                .ToList();

            var diConnectedNodes = InEdges[decisionNode] // Get all nodes connected to the decision node
                .Where(x => x.Key is DataInputNode && x.Value.Any(c => c.Type == ConnectionType.GOES_TO))
                .Select(x => x.Key as DataInputNode)
                .ToList();

            // for any nodes in GOES_TO that aren't in VALIDATES, add a VALIDATES connection
            foreach (var diNode in diConnectedNodes)
            {
                if (!diValidatingNodes.Contains(diNode))
                {
                    AddConnection(diNode, decisionNode, new Connection(ConnectionType.VALIDATES));
                    diValidatingNodes.Add(diNode);
                }
            }

            var connectedSubNodes = InEdges[decisionNode]
                .Where(x => x.Key is HtmlNode && x.Value.Any(c => c.Type == ConnectionType.SUBMITS))
                .Select(x => x.Key as HtmlNode)
                .ToList();

            if (!diValidatingNodes.Any() && !connectedSubNodes.Any())
            {
                throw new Exception($"No Validation nodes found for Decision Node: {decisionNode.Id}");
            }

            var condition = connection.Conditions;
            var dataInputNodeIds = diValidatingNodes.SelectMany(x => x.DataInputNodes.Select(y => y.Id)).ToHashSet();
            var submissionIds = connectedSubNodes.Select(x => x.Id).ToHashSet();

            while (condition != null)
            {
                var ConditionWithoutNodeId = condition.NodeIds.Any() && !condition.NodeIds.All(x => dataInputNodeIds.Contains(x) || submissionIds.Contains(x));
                if (ConditionWithoutNodeId)
                {
                    throw new Exception($"Condition node ids do not match data input node ids or submission ids for decision node id: {decisionNode.Id}");
                }
                condition = condition.InnerConditions;
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

        public List<Conditions> GetConditions(FlowchartNode source, FlowchartNode target)
        {
            List<Connection> connections = GetConnections(source, target);
            if (connections == null || !connections.Any())
            {
                return new List<Conditions>();
            }

            return connections.Select(x => x.Conditions).ToList();
        }
    }

}
