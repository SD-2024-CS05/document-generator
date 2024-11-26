using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
                        Node = ConvertShapeToNode(shapeFromVisio),
                        ShapeData = ReadShapeData(shapeFromVisio),
                        Connections = GetConnected(shapeFromVisio)
                    };
                    nodes.Add(node);
                }
            }
            nodes.RemoveAt(0); // For some reason the active page is a "shape"
            const string startLabel = "5";
            nodes = nodes.SkipWhile(x => x.Name != startLabel)
                .Concat(nodes.TakeWhile(x => x.Name != startLabel))
                .ToList();
            HtmlGraph htmlGraph = ConvertNodesToGraph(nodes);
            return htmlGraph;
        }

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
            if (Regex.IsMatch(type, "\\W*((?i)Start/End(?-i))\\W*"))
                return NodeType.StartEnd;
            if (Regex.IsMatch(type, "\\W*((?i)Decision(?-i))\\W*"))
                return NodeType.Decision;
            if (Regex.IsMatch(type, "\\W*((?i)Input Data(?-i))\\W*"))
                return NodeType.DataInput;
             if (Regex.IsMatch(type, "\\W*((?i)Process(?-i))\\W*"))
                return NodeType.UserProcess;
            if (Regex.IsMatch(type, "\\W*((?i)Page(?-i))\\W*"))
                return NodeType.Page;
            // TODO: Special Connector
            if (Regex.IsMatch(type, "\\W*((?i)Subprocess(?-i))\\W*"))
                return NodeType.BackgroundProcess;
            return NodeType.HtmlElement;
        }

        /// <summary>
        /// Converts a transformed shape to a node
        /// </summary>
        /// <param name="shape">Transformed shape</param>
        /// <returns>The node to be added to an HTML graph</returns>
        private static dynamic ConvertShapeToNode(Shape shape)
        {
            NodeType type = DetermineNodeType(shape.Name);
            dynamic node = null;
            switch (type)
            {
                case NodeType.StartEnd:
                    {
                        // Condition based off of TestFlowchartExample
                        if (shape.Text == "5")
                        {
                            node = new StartEndNode("start");
                            node.IsStart = true;
                        }
                        // Condition based off of TestFlowchartExample
                        if (shape.Text == "5.1")
                            node = new StartEndNode("end");
                    }
                    break;
                case NodeType.Decision: node = new DecisionNode(shape.Text); break;
                case NodeType.DataInput: node = new DataInputNode(shape.Text); break;
                case NodeType.UserProcess: node = new ProcessNode(shape.Text); break;
                case NodeType.Page: node = new PageNode("A"); break;
                // TODO: Special connector
                case NodeType.BackgroundProcess: node = new ProcessNode(shape.Text, true); break;
            }
            return node;
        }
    }
}