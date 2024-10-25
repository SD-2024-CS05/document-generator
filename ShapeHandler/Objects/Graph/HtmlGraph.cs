using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;

namespace ShapeHandler.Objects
{
    public class HtmlGraph
    {
        private Dictionary<HtmlNode, Dictionary<HtmlNode, List<Condition<string>>>> AdjacencyList { get; set; }

        public HtmlGraph()
        {
            AdjacencyList = new Dictionary<HtmlNode, Dictionary<HtmlNode, List<Condition<string>>>>();
        }

        /// <summary>
        /// Adds an edge to the graph
        /// </summary>
        /// <param name="source">Source WebAction Object</param>
        /// <param name="destination">Destination WebAction Object</param>
        /// <param name="conditions">Conditions to add to get to the destination Object</param>
        public void AddEdge(HtmlNode source, HtmlNode destination, List<Condition<string>> conditions)
        {
            if (!AdjacencyList.ContainsKey(source))
            {
                AdjacencyList.Add(source, new Dictionary<HtmlNode, List<Condition<string>>>());
            }

            if (!AdjacencyList.ContainsKey(destination))
            {
                AdjacencyList.Add(destination, new Dictionary<HtmlNode, List<Condition<string>>>());
            }

            if (!AdjacencyList[source].ContainsKey(destination))
            {
                AdjacencyList[source].Add(destination, new List<Condition<string>>());
            }

            AdjacencyList[source][destination] = conditions;
        }

        /// <summary>
        /// Checks if the graph has an edge between two WebAction objects
        /// </summary>
        /// <param name="source">Source WebAction Object</param>
        /// <param name="destination">Destination WebAction Object</param>
        /// <returns></returns>
        public bool HasEdge(HtmlNode source, HtmlNode destination)
        {
            return AdjacencyList.ContainsKey(source) && AdjacencyList[source].ContainsKey(destination);
        }

        /// <summary>
        /// Checks whether a path exists between a Source and Destination WebAction
        /// </summary>
        /// <param name="source">Source WebAction Object</param>
        /// <param name="destination">Destination WebAction object</param>
        /// <param name="fulfilledConditions">(optional) Conditionals fulfilled, if present will check against conditionals, otherwise will assume conditionals are passed</param>
        /// <returns></returns>
        public bool HasPath(HtmlNode source, HtmlNode destination, List<Condition<string>> fulfilledConditions = null)
        {
            if (source.Equals(destination))
            {
                return true;
            }

            HashSet<HtmlNode> visited = new HashSet<HtmlNode>();
            Queue<HtmlNode> queue = new Queue<HtmlNode>();

            visited.Add(source);
            queue.Enqueue(source);

            while (queue.Count != 0)
            {
                HtmlNode current = queue.Dequeue();

                if (current.Equals(destination))
                {
                    return true;
                }

                if (AdjacencyList.ContainsKey(current))
                {
                    foreach (HtmlNode neighbor in AdjacencyList[current].Keys)
                    {
                        bool conditionsFulfilled = fulfilledConditions == null || !AdjacencyList[current][neighbor].Except(fulfilledConditions).Any();

                        if (!visited.Contains(neighbor) && conditionsFulfilled)
                        {
                            visited.Add(neighbor);
                            queue.Enqueue(neighbor);
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        ///  Gets the start node of the graph
        /// </summary>
        /// <returns></returns>
        public HtmlNode GetStartNode()
        {
            return AdjacencyList.FirstOrDefault().Key;
        }

        /// <summary>
        /// Gets the end node of the graph
        /// </summary>
        /// <returns></returns>
        public HtmlNode GetEndNode()
        {
            return AdjacencyList.LastOrDefault().Key;
        }

        /// <summary>
        /// Combines `otherGraph` with the current graph, optionally adding orphaned nodes
        /// </summary>
        /// <param name="otherGraph">The other graph to combine with</param>
        /// <param name="addOrphans">Whether to includes nodes that are orphaned</param>
        public void CombineGraphs(HtmlGraph otherGraph, bool addOrphans = true)
        {
            foreach (var sourceNode in otherGraph.AdjacencyList.Keys)
            {
                if (!AdjacencyList.ContainsKey(sourceNode))
                {
                    AdjacencyList.Add(sourceNode, new Dictionary<HtmlNode, List<Condition<string>>>());
                }

                foreach (var destinationNode in otherGraph.AdjacencyList[sourceNode].Keys)
                {
                    if (!AdjacencyList[sourceNode].ContainsKey(destinationNode))
                    {
                        AdjacencyList[sourceNode].Add(destinationNode, new List<Condition<string>>());
                    }

                    AdjacencyList[sourceNode][destinationNode].AddRange(otherGraph.AdjacencyList[sourceNode][destinationNode]);
                }
            }

            if (addOrphans)
            {
                foreach (var sourceNode in otherGraph.AdjacencyList.Keys)
                {
                    if (!AdjacencyList.ContainsKey(sourceNode))
                    {
                        AdjacencyList.Add(sourceNode, new Dictionary<HtmlNode, List<Condition<string>>>());
                    }
                }
            }
        }

        /// <summary>
        /// Gets the shortest path between two WebAction objects
        /// </summary>
        /// <param name="source">Source WebAction Object</param>
        /// <param name="destination">Destination WebAction Object</param>
        /// <returns></returns>
        public List<HtmlNode> GetShortestPath(HtmlNode source, HtmlNode destination)
        {
            if (source.Equals(destination))
            {
                return new List<HtmlNode> { source };
            }

            Dictionary<HtmlNode, HtmlNode> parent = new Dictionary<HtmlNode, HtmlNode>();
            Queue<HtmlNode> queue = new Queue<HtmlNode>();

            parent.Add(source, null);
            queue.Enqueue(source);

            while (queue.Count != 0)
            {
                HtmlNode current = queue.Dequeue();

                if (current.Equals(destination))
                {
                    break;
                }

                if (AdjacencyList.ContainsKey(current))
                {
                    foreach (HtmlNode neighbor in AdjacencyList[current].Keys)
                    {
                        if (!parent.ContainsKey(neighbor))
                        {
                            parent.Add(neighbor, current);
                            queue.Enqueue(neighbor);
                        }
                    }
                }
            }

            List<HtmlNode> path = new List<HtmlNode>();

            if (!parent.ContainsKey(destination))
            {
                return path;
            }

            HtmlNode currentPath = destination;
            while (currentPath != null)
            {
                path.Add(currentPath);
                currentPath = parent[currentPath];
            }

            path.Reverse();
            return path;
        }

        /// <summary>
        /// Removes an edge from the graph
        /// </summary>
        /// <param name="source">Source WebAction Object</param>
        /// <param name="destination">Destination WebAction Object</param>
        public void RemoveEdge(HtmlNode source, HtmlNode destination)
        {
            if (AdjacencyList.ContainsKey(source) && AdjacencyList[source].ContainsKey(destination))
            {
                AdjacencyList[source].Remove(destination);
            }
        }
    }
}
