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
using Neo4jClient.Cypher;

namespace ShapeHandler.ShapeTransformation
{
    public class ShapeReader
    {
        private static IBrowsingContext context = BrowsingContext.New(Configuration.Default);
        private static IDocument document = context.OpenNewAsync().Result;

        /// <summary>
        /// Converts Visio shapes to an HTML graph
        /// </summary>
        /// <param name="shapes">Visio shapes</param>
        /// <returns>HTML graph</returns>
        public static HtmlGraph ConvertShapesToGraph(Shapes shapes)
        {
            // Mapping between Visio Shape IDs and Node Guids
            IDictionary<int, string> visioIDToGuid = new Dictionary<int, string>();

            // Connections between nodes - Inner dictionary because 1st key is the node's ID,
            // 2nd key(s) are IDs of nodes connected to the original node, the value is the
            // label of the connection
            IDictionary<string, IDictionary<string, Connection>> connections = new Dictionary<string, IDictionary<string, Connection>>();

            // function that does the isSpecialConnector and isSheet check
            Func<Shape, bool> isSpecialConnectorOrSheet = (shape) =>
            {
                var isSpecialConnector = VisioShapeDataHelper.GetNodeType(shape.ID) == Objects.NodeType.Connection;
                var isSheet = Regex.IsMatch(shape.Name, "\\W*((?i)Sheet(?-i))\\W*");
                return isSpecialConnector || isSheet;
            };

            // Nodes
            List<FlowchartNode> nodes = new List<FlowchartNode>();

            foreach (Shape shape in shapes)
            {
                // skip special connectors and sheets
                if (!isSpecialConnectorOrSheet(shape))
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
                if (!isSpecialConnectorOrSheet(shape))
                {
                    IDictionary<string, Connection> connected = GetConnected(shape, visioIDToGuid);
                    connections[visioIDToGuid[shape.ID]] = connected;
                }
            }

            // Convert nodes to a graph
            HtmlGraph htmlGraph = ConvertNodesToGraph(nodes, connections);

            return htmlGraph;
        }

        /// <summary>
        /// Checks if the given shape is a valid connection.
        /// </summary>
        /// <param name="shape">The Visio shape to check.</param>
        /// <returns>True if the shape is a valid connection, otherwise false.</returns>
        public static bool IsValidDecisionConnection(Shape shape)
        {
            // Check if the shape is of NodeType.Connection
            if (VisioShapeDataHelper.GetNodeType(shape.ID) != Objects.NodeType.Connection)
            {
                return false;
            }

            // Check if the connection is from a DecisionNode
            var decisionNodeID = IsConnectionFromDecisionNode(shape);
            if (decisionNodeID == -1)
            {
                return false;
            }

            // check if decision node has at most 2 connections already
            var decisionNode = shape.ContainingPage.Shapes.ItemFromID[decisionNodeID];
            var connectedShapeArrayTargetIDs = decisionNode.GluedShapes(VisGluedShapesFlags.visGluedShapesOutgoing1D, "");

            return connectedShapeArrayTargetIDs.Length <= 2;
        }

        /// <summary>
        /// Gets the DecisionNode that the connection is coming from.
        /// </summary>
        /// <param name="shape">The Visio shape to check.</param>
        /// <returns>The DecisionNode that the connection is coming from or null otherwise.</returns>
        public static DecisionNode GetBoundDecisionNode(Shape shape)
        {
            if (VisioShapeDataHelper.GetNodeType(shape.ID) != Objects.NodeType.Connection)
            {
                return null;
            }

            var decisionNodeID = IsConnectionFromDecisionNode(shape);
            if (decisionNodeID == -1)
            {
                return null;
            }

            var decisionNode = shape.ContainingPage.Shapes.ItemFromID[decisionNodeID];
            var node = ConvertShapeToNode(decisionNode);
            return node as DecisionNode;
        }

        public static DataInputNode GetBoundDataInputNode(Shape shape)
        {

            if (VisioShapeDataHelper.GetNodeType(shape.ID) != Objects.NodeType.Decision)
            {
                return null;
            }

            // a decision node may or may not be connected to a data input node by a connection
            var connectedShapeArrayTargetIDs = shape.GluedShapes(VisGluedShapesFlags.visGluedShapesIncoming1D, "");
            if (connectedShapeArrayTargetIDs.Length == 0)
            {
                return null;
            }

            // for each incoming connection, check if the source is a data input
            for (int i = connectedShapeArrayTargetIDs.GetLowerBound(0); i <= connectedShapeArrayTargetIDs.GetUpperBound(0); i++)
            {
                var connectionShape = shape.ContainingPage.Shapes.ItemFromID[(int)connectedShapeArrayTargetIDs.GetValue(i)];
                var connectedShapeArraySourceIDs = connectionShape.GluedShapes(VisGluedShapesFlags.visGluedShapesIncoming2D, "");
                if (connectedShapeArraySourceIDs.Length == 0)
                {
                    continue;
                }

                var connectedShape = shape.ContainingPage.Shapes.ItemFromID[(int)connectedShapeArraySourceIDs.GetValue(0)];
                if (VisioShapeDataHelper.GetNodeType(connectedShape.ID) == Objects.NodeType.DataInput)
                {
                    return ConvertShapeToNode(connectedShape) as DataInputNode;
                }
            }

            return null;
        }

