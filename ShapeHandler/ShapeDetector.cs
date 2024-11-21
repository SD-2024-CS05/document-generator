using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Visio = Microsoft.Office.Interop.Visio;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Interop.Visio;
using ShapeHandler.Objects;
using ShapeHandler.Identity;
using ShapeHandler.Database;
using System.Reflection.Emit;
using System.Runtime.Remoting.Contexts;
using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using Microsoft.Extensions.Azure;

namespace ShapeHandler
{
    public partial class ShapeDetector
    {
        private void ShapeDetector_Startup(object sender, System.EventArgs e)
        {
            // Uncomment for local testing
            //ShapeDetector.CreateGraphFromFlowchart(Globals.ShapeDetector.Application);
        }

        private void ShapeDetector_Shutdown(object sender, System.EventArgs e)
        {
        }

        public static HtmlGraph CreateGraphFromFlowchart(Visio.Application application)
        {
            Page page = application.ActivePage;
            List<VisioShape> shapesFromVisio = FetchShapesFromVisio(page.Shapes);
            HtmlGraph graph = new HtmlGraph();
            // TODO: Implement
            return null;
        }

        class VisioShape
        {
            public string Name { get; set; }
            public string Type { get; set; }
            public IDictionary<string, string> ShapeData { get; set; }
        }

        /// <summary>
        /// Intakes shapes from Visio
        /// </summary>
        /// <param name="shapesFromVisio">Visio shapes</param>
        /// <returns>Inner dictionary with shapes and their properties</returns>
        private static List<VisioShape> FetchShapesFromVisio(Shapes shapesFromVisio)
        {
            List<VisioShape> shapes = new List<VisioShape>();
            foreach (Shape shapeFromVisio in shapesFromVisio)
            {
                VisioShape shape = new VisioShape
                {
                    Name = shapeFromVisio.Text,
                    Type = shapeFromVisio.Name,
                    ShapeData = ReadShapeData(shapeFromVisio)
                };
                shapes.Add(shape);
            }
            return shapes;
        }

        /// <summary>
        /// Reads shape data from a given Visio shape
        /// </summary>
        /// <param name="shape">Visio shape</param>
        /// <returns>Dictionary of a shape data's labels as keys and values as values</returns>
        private static IDictionary<string, string> ReadShapeData(Shape shape)
        {
            IDictionary<string, string> properties = new Dictionary<string, string>();
            short iRow = (short)VisRowIndices.visRowFirst;
            while (shape.get_CellsSRCExists(
                (short)VisSectionIndices.visSectionProp,
                iRow,
                (short)VisCellIndices.visCustPropsValue,
                (short)0) != 0)
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

        private static void ConvertShapesToAngleSharp(List<VisioShape> shapes)
        {
            HtmlGraph htmlGraph = new HtmlGraph();
            IBrowsingContext context = BrowsingContext.New(Configuration.Default);
            IDocument document = context.OpenNewAsync().Result;
            DataInputNode viewRelatedDataFormNode = new DataInputNode("View Related Data");
            DecisionNode viewRelatedDataDecisionNode = new DecisionNode("View Related Data?");
            foreach (VisioShape shape in shapes)
            {
                switch (shape.Type)
                {
                    case "Start/End":
                        {
                            StartEndNode startEnd = null;
                            if (shape.Name == "start")
                            {
                                startEnd = new StartEndNode("start")
                                {
                                    IsStart = true
                                };
                            }
                            if (shape.Name == "end")
                                startEnd = new StartEndNode("end");
                            htmlGraph.AddNode(startEnd);
                        }
                        break;
                    case "Decision":
                        {
                            // TODO: Change the properties
                            // to be more generalized and
                            // not based off the example
                            dynamic button;
                            HtmlNode buttonNode;
                            if ("lol" == "lol") // submit
                            {
                                button = document.CreateElement("input") as IHtmlInputElement;
                                button.Id = "submitButton";
                                button.Type = "submit";
                                buttonNode = new HtmlNode(button.Id, button, Objects.NodeType.Button);
                            }
                            if ("nice" == "nice") // cancel
                            {
                                button = document.CreateElement("a") as IHtmlAnchorElement;
                                button.Id = "cancelButton";
                                button.Href = "/fast-cooling/input";
                                buttonNode = new HtmlNode(button.Id, button, Objects.NodeType.Anchor);
                            }
                            if ("yes" == "yes") // yes button for view related form data?
                            {
                                button = document.CreateElement("button") as IHtmlInputElement;
                                button.Id = "viewRelatedDataButton";
                                button.Type = "submit";
                                buttonNode = new HtmlNode(button.Id, button, Objects.NodeType.Button);
                            }
                            if ("no" == "no") // no button for view related form data?
                            {
                                button = document.CreateElement("button") as IHtmlAnchorElement;
                                button.Type = "submit";
                                buttonNode = new HtmlNode(button.Id, button, Objects.NodeType.Anchor);
                            }
                            if ("backToInput" == "backToInput") // back to input for view related form data?
                            {
                                button = document.CreateElement("a") as IHtmlAnchorElement;
                                button.Href = "/fast-cooling/input";
                                button.ClassList.Add(new string[] { "btn", "btn-primary" });
                            }
                            viewRelatedDataFormNode.DataInputNodes.Add(buttonNode);
                            htmlGraph.AddNode(buttonNode);
                        }
                        break;
                    case "Input Data":
                        {
                            // TODO: Change the properties
                            // to be more generalized and
                            // not based off the example
                            IHtmlInputElement input = document.CreateElement("input") as IHtmlInputElement;
                            input.Type = "number";
                            input.Id = "inputTempSensor";
                            input.Minimum = 50.ToString();
                            input.Maximum = 150.ToString();
                            input.ClassList.Add("form-control");
                            HtmlNode inputNode = new HtmlNode(input.Id, input, Objects.NodeType.Input);
                            htmlGraph.AddNode(inputNode);
                        }
                        break;
                    case "foreground process":
                        {
                            // TODO: Put foreground process stuff
                        }
                        break;
                    case "Page":
                        {
                            PageNode pageANode = new PageNode("A");
                            htmlGraph.AddNode(pageANode);
                        }
                        break;
                    case "Special connector":
                        {
                            // TODO: Put special connector
                        }
                        break;
                    case "Background process":
                        {
                            // TODO: Put background process connector
                        }
                        break;
                }
            }
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ShapeDetector_Startup);
            this.Shutdown += new System.EventHandler(ShapeDetector_Shutdown);
        }

        #endregion
    }
}
