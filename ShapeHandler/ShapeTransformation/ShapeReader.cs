using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Text;
using Microsoft.Office.Interop.Visio;
using ShapeHandler.Objects;

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
                if (!Regex.IsMatch(shape.Name, "\\W*((?i)Dynamic connector(?-i))\\W*") && !Regex.IsMatch(shape.Name, "\\W*((?i)Sheet(?-i))\\W*"))
                {
                    FlowchartNode node = ConvertShapeToNode(shape);
                    visioIDToGuid[shape.ID] = node.Id;
                    nodes.Add(node);
                }
            }

            // Begin the list at the start node
            nodes = nodes.SkipWhile(x => x.Label != "Start")
                .Concat(nodes.TakeWhile(x => x.Label != "Start"))
                .ToList();

            // Add the connections of the nodes
            foreach (Shape shape in shapes)
            {
                if (!Regex.IsMatch(shape.Name, "\\W*((?i)Dynamic connector(?-i))\\W*") && !Regex.IsMatch(shape.Name, "\\W*((?i)Sheet(?-i))\\W*"))
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
        /// Reads shape data from a given Visio shape
        /// </summary>
        /// <param name="shape">Visio shape</param>
        /// <returns>Dictionary of a shape data's labels as keys and values as values</returns>
        public static IDictionary<string, string> ReadShapeData(Shape shape)
        {
            IDictionary<string, string> properties = new Dictionary<string, string>();
            short iRow = (short)VisRowIndices.visRowFirst;
            while (
                shape.get_CellsSRCExists
                (
                    (short)VisSectionIndices.visSectionProp,
                    iRow,
                    (short)VisCellIndices.visCustPropsValue,
                    0
                ) < 0)
            {
                string label = shape.get_CellsSRC(
                        (short)VisSectionIndices.visSectionProp,
                        iRow,
                        (short)VisCellIndices.visCustPropsLabel
                    ).get_ResultStr(VisUnitCodes.visNoCast);
                string value = shape.get_CellsSRC(
                        (short)VisSectionIndices.visSectionProp,
                        iRow,
                        (short)VisCellIndices.visCustPropsValue
                    ).get_ResultStr(VisUnitCodes.visNoCast);
                // This is here until I can figure out how to add only one row to shape data
                if (!string.IsNullOrEmpty(label))
                    properties.Add(label, value);
                iRow++;
            }
            return properties;
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
                if (node is DataInputNode dtNode)
                {
                    foreach (HtmlNode n in dtNode.DataInputNodes)
                    {
                        htmlGraph.AddNode(n);
                        htmlGraph.AddConnection(n, dtNode, new Connection(n.Id, ConnectionType.INPUT_FOR));
                    }
                }
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
        /// Takes a shape's type and provides a NodeType enum 
        /// </summary>
        /// <param name="type">Shape type</param>
        /// <returns>Enum of node type</returns>
        private static Objects.NodeType DetermineNodeType(string type)
        {
            if (type == "Start/End")
                return Objects.NodeType.StartEnd;
            if (type == "Decision")
                return Objects.NodeType.Decision;
            if (type == "InputData")
                return Objects.NodeType.DataInput;
            if (type == "Process")
                return Objects.NodeType.UserProcess;
            if (type == "Page")
                return Objects.NodeType.Page;
            // TODO: Special Connector
            if (type == "Subprocess")
                return Objects.NodeType.BackgroundProcess;
            return Objects.NodeType.HtmlElement;
        }

        /// <summary>
        /// Converts a transformed shape to a node
        /// </summary>
        /// <param name="shape">Transformed shape</param>
        /// <returns>The node to be added to an HTML graph</returns>
        private static FlowchartNode ConvertShapeToNode(Shape shape)
        {
            IDictionary<string, string> shapeData = ReadShapeData(shape);
            Objects.NodeType type = DetermineNodeType(shapeData["NodeType"]);
            dynamic node = null;
            switch (type)
            {
                case Objects.NodeType.StartEnd:
                    {
                        bool isStart = shapeData["Is Start"].ToBoolean();
                        if (isStart)
                        {
                            node = new StartEndNode("Start");
                            node.IsStart = true;
                        }
                        else
                            node = new StartEndNode("End");
                    }
                    break;
                case Objects.NodeType.Decision: node = new DecisionNode(shape.Text); break;
                case Objects.NodeType.DataInput:
                    {
                        node = new DataInputNode(shape.Text);
                        IDictionary schema = JsonSerializer.Deserialize<Dictionary<string, string>>(shapeData["Input 1"]);
                        IHtmlInputElement input = document.CreateElement("input") as IHtmlInputElement;
                        input.Type = schema["type"].ToString();
                        input.Id = schema["id"].ToString();
                        input.Minimum = schema["min"].ToString();
                        input.Maximum = schema["max"].ToString();
                        input.ClassList.Add(schema["class"].ToString());
                        HtmlNode inputNode = new HtmlNode(input.Id, input, Objects.NodeType.Input);
                        node.DataInputNodes.Add(inputNode);
                        break;
                    }
                case Objects.NodeType.UserProcess: node = new ProcessNode(shape.Text); break;
                case Objects.NodeType.Page: node = new PageNode(shape.Text); break;
                // TODO: Special connector
                case Objects.NodeType.BackgroundProcess: node = new ProcessNode(shape.Text, true); break;
            }
            return node;
        }
    }
}