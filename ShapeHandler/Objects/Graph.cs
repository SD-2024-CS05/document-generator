using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeHandler
{
    public class Graph
    {
        private Dictionary<WebElement, Dictionary<WebElement, List<Condition<Enum>>>> AdjacencyList { get; set; }

        public Graph()
        {
            AdjacencyList = new Dictionary<WebElement, Dictionary<WebElement, List<Condition<Enum>>>>();
        }

        /// <summary>
        /// Adds an edge to the graph
        /// </summary>
        /// <param name="source">Source WebAction Object</param>
        /// <param name="destination">Destination WebAction Object</param>
        /// <param name="conditions">Conditions to add to get to the destination Object</param>
        public void AddEdge(WebElement source, WebElement destination, List<Condition<Enum>> conditions)
        {
            if (!AdjacencyList.ContainsKey(source))
            {
                AdjacencyList.Add(source, new Dictionary<WebElement, List<Condition<Enum>>>());
            }

            if (!AdjacencyList.ContainsKey(destination))
            {
                AdjacencyList.Add(destination, new Dictionary<WebElement, List<Condition<Enum>>>());
            }

            if (!AdjacencyList[source].ContainsKey(destination))
            {
                AdjacencyList[source].Add(destination, new List<Condition<Enum>>());
            }

            AdjacencyList[source][destination] = conditions;
        }

        /// <summary>
        /// Checks if the graph has an edge between two WebAction objects
        /// </summary>
        /// <param name="source">Source WebAction Object</param>
        /// <param name="destination">Destination WebAction Object</param>
        /// <returns></returns>
        public bool HasEdge(WebElement source, WebElement destination)
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
        public bool HasPath(WebElement source, WebElement destination, List<Condition<Enum>> fulfilledConditions = null)
        {
            if (source.Equals(destination))
            {
                return true;
            }

            HashSet<WebElement> visited = new HashSet<WebElement>();
            Queue<WebElement> queue = new Queue<WebElement>();

            visited.Add(source);
            queue.Enqueue(source);

            while (queue.Count != 0)
            {
                WebElement current = queue.Dequeue();

                if (current.Equals(destination))
                {
                    return true;
                }

                if (AdjacencyList.ContainsKey(current))
                {
                    foreach (WebElement neighbor in AdjacencyList[current].Keys)
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
        public WebElement GetStartNode()
        {
            return AdjacencyList.FirstOrDefault().Key;
        }

        /// <summary>
        /// Gets the end node of the graph
        /// </summary>
        /// <returns></returns>
        public WebElement GetEndNode()
        {
            return AdjacencyList.LastOrDefault().Key;
        }

        /// <summary>
        /// Combines `otherGraph` with the current graph, optionally adding orphaned nodes
        /// </summary>
        /// <param name="otherGraph">The other graph to combine with</param>
        /// <param name="addOrphans">Whether to includes nodes that are orphaned</param>
        public void CombineGraphs(Graph otherGraph, bool addOrphans = true)
        {
            foreach (var sourceNode in otherGraph.AdjacencyList.Keys)
            {
                if (!AdjacencyList.ContainsKey(sourceNode))
                {
                    AdjacencyList.Add(sourceNode, new Dictionary<WebElement, List<Condition<Enum>>>());
                }

                foreach (var destinationNode in otherGraph.AdjacencyList[sourceNode].Keys)
                {
                    if (!AdjacencyList[sourceNode].ContainsKey(destinationNode))
                    {
                        AdjacencyList[sourceNode].Add(destinationNode, new List<Condition<Enum>>());
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
                        AdjacencyList.Add(sourceNode, new Dictionary<WebElement, List<Condition<Enum>>>());
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
        public List<WebElement> GetShortestPath(WebElement source, WebElement destination)
        {
            if (source.Equals(destination))
            {
                return new List<WebElement> { source };
            }

            Dictionary<WebElement, WebElement> parent = new Dictionary<WebElement, WebElement>();
            Queue<WebElement> queue = new Queue<WebElement>();

            parent.Add(source, null);
            queue.Enqueue(source);

            while (queue.Count != 0)
            {
                WebElement current = queue.Dequeue();

                if (current.Equals(destination))
                {
                    break;
                }

                if (AdjacencyList.ContainsKey(current))
                {
                    foreach (WebElement neighbor in AdjacencyList[current].Keys)
                    {
                        if (!parent.ContainsKey(neighbor))
                        {
                            parent.Add(neighbor, current);
                            queue.Enqueue(neighbor);
                        }
                    }
                }
            }

            List<WebElement> path = new List<WebElement>();

            if (!parent.ContainsKey(destination))
            {
                return path;
            }

            WebElement currentPath = destination;
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
        public void RemoveEdge(WebElement source, WebElement destination)
        {
            if (AdjacencyList.ContainsKey(source) && AdjacencyList[source].ContainsKey(destination))
            {
                AdjacencyList[source].Remove(destination);
            }
        }
    }
}
