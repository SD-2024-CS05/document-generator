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
        private Dictionary<WebAction, Dictionary<WebAction, List<Condition<Enum>>>> AdjacencyList { get; set; }

        public Graph()
        {
            AdjacencyList = new Dictionary<WebAction, Dictionary<WebAction, List<Condition<Enum>>>>();
        }

        /// <summary>
        /// Adds an edge to the graph
        /// </summary>
        /// <param name="source">Source WebAction Object</param>
        /// <param name="destination">Destination WebAction Object</param>
        /// <param name="conditions">Conditions to add to get to the destination Object</param>
        public void AddEdge(WebAction source, WebAction destination, List<Condition<Enum>> conditions)
        {
            if (!AdjacencyList.ContainsKey(source))
            {
                AdjacencyList.Add(source, new Dictionary<WebAction, List<Condition<Enum>>>());
            }

            if (!AdjacencyList.ContainsKey(destination))
            {
                AdjacencyList.Add(destination, new Dictionary<WebAction, List<Condition<Enum>>>());
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
        public bool HasEdge(WebAction source, WebAction destination)
        {
            return AdjacencyList.ContainsKey(source) && AdjacencyList[source].ContainsKey(destination);
        }

        /// <summary>
        /// Checks if there is a path between two WebAction objects
        /// </summary>
        /// <param name="source">Source WebAction Object</param>
        /// <param name="destination">Destination WebAction Object</param>
        /// <returns></returns>
        public bool HasPath(WebAction source, WebAction destination)
        {
            if (source.Equals(destination))
            {
                return true;
            }

            HashSet<WebAction> visited = new HashSet<WebAction>();
            Queue<WebAction> queue = new Queue<WebAction>();

            visited.Add(source);
            queue.Enqueue(source);

            while (queue.Count != 0)
            {
                WebAction current = queue.Dequeue();

                if (current.Equals(destination))
                {
                    return true;
                }

                if (AdjacencyList.ContainsKey(current))
                {
                    foreach (WebAction neighbor in AdjacencyList[current].Keys)
                    {
                        if (!visited.Contains(neighbor))
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
        /// Checks whether a path exists between a Source and Destination WebAction, checking with fulfilled Conditions
        /// </summary>
        /// <param name="source">Source WebAction Object</param>
        /// <param name="destination">Destination WebAction object</param>
        /// <param name="fulfilledConditions">Conditionals fulfilled</param>
        /// <returns></returns>
        public bool HasPath(WebAction source, WebAction destination, List<Condition<Enum>> fulfilledConditions)
        {
            if (source.Equals(destination))
            {
                return true;
            }

            HashSet<WebAction> visited = new HashSet<WebAction>();
            Queue<WebAction> queue = new Queue<WebAction>();

            visited.Add(source);
            queue.Enqueue(source);

            while (queue.Count != 0)
            {
                WebAction current = queue.Dequeue();

                if (current.Equals(destination))
                {
                    return true;
                }

                if (AdjacencyList.ContainsKey(current))
                {
                    foreach (WebAction neighbor in AdjacencyList[current].Keys)
                    {
                        bool conditionsFulfilled = !AdjacencyList[current][neighbor].Except(fulfilledConditions).Any();

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


        public void RemoveEdge(WebAction source, WebAction destination)
        {
            if (AdjacencyList.ContainsKey(source) && AdjacencyList[source].ContainsKey(destination))
            {
                AdjacencyList[source].Remove(destination);
            }
        }
    }
}