        /// <summary>
        /// Checks if the given connection shape is from a DecisionNode.
        /// </summary>
        /// <param name="shape">The Visio shape to check.</param>
        /// <returns>ID of the Decision Node Shape the connection is coming from or -1 otherwise</returns>
        public static int IsConnectionFromDecisionNode(Shape shape)
        {
            // Check if the shape is of NodeType.Connection
            if (VisioShapeDataHelper.GetNodeType(shape.ID) == Objects.NodeType.Connection)
            {
                // Get the connected shapes
                Array connectedShapeArraySourceIDs = shape.GluedShapes(VisGluedShapesFlags.visGluedShapesIncoming2D, "");
                for (int i = connectedShapeArraySourceIDs.GetLowerBound(0); i <= connectedShapeArraySourceIDs.GetUpperBound(0); i++)
                {
                    Shape connectedShape = shape.ContainingPage.Shapes.ItemFromID[(int)connectedShapeArraySourceIDs.GetValue(i)];
                    // Check if the connected shape is a DecisionNode
                    if (VisioShapeDataHelper.GetNodeType(connectedShape.ID) == Objects.NodeType.Decision)
                    {
                        return connectedShape.ID;
                    }
                }
            }
            return -1;
        }


        /// <summary>
        /// Gets the connected shapes of a shape
        /// </summary>
        /// <param name="shape">Visio shape</param>
        /// <returns>List of connected shapes to a shape</returns>
        private static IDictionary<string, Connection> GetConnected(Shape shape, IDictionary<int, string> visioIDToGuid)
        {
            IDictionary<string, Connection> connections = new Dictionary<string, Connection>();
            Array connectedShapeArrayTargetIDs = shape.ConnectedShapes(VisConnectedShapesFlags.visConnectedShapesOutgoingNodes, "");
            Array connectorArrayTargetIDs = shape.GluedShapes(VisGluedShapesFlags.visGluedShapesOutgoing1D, "");
            for (int i = connectedShapeArrayTargetIDs.GetLowerBound(0); i <= connectedShapeArrayTargetIDs.GetUpperBound(0); i++)
            {
                Shape connector = shape.ContainingPage.Shapes.ItemFromID[(int)connectorArrayTargetIDs.GetValue(i)];
                Shape connectedShape = shape.ContainingPage.Shapes.ItemFromID[(int)connectedShapeArrayTargetIDs.GetValue(i)];

                var shapeData = VisioShapeDataHelper.GetShapeData(connector.ID);

                var connection = new Connection(connector.Text);
                if (shapeData.ContainsKey("Connection"))
                {
                    var serializedData = shapeData["Connection"].ToString();
                    connection = JsonConvert.DeserializeObject<Connection>(serializedData);
                    connection.Label = connector.Text;
                }

                connections.Add(visioIDToGuid[connectedShape.ID], connection);
            }
            return connections;
        }

        /// <summary>
        /// Converts nodes to graph
        /// </summary>
        /// <param name="nodes">List of nodes</param>
        /// <returns>HTML graph</returns>
        private static HtmlGraph ConvertNodesToGraph(List<FlowchartNode> nodes, IDictionary<string, IDictionary<string, Connection>> connections)
        {
            HtmlGraph htmlGraph = new HtmlGraph();
            foreach (FlowchartNode node in nodes)
            {
                htmlGraph.AddNode(node);
            }
            foreach (FlowchartNode node in nodes)
            {
                foreach (KeyValuePair<string, Connection> connection in connections[node.Id])
                {
                    if (node is DataInputNode)
                    {
                        if (htmlGraph.GetConnectedNodesTo(nodes.Find(x => x.Id == connection.Key)).Keys.OfType<DataInputNode>().Count() < 1 && !htmlGraph.GetConnectedNodesTo(nodes.Find(x => x.Id == connection.Key)).ContainsKey(node))
                        {
                            htmlGraph.AddConnection(
                                node,
                                nodes.Find(x => x.Id == connection.Key),
                                connection.Value
                            );
                        }
                    }
                    else
                    {
                        htmlGraph.AddConnection(
                            node,
                            nodes.Find(x => x.Id == connection.Key),
                            connection.Value
                        );
                    }
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
                    node = new DecisionNode(shape.Text);
                    var lol = new DecisionNode("lol");
                    htmlElements.ForEach(he =>
                    {
                        HtmlNode htmlNode = new HtmlNode(he.Id, he);
                        int buttonCount = node.SubmissionNodes.OfType<IHtmlButtonElement>().Count();
                        int anchorCount = node.SubmissionNodes.OfType<IHtmlAnchorElement>().Count();
                        int count = buttonCount + anchorCount;
                        // Element will only be added if there is less than two anchors and/or buttons
                        if (count < 2)
                        {
                            node.SubmissionNodes.Add(htmlNode);
                        }
                    });
                    break;
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