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
            start.IsStart = true;

            /// Input Form Node
            var inputTempSensor = document.CreateElement("input") as IHtmlInputElement;
            inputTempSensor.Type = "number";
            inputTempSensor.Id = "inputTempSensor";
            inputTempSensor.Minimum = 50.ToString();
            inputTempSensor.Maximum = 150.ToString();
            inputTempSensor.ClassList.Add("form-control");

            var inputTempSensorNode = new HtmlNode(inputTempSensor.Id, inputTempSensor);

            /// Checkbox Node
            var setFastCoolingMode = document.CreateElement("input") as IHtmlInputElement;
            setFastCoolingMode.Type = "checkbox";
            setFastCoolingMode.Id = "inputCoolingMode";
            setFastCoolingMode.ClassList.Add("form-check-input");
            setFastCoolingMode.IsChecked = true;

            var setFastCoolingModeNode = new HtmlNode(setFastCoolingMode.Id, setFastCoolingMode);

            /// Input Form Node
            var inputWaitTime = document.CreateElement("input") as IHtmlInputElement;
            inputWaitTime.Type = "number";
            inputWaitTime.Id = "inputWaitTime";
            inputWaitTime.Value = 3.ToString();

            var inputWaitTimeNode = new HtmlNode(inputWaitTime.Id, inputWaitTime);

            /// Decision Node
            /// Submit Button

            var submitButton = document.CreateElement("button") as IHtmlButtonElement;
            submitButton.Id = "submitButton";
            submitButton.Type = "submit";

            var submitButtonNode = new HtmlNode(submitButton.Id, submitButton);

            /// Cancel Button
            var cancelButton = document.CreateElement("a") as IHtmlAnchorElement;
            cancelButton.Id = "cancelButton";
            cancelButton.Href = "/fast-cooling/input";

            var cancelButtonNode = new HtmlNode(cancelButton.Id, cancelButton);

            /// Conditions
            Condition submitCondition = new Condition
            {
                ElementType = "button",
                Attribute = "id",
                AttributeValue = "submitButton",
                IsActive = true,
                Validate = (value) => value == "submitButton",
                NodeId = submitButtonNode.Id
            };

            Condition cancelCondition = new Condition
            {
                ElementType = "a",
                Attribute = "id",
                AttributeValue = "cancelButton",
                IsActive = true,
                Validate = (value) => value == "cancelButton",
                NodeId = cancelButtonNode.Id
            };

            DecisionNode submitDecisionNode = new DecisionNode("Submit Results?", new List<HtmlNode> { submitButtonNode, cancelButtonNode });

            /// View Related Data Decision Node
            var yesButton = document.CreateElement("button") as IHtmlButtonElement;
            yesButton.Id = "viewRelatedDataButton";
            yesButton.Type = "submit";

            var yesButtonNode = new HtmlNode(yesButton.Id, yesButton);

            var noButton = document.CreateElement("button") as IHtmlButtonElement;
            noButton.Type = "submit";

            var noButtonNode = new HtmlNode(noButton.Id, noButton);

            /// Conditions
            Condition yesCondition = new Condition
            {
                ElementType = "button",
                Attribute = "id",
                AttributeValue = "viewRelatedDataButton",
                IsActive = true,
                Validate = (value) => value == "viewRelatedDataButton",
                NodeId = yesButtonNode.Id
            };

            Condition noCondition = new Condition
            {
                ElementType = "button",
                Attribute = "id",
                AttributeValue = "",
                IsActive = true,
                Validate = (value) => value == "",
                NodeId = noButtonNode.Id
            };

            DecisionNode viewRelatedDataDecisionNode = new DecisionNode("View Related Data?" , new List<HtmlNode> { yesButtonNode, noButtonNode });

            /// End Node

            var end = new StartEndNode("end");

            #endregion

            #region Create Graph

            /// Add nodes
            htmlGraph.AddNode(start);
            htmlGraph.AddNode(inputTempSensorNode);
            htmlGraph.AddNode(submitButtonNode);
            htmlGraph.AddNode(cancelButtonNode);
            htmlGraph.AddNode(setFastCoolingModeNode);
            htmlGraph.AddNode(inputWaitTimeNode);
            htmlGraph.AddNode(viewRelatedDataDecisionNode);
            htmlGraph.AddNode(yesButtonNode);
            htmlGraph.AddNode(noButtonNode);
            htmlGraph.AddNode(submitDecisionNode);
            htmlGraph.AddNode(end);

            /// Create Connections
            Connection startToInput = new Connection("1");
            Connection inputToDecisionNode = new Connection("2");

            /// Add connections from decision nodes
            Connection cancelConnection = new Connection("N 3", new List<Condition> { cancelCondition });
            Connection submitConnection = new Connection("Y 4", new List<Condition> { submitCondition });
            Connection yesConnection = new Connection("Y 5", new List<Condition> { yesCondition });
            Connection noConnection = new Connection("N 6", new List<Condition> { noCondition });

            /// Add other connection types
            Connection submitValidationConnection = new Connection("", ConnectionType.VALIDATES);
            Connection cancelValidationConnection = new Connection("", ConnectionType.VALIDATES);
            Connection yesValidationConnection = new Connection("", ConnectionType.VALIDATES);
            Connection noValidationConnection = new Connection("", ConnectionType.VALIDATES);

            /// Regular connections
            htmlGraph.AddConnection(start, inputTempSensorNode, startToInput);
            htmlGraph.AddConnection(inputTempSensorNode, submitDecisionNode, inputToDecisionNode);

            /// Connections from Decision Nodes
            htmlGraph.AddConnection(submitDecisionNode, viewRelatedDataDecisionNode, submitConnection);
            htmlGraph.AddConnection(submitDecisionNode, inputTempSensorNode, cancelConnection);

            htmlGraph.AddConnection(viewRelatedDataDecisionNode, end, yesConnection);
            htmlGraph.AddConnection(viewRelatedDataDecisionNode, inputTempSensorNode, noConnection);

            /// Validation Connections
            htmlGraph.AddConnection(submitDecisionNode, submitDecisionNode, submitValidationConnection);
            htmlGraph.AddConnection(submitDecisionNode, submitDecisionNode, cancelValidationConnection);
            htmlGraph.AddConnection(viewRelatedDataDecisionNode, viewRelatedDataDecisionNode, yesValidationConnection);
            htmlGraph.AddConnection(viewRelatedDataDecisionNode, viewRelatedDataDecisionNode, noValidationConnection);


            #endregion

            graph = htmlGraph;
        }

        [TestMethod()]
        //[Ignore] // Ignored because it writes to the database
        public void WriteTestFlowchartToFile()
        {
            DatabaseConnector connector = new KeyVaultManager().ConnectToDatabase();

            bool res = false;
            try
            {
                res = connector.WriteHtmlGraphAsync(graph).Result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Assert.Fail();
            }

            Assert.IsTrue(res, "Failed to write Instruction Set to database");
        }
    }
}
