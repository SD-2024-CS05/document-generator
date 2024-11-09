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

            var inputTempSensorNode = new HtmlNode(inputTempSensor.Id, inputTempSensor, NodeType.Input);

            /// Checkbox Node
            var setFastCoolingMode = document.CreateElement("input") as IHtmlInputElement;
            setFastCoolingMode.Type = "checkbox";
            setFastCoolingMode.Id = "inputCoolingMode";
            setFastCoolingMode.ClassList.Add("form-check-input");
            setFastCoolingMode.IsChecked = true;

            var setFastCoolingModeNode = new HtmlNode(setFastCoolingMode.Id, setFastCoolingMode, NodeType.Input);

            /// Input Form Node
            var inputWaitTime = document.CreateElement("input") as IHtmlInputElement;
            inputWaitTime.Type = "number";
            inputWaitTime.Id = "inputWaitTime";
            inputWaitTime.Value = 3.ToString();

            var inputWaitTimeNode = new HtmlNode(inputWaitTime.Id, inputWaitTime, NodeType.Input);

            /// Decision Node
            /// Submit Button

            var submitButton = document.CreateElement("button") as IHtmlButtonElement;
            submitButton.Id = "submitButton";
            submitButton.Type = "submit";

            var submitButtonNode = new HtmlNode(submitButton.Id, submitButton, NodeType.Button);

            /// Cancel Button
            var cancelButton = document.CreateElement("a") as IHtmlAnchorElement;
            cancelButton.Id = "cancelButton";
            cancelButton.Href = "/fast-cooling/input";

            var cancelButtonNode = new HtmlNode(cancelButton.Id, cancelButton, NodeType.Anchor);

            // Make Wrapper for Form 1
            var TemperatureFormNode = new DataInputWrapperNode("Input Data");
            TemperatureFormNode.DataInputNodes.Add(inputTempSensorNode);
            TemperatureFormNode.DataInputNodes.Add(setFastCoolingModeNode);
            TemperatureFormNode.DataInputNodes.Add(inputWaitTimeNode);
            TemperatureFormNode.DataInputNodes.Add(submitButtonNode);
            TemperatureFormNode.DataInputNodes.Add(cancelButtonNode);

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

            DecisionNode submitDecisionNode = new DecisionNode("Submit Results?",
                new List<string> { TemperatureFormNode.Id });

            /// Process nodes (wip)
            ProcessNode processDataNode = new ProcessNode("Process Data", false);
            ProcessNode displayResults = new ProcessNode("Display Results", true);

            /// View Related Data Decision Node
            var yesButton = document.CreateElement("button") as IHtmlButtonElement;
            yesButton.Id = "viewRelatedDataButton";
            yesButton.Type = "submit";

            var yesButtonNode = new HtmlNode(yesButton.Id, yesButton, NodeType.Button);

            var noButton = document.CreateElement("button") as IHtmlButtonElement;
            noButton.Type = "submit";

            var noButtonNode = new HtmlNode(noButton.Id, noButton, NodeType.Button);

            var backToInputForm = document.CreateElement("a") as IHtmlAnchorElement;
            backToInputForm.Href = "/fast-cooling/input";
            backToInputForm.ClassList.Add(new string[] { "btn", "btn-primary" });

            var backToInputFormNode = new HtmlNode(backToInputForm.Id, backToInputForm, NodeType.Anchor);

            // make data input wrapper node
            var viewRelatedDataFormNode = new DataInputWrapperNode("View Related Data");
            viewRelatedDataFormNode.DataInputNodes.Add(yesButtonNode);
            viewRelatedDataFormNode.DataInputNodes.Add(noButtonNode);
            viewRelatedDataFormNode.DataInputNodes.Add(backToInputFormNode);

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

            DecisionNode viewRelatedDataDecisionNode = new DecisionNode("View Related Data?", new List<string> { viewRelatedDataFormNode.Id });


            // Other functions
            DecisionNode otherFunctionsDecisionNode = new DecisionNode("Other Functions?");

            PageNode pageANode = new PageNode("A");

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
            htmlGraph.AddNode(processDataNode);
            htmlGraph.AddNode(displayResults);
            htmlGraph.AddNode(TemperatureFormNode);
            htmlGraph.AddNode(viewRelatedDataFormNode);
            htmlGraph.AddNode(otherFunctionsDecisionNode);
            htmlGraph.AddNode(pageANode);
            htmlGraph.AddNode(end);

            /// Create Connections
            // Start -> Input Data Form -> Submit Decision -> Process Data
            Connection startToInputDataForm = new Connection("1");
            Connection inputDataFormToSubmitDecision = new Connection("", ConnectionType.VALIDATES);
            Connection inputDataFormToSubmitDecisionGoing = new Connection("2");
            Connection submitDecisionNo = new Connection("N 3", new List<Condition> { cancelCondition });
            Connection submitDecisionYesToProcessData = new Connection("Y 4", new List<Condition> { submitCondition });

            // Process Data -> Display Results -> View Related Data
            Connection processDataToDisplayResults = new Connection("5");
            Connection displayResultsToViewRelatedData = new Connection("6");
            Connection inputDataFormToViewDataDecision = new Connection("", ConnectionType.VALIDATES);

            // View Related Data -> Input Data Form -> Other Functions? -> End
            Connection viewRelatedDataYes = new Connection("Y 7", new List<Condition> { yesCondition });
            Connection viewRelatedDataNoToOtherFunction = new Connection("N 8", new List<Condition> { noCondition });
            Connection otherFunctionYesToPage = new Connection("Y 9");
            Connection otherFunctionNoToBeginning = new Connection("N 10");

            // Add input element connections for data forms
            // Temperature Form
            foreach (var inputNode in TemperatureFormNode.DataInputNodes)
            {
                htmlGraph.AddConnection(inputNode, TemperatureFormNode, new Connection(inputNode.Element.Id ?? inputNode.Id, ConnectionType.INPUT_FOR));
            }

            // View Related Data Form
            foreach (var inputNode in viewRelatedDataFormNode.DataInputNodes)
            {
                htmlGraph.AddConnection(inputNode, viewRelatedDataFormNode, new Connection(inputNode.Element.Id ?? inputNode.Id, ConnectionType.INPUT_FOR));
            }


            /// Add connections
            htmlGraph.AddConnection(start, TemperatureFormNode, startToInputDataForm);
            htmlGraph.AddConnection(TemperatureFormNode, submitDecisionNode, inputDataFormToSubmitDecision);
            htmlGraph.AddConnection(TemperatureFormNode, submitDecisionNode, inputDataFormToSubmitDecisionGoing);
            htmlGraph.AddConnection(submitDecisionNode, processDataNode, submitDecisionYesToProcessData);
            htmlGraph.AddConnection(submitDecisionNode, TemperatureFormNode, submitDecisionNo);
            htmlGraph.AddConnection(processDataNode, displayResults, processDataToDisplayResults);

            htmlGraph.AddConnection(displayResults, viewRelatedDataDecisionNode, displayResultsToViewRelatedData);
            htmlGraph.AddConnection(viewRelatedDataFormNode, viewRelatedDataDecisionNode, inputDataFormToViewDataDecision);
            htmlGraph.AddConnection(viewRelatedDataDecisionNode, end, viewRelatedDataYes);
            htmlGraph.AddConnection(viewRelatedDataDecisionNode, otherFunctionsDecisionNode, viewRelatedDataNoToOtherFunction);
            htmlGraph.AddConnection(otherFunctionsDecisionNode, pageANode, otherFunctionYesToPage);
            htmlGraph.AddConnection(otherFunctionsDecisionNode, start, otherFunctionNoToBeginning);

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
