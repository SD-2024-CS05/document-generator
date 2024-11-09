using Neo4jClient.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShapeHandler.Objects
{
    public class HtmlGraph
    {
        //<source, <target, connection>>
        private Dictionary<FlowchartNode, Dictionary<FlowchartNode, Connection>> OutEdges { get; set; }

        //<target, <source, connection>>
        private Dictionary<FlowchartNode, Dictionary<FlowchartNode, Connection>> InEdges { get; set; }

        public HtmlGraph()
        {
            OutEdges = new Dictionary<FlowchartNode, Dictionary<FlowchartNode, Connection>>();
            InEdges = new Dictionary<FlowchartNode, Dictionary<FlowchartNode, Connection>>();
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
                OutEdges[node] = new Dictionary<FlowchartNode, Connection>();
            }
            if (!InEdges.ContainsKey(node))
            {
                InEdges[node] = new Dictionary<FlowchartNode, Connection>();
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

            if (source is DecisionNode && connection.Conditions != null && connection.Conditions.Any())
            {
                var decisionNode = source as DecisionNode;
                foreach (var condition in connection.Conditions)
                {
                    if (!decisionNode.ValidationElements.Any(e => e.Id == condition.NodeId))
                    {
                        throw new InvalidOperationException("Condition node must match an element in the DecisionNode");
                    }
                }
            }

            if (!OutEdges.ContainsKey(source))
            {
                OutEdges[source] = new Dictionary<FlowchartNode, Connection>();
            }
            if (!InEdges.ContainsKey(target))
            {
                InEdges[target] = new Dictionary<FlowchartNode, Connection>();
            }

            OutEdges[source][target] = connection;
            InEdges[target][source] = connection;
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
        public Dictionary<FlowchartNode, Connection> GetConnectedNodesFrom(FlowchartNode node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("Node must be non-null");
            }
            if (!OutEdges.ContainsKey(node))
            {
                return new Dictionary<FlowchartNode, Connection>();
            }
            return OutEdges[node];
        }

        /// <summary>
        /// Get all nodes connected to a given node
        /// </summary>
        /// <param name="node">The target node</param>
        /// <returns>Dictionary of connected nodes and their connections</returns>
        public Dictionary<FlowchartNode, Connection> GetConnectedNodesTo(FlowchartNode node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("Node must be non-null");
            }
            if (!InEdges.ContainsKey(node))
            {
                return new Dictionary<FlowchartNode, Connection>();
            }
            return InEdges[node];
        }

        public Connection GetConnection(FlowchartNode source, FlowchartNode target)
        {
            if (source == null || target == null)
            {
                throw new ArgumentNullException("Source and target must be non-null");
            }
            if (!OutEdges.ContainsKey(source) || !OutEdges[source].ContainsKey(target))
            {
                return null;
            }
            return OutEdges[source][target];
        }

        public List<Condition> GetConditions(FlowchartNode source, FlowchartNode target)
        {
            Connection connection = GetConnection(source, target);
            if (connection == null)
            {
                return new List<Condition>();
            }

            return connection.Conditions;
        }
    }

}
