using AngleSharp.Html.Dom;
using AngleSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapeHandler.Database;
using ShapeHandler.Identity;
using ShapeHandler.Objects;
using System;
using System.Collections.Generic;

namespace ShapeHandler.Tests.Database
{
    [TestClass()]
    public class TestFlowChartExample
    {

        private HtmlGraph graph;

        [TestInitialize()]
        public void Setup()
        {
            var htmlGraph = new HtmlGraph();
            var context = BrowsingContext.New(Configuration.Default);
            var document = context.OpenNewAsync().Result;

            #region Create Form Elements

            /// Start Node
            var start = new StartEndNode("start");

            /// Input Form Node
            var inputTempSensor = document.CreateElement("input") as IHtmlInputElement;
            inputTempSensor.Type = "number";
            inputTempSensor.Id = "inputTempSensor";
            inputTempSensor.Minimum = 50.ToString();
            inputTempSensor.Maximum = 150.ToString();
            inputTempSensor.ClassList.Add("form-control");

            var inputTempSensorNode = new HtmlNode(inputTempSensor);

            /// Checkbox Node
            var setFastCoolingMode = document.CreateElement("input") as IHtmlInputElement;
            setFastCoolingMode.Type = "checkbox";
            setFastCoolingMode.Id = "inputCoolingMode";
            setFastCoolingMode.ClassList.Add("form-check-input");
            setFastCoolingMode.IsChecked = true;

            var setFastCoolingModeNode = new HtmlNode(setFastCoolingMode);

            /// Input Form Node
            var inputWaitTime = document.CreateElement("input") as IHtmlInputElement;
            inputWaitTime.Type = "number";
            inputWaitTime.Id = "inputWaitTime";
            inputWaitTime.Value = 3.ToString();

            var inputWaitTimeNode = new HtmlNode(inputWaitTime);

            /// Decision Node
            /// Submit Button

            var submitButton = document.CreateElement("button") as IHtmlButtonElement;
            submitButton.Id = "submitButton";
            submitButton.Type = "submit";

            var submitButtonNode = new HtmlNode(submitButton);

            /// Cancel Button
            var cancelButton = document.CreateElement("a") as IHtmlAnchorElement;
            cancelButton.Id = "cancelButton";
            cancelButton.Href = "/fast-cooling/input";

            var cancelButtonNode = new HtmlNode(cancelButton);

            /// Conditions
            Condition submitCondition = new Condition
            {
                ElementType = "button",
                Attribute = "id",
                AttributeValue = "submitButton",
                IsActive = true,
                Validate = (value) => value == "submitButton"
            };

            Condition cancelCondition = new Condition
            {
                ElementType = "a",
                Attribute = "id",
                AttributeValue = "cancelButton",
                IsActive = true,
                Validate = (value) => value == "cancelButton"
            };

            DecisionNode submitDecisionNode = new DecisionNode("Submit Results?", new List<IHtmlElement> { submitButton, cancelButton });

            /// View Related Data Decision Node
            var yesButton = document.CreateElement("button") as IHtmlButtonElement;
            yesButton.Id = "viewRelatedDataButton";
            yesButton.Type = "submit";

            var yesButtonNode = new HtmlNode(yesButton);

            var noButton = document.CreateElement("button") as IHtmlButtonElement;
            noButton.Type = "submit";

            var noButtonNode = new HtmlNode(noButton);

            Condition yesCondition = new Condition
            {
                ElementType = "button",
                Attribute = "id",
                AttributeValue = "viewRelatedDataButton",
                IsActive = true,
                Validate = (value) => value == "viewRelatedDataButton"
            };

            Condition noCondition = new Condition
            {
                ElementType = "button",
                Attribute = "id",
                AttributeValue = "",
                IsActive = true,
                Validate = (value) => value == ""
            };

            DecisionNode viewRelatedDataDecisionNode = new DecisionNode("View Related Data?", new List<IHtmlElement> { yesButton, noButton });

            /// End Node

            var end = new StartEndNode("end");

            #endregion

            #region Create Graph

            htmlGraph.AddNode(start);
            htmlGraph.AddNode(inputTempSensorNode);
            htmlGraph.AddNode(setFastCoolingModeNode);
            htmlGraph.AddNode(inputWaitTimeNode);
            htmlGraph.AddNode(submitDecisionNode);
            htmlGraph.AddNode(end);

            /// Create Connections
            Connection startToInput = new Connection("1");
            Connection inputToDecisionNode = new Connection("2");

            /// Add connections for decision nodes
            Connection cancelConnection = new Connection("N 3", new List<Condition> { cancelCondition });
            Connection submitConnection = new Connection("Y 4", new List<Condition> { submitCondition });
            Connection yesConnection = new Connection("Y 5", new List<Condition> { yesCondition });
            Connection noConnection = new Connection("N 6", new List<Condition> { noCondition });

            htmlGraph.AddConnection(start, end, startToInput);
            htmlGraph.AddConnection(inputTempSensorNode, submitDecisionNode, inputToDecisionNode);
            htmlGraph.AddConnection(submitDecisionNode, viewRelatedDataDecisionNode, submitConnection);
            htmlGraph.AddConnection(submitDecisionNode, inputTempSensorNode, cancelConnection);
            htmlGraph.AddConnection(viewRelatedDataDecisionNode, end, yesConnection);
            htmlGraph.AddConnection(viewRelatedDataDecisionNode, inputTempSensorNode, noConnection);

            #endregion

            graph = htmlGraph;
        }

        [TestMethod()]
        [Ignore] // Ignored because it writes to the database
        public void WriteTestFlowchartToFile()
        {
            DatabaseConnector connector = new KeyVaultManager().ConnectToDatabase();

            if (connector.WriteHtmlGraphAsync(graph).Result == false)
            {
                Console.WriteLine("Failed to write Instruction Set to database");
            }
            else
            {
                Console.WriteLine("Instruction Set written to database");
            }
        }
    }
}
