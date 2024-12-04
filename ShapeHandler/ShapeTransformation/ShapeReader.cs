using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AngleSharp.Text;
using Microsoft.Office.Interop.Visio;
using ShapeHandler.Objects;

namespace ShapeHandler.ShapeTransformation
{
    public class ShapeReader
    {
        public static HtmlGraph ConvertShapesToGraph(Shapes shapesFromVisio)
        {
            List<NodesNCrap> nodes = new List<NodesNCrap>();
            foreach (Shape shapeFromVisio in shapesFromVisio)
            {
                if (!Regex.IsMatch(shapeFromVisio.Name, "\\W*((?i)Dynamic connector(?-i))\\W*"))
                {
                    NodesNCrap node = new NodesNCrap
                    {
                        VisioID = shapeFromVisio.ID,
                        Name = shapeFromVisio.Text,
                        ShapeData = ReadShapeData(shapeFromVisio),
                        Connections = GetConnected(shapeFromVisio)
                    };
                    node.Node = ConvertShapeToNode(node);
                    nodes.Add(node);
                }
            }
            nodes.RemoveAt(0); // For some reason the active page is a "shape"

            // Begin the list at the start node
            const string startLabel = "start";
            nodes = nodes.SkipWhile(x => x.Name != startLabel)
                .Concat(nodes.TakeWhile(x => x.Name != startLabel))
                .ToList();

            HtmlGraph htmlGraph = ConvertNodesToGraph(nodes);
            return htmlGraph;
        }

        /// <summary>
        /// Gets the connected shapes of a shape
        /// </summary>
        /// <param name="shape">Visio shape</param>
        /// <returns>List of connected shapes to a shape</returns>
        private static List<VisioConnector> GetConnected(Shape shape)
        {
            List<VisioConnector> connections = new List<VisioConnector>();
            Array connectedShapeArrayTargetIDs = shape.ConnectedShapes(VisConnectedShapesFlags.visConnectedShapesOutgoingNodes, "");
            Array connectorArrayTargetIDs = shape.GluedShapes(VisGluedShapesFlags.visGluedShapesOutgoing1D, "");
            for (int i = connectedShapeArrayTargetIDs.GetLowerBound(0); i <= connectedShapeArrayTargetIDs.GetUpperBound(0); i++)
            {
                Shape connector = shape.ContainingPage.Shapes.ItemFromID[(int)connectorArrayTargetIDs.GetValue(i)];
                Shape connectedShape = shape.ContainingPage.Shapes.ItemFromID[(int)connectedShapeArrayTargetIDs.GetValue(i)];
                VisioConnector connection = new VisioConnector
                {
                    Name = connector.Text,
                    ConnectedShapeID = connectedShape.ID
                };
                connections.Add(connection);
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
        private static HtmlGraph ConvertNodesToGraph(List<NodesNCrap> nodes)
        {
            HtmlGraph htmlGraph = new HtmlGraph();
            foreach (NodesNCrap node in nodes)
            {
                htmlGraph.AddNode(node.Node);
            }
            foreach (NodesNCrap node in nodes)
            {
                foreach (VisioConnector connection in node.Connections)
                {
                    htmlGraph.AddConnection(
                        node.Node,
                        nodes.Find(x => x.VisioID == connection.ConnectedShapeID).Node,
                        new Connection(connection.Name)
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
        private static NodeType DetermineNodeType(string type)
        {
            if (type == "Start/End")
                return NodeType.StartEnd;
            if (type == "Decision")
                return NodeType.Decision;
            if (type == "Input Data")
                return NodeType.DataInput;
            if (type == "Process")
                return NodeType.UserProcess;
            if (type == "Page")
                return NodeType.Page;
            // TODO: Special Connector
            if (type == "Subprocess")
                return NodeType.BackgroundProcess;
            return NodeType.HtmlElement;
        }

        /// <summary>
        /// Converts a transformed shape to a node
        /// </summary>
        /// <param name="shape">Transformed shape</param>
        /// <returns>The node to be added to an HTML graph</returns>
        private static dynamic ConvertShapeToNode(NodesNCrap nodeToConvert)
        {
            NodeType type = DetermineNodeType(nodeToConvert.ShapeData["Node Type"]);
            dynamic node = null;
            switch (type)
            {
                case NodeType.StartEnd:
                    {
                        bool isStart = nodeToConvert.ShapeData["Is Start"].ToBoolean();
                        if (isStart)
                        {
                            node = new StartEndNode("start");
                            node.IsStart = true;
                        }
                        else
                            node = new StartEndNode("end");
                    }
                    break;
                case NodeType.Decision: node = new DecisionNode(nodeToConvert.Name); break;
                case NodeType.DataInput: node = new DataInputNode(nodeToConvert.Name); break;
                case NodeType.UserProcess: node = new ProcessNode(nodeToConvert.Name); break;
                case NodeType.Page: node = new PageNode(nodeToConvert.Name); break;
                // TODO: Special connector
                case NodeType.BackgroundProcess: node = new ProcessNode(nodeToConvert.Name, true); break;
            }
            return node;
        }
    }
}