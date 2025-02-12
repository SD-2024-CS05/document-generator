using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Text;
using Microsoft.Office.Interop.Visio;
using ShapeHandler.Objects;
using Newtonsoft.Json.Linq;

namespace ShapeHandler.ShapeTransformation
{
    public class ShapeReader
    {
        private static IBrowsingContext context = BrowsingContext.New(Configuration.Default);
        private static IDocument document = context.OpenNewAsync().Result;
        public static HtmlGraph ConvertShapesToGraph(Shapes shapes)
        {
            // Mapping between Visio Shape IDs and Node Guids
            IDictionary<int, string> visioIDToGuid = new Dictionary<int, string>();

            // Connections between nodes - Inner dictionary because 1st key is the node's ID,
            // 2nd key(s) are IDs of nodes connected to the original node, the value is the
            // label of the connection
            IDictionary<string, IDictionary<string, string>> connections = new Dictionary<string, IDictionary<string, string>>();

            // Nodes
            List<FlowchartNode> nodes = new List<FlowchartNode>();

            foreach (Shape shape in shapes)
            {
                var isSpecialConnector = VisioShapeDataHelper.GetShapeData(shape.ID)["Node Type"]?.ToString() == "Special Connector";
                var isSheet = Regex.IsMatch(shape.Name, "\\W*((?i)Sheet(?-i))\\W*");
                if (!isSpecialConnector && !isSheet)
                {
                    FlowchartNode node = ConvertShapeToNode(shape);
                    if (node != null)
                    {
                        visioIDToGuid[shape.ID] = node.Id;
                        nodes.Add(node);
                    }
                }
            }

            // Begin the list at the start node
            nodes = nodes.SkipWhile(x => x.Label != "Start")
                .Concat(nodes.TakeWhile(x => x.Label != "Start"))
                .ToList();

            // Add the connections of the nodes
            foreach (Shape shape in shapes)
            {
                var isSpecialConnector = VisioShapeDataHelper.GetShapeData(shape.ID)["Node Type"]?.ToString() == "Special Connector";
                var isSheet = Regex.IsMatch(shape.Name, "\\W*((?i)Sheet(?-i))\\W*");
                if (!isSpecialConnector && !isSheet)
                {
                    IDictionary<string, string> connected = GetConnected(shape, visioIDToGuid);
                    connections[visioIDToGuid[shape.ID]] = connected;
                }
            }

            // Convert nodes to a graph
            HtmlGraph htmlGraph = ConvertNodesToGraph(nodes, connections);

            return htmlGraph;
        }

        /// <summary>
        /// Gets the connected shapes of a shape
        /// </summary>
        /// <param name="shape">Visio shape</param>
        /// <returns>List of connected shapes to a shape</returns>
        private static IDictionary<string, string> GetConnected(Shape shape, IDictionary<int, string> visioIDToGuid)
        {
            IDictionary<string, string> connections = new Dictionary<string, string>();
            Array connectedShapeArrayTargetIDs = shape.ConnectedShapes(VisConnectedShapesFlags.visConnectedShapesOutgoingNodes, "");
            Array connectorArrayTargetIDs = shape.GluedShapes(VisGluedShapesFlags.visGluedShapesOutgoing1D, "");
            for (int i = connectedShapeArrayTargetIDs.GetLowerBound(0); i <= connectedShapeArrayTargetIDs.GetUpperBound(0); i++)
            {
                Shape connector = shape.ContainingPage.Shapes.ItemFromID[(int)connectorArrayTargetIDs.GetValue(i)];
                Shape connectedShape = shape.ContainingPage.Shapes.ItemFromID[(int)connectedShapeArrayTargetIDs.GetValue(i)];
                connections.Add(visioIDToGuid[connectedShape.ID], connector.Text);
            }
            return connections;
        }

        /// <summary>
        /// Converts nodes to graph
        /// </summary>
        /// <param name="nodes">List of nodes</param>
        /// <returns>HTML graph</returns>
        private static HtmlGraph ConvertNodesToGraph(List<FlowchartNode> nodes, IDictionary<string, IDictionary<string, string>> connections)
        {
            HtmlGraph htmlGraph = new HtmlGraph();
            foreach (FlowchartNode node in nodes)
            {
                htmlGraph.AddNode(node);
            }
            foreach (FlowchartNode node in nodes)
            {
                foreach (KeyValuePair<string, string> connection in connections[node.Id])
                {
                    htmlGraph.AddConnection(
                        node,
                        nodes.Find(x => x.Id == connection.Key),
                        new Connection(connection.Value)
                    );
                }
            }
            return htmlGraph;
        }

        /// <summary>
        /// Converts a transformed shape to a node
        /// </summary>
        /// <param name="shape">Transformed shape</param>
        /// <returns>The node to be added to an HTML graph</returns>
        private static FlowchartNode ConvertShapeToNode(Shape shape)
        {
            var shapeData = VisioShapeDataHelper.GetShapeData(shape.ID);
            var htmlElements = VisioShapeDataHelper.GetHtmlElements(shape.ID);
            var type = VisioShapeDataHelper.GetNodeType(shape.ID);
            dynamic node = null;
            switch (type)
            {
                case Objects.NodeType.StartEnd:
                    bool isStart = shapeData["IsStart"].ToString().ToBoolean();
                    string url = shapeData["URL"].ToString();
                    if (isStart)
                    {
                        node = new StartEndNode("Start")
                        {
                            IsStart = true,
                            URL = url
                        };
                    }
                    else
                    {
                        node = new StartEndNode("End")
                        {
                            IsStart = false,
                            URL = url
                        };
                    }
                    break;
                case Objects.NodeType.Decision:
                    {
                        node = new DecisionNode(shape.Text);
                        htmlElements.ForEach(he =>
                        {
                            HtmlNode htmlNode = new HtmlNode(he.Id, he);
                            node.SubmissionNodes.Add(htmlNode);
                        });
                        break;
                    }
                case Objects.NodeType.DataInput:
                    node = new DataInputNode(shape.Text);
                    htmlElements.ForEach(he =>
                    {
                        HtmlNode htmlNode = new HtmlNode(he.Id, he);
                        node.DataInputNodes.Add(htmlNode);
                    });

                    break;
                case Objects.NodeType.UserProcess:
                    node = new ProcessNode(shape.Text);
                    break;
                case Objects.NodeType.BackgroundProcess:
                    node = new ProcessNode(shape.Text, true);
                    break;
                case Objects.NodeType.Page:
                    node = new PageNode(shape.Text);
                    break;
                default:
                    break;
            }
            return node;
        }
    }
}