using System;
using System.Collections.Generic;
using System.Linq;

namespace ShapeHandler.Objects
{
    public class HtmlGraph
    {
        //<source, <target, conditions>>
        private Dictionary<FlowchartNode, Dictionary<FlowchartNode, List<Condition<Enum>>>> OutEdges { get; set; }

        //<target, <source, conditions>>
        private Dictionary<FlowchartNode, Dictionary<FlowchartNode, List<Condition<Enum>>>> InEdges { get; set; }

        public HtmlGraph()
        {
            OutEdges = new Dictionary<FlowchartNode, Dictionary<FlowchartNode, List<Condition<Enum>>>>();
            InEdges = new Dictionary<FlowchartNode, Dictionary<FlowchartNode, List<Condition<Enum>>>>();
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
                OutEdges[node] = new Dictionary<FlowchartNode, List<Condition<Enum>>>();
            }
            if (!InEdges.ContainsKey(node))
            {
                InEdges[node] = new Dictionary<FlowchartNode, List<Condition<Enum>>>();
            }
        }

        /// <summary>
        /// Adds a connection between two nodes in the graph.
        /// </summary>
        /// <param name="source">The source node id</param>
        /// <param name="target">The target node id</param>
        /// <param name="condition">The condition of the connection.</param>
        /// <exception cref="ArgumentNullException">Thrown when the source or target node is null.</exception>
        public void AddConnection(string source, string target, Condition<Enum> condition)
        {
            if (source == null || target == null)
            {
                throw new ArgumentNullException("Source and target must be non-null");
            }

            FlowchartNode sourceNode = OutEdges.Keys.FirstOrDefault(x => x.Id == source);
            FlowchartNode targetNode = OutEdges.Keys.FirstOrDefault(x => x.Id == target);

            if (sourceNode == null)
            {
                sourceNode = new DecisionNode(source);
                AddNode(sourceNode);
            }

            if (targetNode == null)
            {
                targetNode = new DecisionNode(target);
                AddNode(targetNode);
            }

            AddConnection(sourceNode, targetNode, condition);
        }

        /// <summary>
        /// Add a connection between two nodes in the graph
        /// </summary>
        /// <param name="source">The source node</param>
        /// <param name="target">The target node</param>
        /// <param name="condition">The Condition of the connectin</param>
        /// <exception cref="ArgumentNullException">Thrown when source or target is null</exception>
        public void AddConnection(FlowchartNode source, FlowchartNode target, Condition<Enum> condition)
        {
            if (source == null || target == null)
            {
                throw new ArgumentNullException("Source and target must be non-null");
            }

            if (!OutEdges.ContainsKey(source))
            {
                OutEdges[source] = new Dictionary<FlowchartNode, List<Condition<Enum>>>();
            }
            if (!InEdges.ContainsKey(target))
            {
                InEdges[target] = new Dictionary<FlowchartNode, List<Condition<Enum>>>();
            }

            if (!OutEdges[source].ContainsKey(target))
            {
                OutEdges[source][target] = new List<Condition<Enum>>();
            }
            if (!InEdges[target].ContainsKey(source))
            {
                InEdges[target][source] = new List<Condition<Enum>>();
            }

            OutEdges[source][target].Add(condition);
            InEdges[target][source].Add(condition);
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
        /// <returns>Dictionary of connected nodes and their conditions</returns>
        public Dictionary<FlowchartNode, List<Condition<Enum>>> GetConnectedNodesFrom(FlowchartNode node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("Node must be non-null");
            }
            if (!OutEdges.ContainsKey(node))
            {
                return new Dictionary<FlowchartNode, List<Condition<Enum>>>();
            }
            return OutEdges[node];
        }

        /// <summary>
        /// Get all nodes connected to a given node
        /// </summary>
        /// <param name="node">The target node</param>
        /// <returns>Dictionary of connected nodes and their conditions</returns>
        public Dictionary<FlowchartNode, List<Condition<Enum>>> GetConnectedNodesTo(FlowchartNode node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("Node must be non-null");
            }
            if (!InEdges.ContainsKey(node))
            {
                return new Dictionary<FlowchartNode, List<Condition<Enum>>>();
            }
            return InEdges[node];
        }

        public List<Condition<Enum>> GetConditions(FlowchartNode source, FlowchartNode target)
        {
            if (source == null || target == null)
            {
                throw new ArgumentNullException("Source and target must be non-null");
            }
            if (!OutEdges.ContainsKey(source) || !OutEdges[source].ContainsKey(target))
            {
                return new List<Condition<Enum>>();
            }
            return OutEdges[source][target];
        }
    }
}
