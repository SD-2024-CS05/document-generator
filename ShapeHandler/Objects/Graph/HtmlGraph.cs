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
        private Dictionary<FlowchartNode, Dictionary<FlowchartNode, List<Connection>>> AdjacencyList { get; set; } = new Dictionary<FlowchartNode, Dictionary<FlowchartNode, List<Connection>>>();

        public void AddNode(FlowchartNode node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("Node must be non-null");
            }
            if (!AdjacencyList.ContainsKey(node))
            {
                AdjacencyList[node] = new Dictionary<FlowchartNode, List<Connection>>();
            }
        }

        public void AddConnection(FlowchartNode source, FlowchartNode target, string label, string behavior)
        {
            var connection = new Connection(label, behavior, source, target);

            if (source == null || target == null)
            {
                throw new ArgumentNullException("Source and target must be non-null");
            }

            if (!AdjacencyList.ContainsKey(source))
            {
                AddNode(source);
            }
            if (!AdjacencyList[source].ContainsKey(target))
            {
                AdjacencyList[source][target] = new List<Connection>();
            }
            AdjacencyList[source][target].Add(connection);
        }
    }
}
