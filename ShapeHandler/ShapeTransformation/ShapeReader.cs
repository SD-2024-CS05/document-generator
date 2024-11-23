using System.Collections.Generic;
using Microsoft.Office.Interop.Visio;
using ShapeHandler.Objects;

namespace ShapeHandler.ShapeTransformation
{
    public class ShapeReader
    {
        /// <summary>
        /// Intakes shapes from Visio and transforms them into graph
        /// </summary>
        /// <param name="shapesFromVisio">Visio shapes</param>
        /// <returns>HTML graph adapted from Visio shapes</returns>
        public static HtmlGraph ConvertShapesToGraph(Shapes shapesFromVisio)
        {
            List<VisioShape> shapes = new List<VisioShape>();
            foreach (Shape shapeFromVisio in shapesFromVisio)
            {
                VisioShape shape = new VisioShape
                {
                    Name = shapeFromVisio.Text,
                    Type = DetermineNodeType(shapeFromVisio.Name),
                    ShapeData = ReadShapeData(shapeFromVisio)
                };
                shapes.Add(shape);
            }
            shapes.RemoveAt(0); // For some reason Visio provides an "extra" shape
            HtmlGraph htmlGraph = ConvertShapesToNodes(shapes);
            return htmlGraph;
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
        /// Takes a shape's type and provides a NodeType enum 
        /// </summary>
        /// <param name="type">Shape type</param>
        /// <returns>Enum of node type</returns>
        private static NodeType DetermineNodeType(string type)
        {
            switch (type)
            {
                // Condition based off of TestFlowchartExample
                case "Start/End": return NodeType.StartEnd;

                // Condition based off of TestFlowchartExample
                case "Start/End.17": return NodeType.StartEnd;

                // TODO: Decision
                // TODO: Input Data
                // TODO: Foreground Process

                // Condition based off of TestFlowchartExample
                case "Page": return NodeType.Page;

                // TODO: Special Connector
                // TODO: Background Process
                default: return NodeType.HtmlElement;
            }
        }

        /// <summary>
        /// Converts shapes to nodes
        /// </summary>
        /// <param name="shapes">Transformed </param>
        /// <returns>HTML graph</returns>
        private static HtmlGraph ConvertShapesToNodes(List<VisioShape> shapes)
        {
            HtmlGraph htmlGraph = new HtmlGraph();
            foreach (VisioShape shape in shapes)
            {
                dynamic node = AddNodeType(shape);
                if (node != null)
                    htmlGraph.AddNode(node);
            }
            return htmlGraph;
        }

        /// <summary>
        /// Converts a transformed shape to a node
        /// </summary>
        /// <param name="shape">Transformed shape</param>
        /// <returns>The node to be added to an HTML graph</returns>
        private static dynamic AddNodeType(VisioShape shape)
        {
            dynamic node = null;
            switch (shape.Type)
            {
                case NodeType.StartEnd:
                    {
                        // Condition based off of TestFlowchartExample
                        if (shape.Name == "5")
                        {
                            node = new StartEndNode("start");
                            node.IsStart = true;
                        }
                        // Condition based off of TestFlowchartExample
                        if (shape.Name == "5.1")
                            node = new StartEndNode("end");
                    }
                    break;
                // TODO: Decision
                // TODO: Input Data
                // TODO: Foreground process
                case NodeType.Page: node = new PageNode("A"); break;
                // TODO: Special connector
                // TODO: Background process
            }
            return node;
        }
    }
}