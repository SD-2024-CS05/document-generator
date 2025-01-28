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

        public void Setup1()
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
            var TemperatureFormNode = new DataInputNode("Input Data");
            TemperatureFormNode.DataInputNodes.Add(inputTempSensorNode);
            TemperatureFormNode.DataInputNodes.Add(setFastCoolingModeNode);
            TemperatureFormNode.DataInputNodes.Add(inputWaitTimeNode);
            TemperatureFormNode.DataInputNodes.Add(submitButtonNode);
            TemperatureFormNode.DataInputNodes.Add(cancelButtonNode);

            DecisionNode submitDecisionNode = new DecisionNode("Submit Results?");

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
            var viewRelatedDataFormNode = new DataInputNode("View Related Data");
            viewRelatedDataFormNode.DataInputNodes.Add(yesButtonNode);
            viewRelatedDataFormNode.DataInputNodes.Add(noButtonNode);
            viewRelatedDataFormNode.DataInputNodes.Add(backToInputFormNode);

            DecisionNode viewRelatedDataDecisionNode = new DecisionNode("View Related Data?");

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
            htmlGraph.AddNode(backToInputFormNode);
            htmlGraph.AddNode(submitDecisionNode);
            htmlGraph.AddNode(processDataNode);
            htmlGraph.AddNode(displayResults);
            htmlGraph.AddNode(TemperatureFormNode);
            htmlGraph.AddNode(viewRelatedDataFormNode);
            htmlGraph.AddNode(otherFunctionsDecisionNode);
            htmlGraph.AddNode(pageANode);
            htmlGraph.AddNode(end);

            // Create Conditions
            Conditions submitCondition = new Conditions
            {
                NodeIds = new List<string> { inputTempSensorNode.Id, inputWaitTimeNode.Id },
                Operator = LogicalOperator.AND
            };

            /// Create Connections
            // Start -> Input Data Form -> Submit Decision -> Process Data
            Connection startToInputDataForm = new Connection("1");
            Connection inputDataFormToSubmitDecision = new Connection("", ConnectionType.VALIDATES);
            Connection inputDataFormToSubmitDecisionGoing = new Connection("2");
            Connection submitDecisionNo = new Connection("N 3", cancelButtonNode.Id);
            Connection submitDecisionYesToProcessData = new Connection("Y 4", submitCondition, submitButtonNode.Id);

            // Process Data -> Display Results -> View Related Data
            Connection processDataToDisplayResults = new Connection("5");
            Connection displayResultsToViewRelatedData = new Connection("6");
            Connection inputDataFormToViewDataDecision = new Connection("", ConnectionType.VALIDATES);
            Connection inputDataFormToOtherFunctions = new Connection("", ConnectionType.VALIDATES);

            // View Related Data -> Input Data Form -> Other Functions? -> End
            Connection viewRelatedDataYes = new Connection("Y 7", yesButtonNode.Id);
            Connection viewRelatedDataNoToOtherFunction = new Connection("N 8", noButtonNode.Id);
            Connection otherFunctionYesToPage = new Connection("Y 9");
            Connection otherFunctionNoToBeginning = new Connection("N 10", backToInputFormNode.Id);

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
            // Start -> Input Data Form -> Submit Decision -> Process Data
            htmlGraph.AddConnection(start, TemperatureFormNode, startToInputDataForm);
            htmlGraph.AddConnection(TemperatureFormNode, submitDecisionNode, inputDataFormToSubmitDecision);
            htmlGraph.AddConnection(TemperatureFormNode, submitDecisionNode, inputDataFormToSubmitDecisionGoing);

            // Submit Decision -> Process Data
            htmlGraph.AddConnection(submitDecisionNode, processDataNode, submitDecisionYesToProcessData);
            htmlGraph.AddConnection(submitDecisionNode, TemperatureFormNode, submitDecisionNo);

            // Process Data -> Display Results -> View Related Data
            htmlGraph.AddConnection(processDataNode, displayResults, processDataToDisplayResults);
            htmlGraph.AddConnection(displayResults, viewRelatedDataDecisionNode, displayResultsToViewRelatedData);
            htmlGraph.AddConnection(viewRelatedDataFormNode, viewRelatedDataDecisionNode, inputDataFormToViewDataDecision);
            htmlGraph.AddConnection(viewRelatedDataDecisionNode, end, viewRelatedDataYes);
            htmlGraph.AddConnection(viewRelatedDataDecisionNode, otherFunctionsDecisionNode, viewRelatedDataNoToOtherFunction);

            // Other Functions
            htmlGraph.AddConnection(viewRelatedDataFormNode, otherFunctionsDecisionNode, inputDataFormToOtherFunctions);
            htmlGraph.AddConnection(otherFunctionsDecisionNode, pageANode, otherFunctionYesToPage);
            htmlGraph.AddConnection(otherFunctionsDecisionNode, start, otherFunctionNoToBeginning);

            #endregion

            graph = htmlGraph;
        }

        public void SetupTest2()
        {
            var htmlGraph = new HtmlGraph();
            var context = BrowsingContext.New(Configuration.Default);
            var document = context.OpenNewAsync().Result;

            /// Start Node
            var start = new StartEndNode("start");
            start.IsStart = true;

            // add to basket decision
            var addToBasket = document.CreateElement("input") as IHtmlInputElement;
            addToBasket.Type = "submit";
            addToBasket.Value = "[ ADD TO BASKET ]";
            addToBasket.ClassList.Add("esh-catalog-thumbnail");
            var addToBasketInput = new HtmlNode(addToBasket.Id, addToBasket, NodeType.Input);

            var addToBasketDecision = new DecisionNode("Click Add to Basket");

            // Make Data Input wrapper
            var addToBasketDataInput = new DataInputNode(new List<HtmlNode> { addToBasketInput });

            /// Input Quantity Box
            // input
            var inputQuantity = document.CreateElement("input") as IHtmlInputElement;
            inputQuantity.Type = "number";
            inputQuantity.Value = "1";
            inputQuantity.ClassList.Add("esh-basket-input");
            inputQuantity.Minimum = "0";
            inputQuantity.Name = "Items[0].Quantity";

            var inputQuantityNode = new HtmlNode(inputQuantity.Id, inputQuantity, NodeType.Input);

            // anchor button
            var continueShopping = document.CreateElement("a") as IHtmlAnchorElement;
            continueShopping.ClassList.Add("btn", "esh-basket-checkout", "text-white");
            continueShopping.Href = "/";
            continueShopping.TextContent = "[ Continue Shopping ]";

            var continueShoppingNode = new HtmlNode(continueShopping.Id, continueShopping, NodeType.Anchor);

            // continue shopping decision
            var continueShoppingDecision = new DecisionNode("Continue Shopping?");

            // update button
            var updateBasket = document.CreateElement("button") as IHtmlButtonElement;
            updateBasket.ClassList.Add("btn", "esh-basket-checkout");
            updateBasket.Name = "updatebutton";
            updateBasket.Type = "submit";
            updateBasket.FormAction = "/Basket/Update";
            updateBasket.TextContent = "[ Update Basket ]";

            var updateBasketNode = new HtmlNode(updateBasket.Id, updateBasket, NodeType.Button);

            var updateDecision = new DecisionNode("Update?");

            // foreground process
            var updateCartProcess = new ProcessNode("Update Cart");

            //checkout button
            var checkout = document.CreateElement("a") as IHtmlAnchorElement;
            checkout.ClassList.Add("btn", "esh-basket-checkout");
            checkout.Href = "/Basket/Checkout";
            checkout.TextContent = "[ Checkout ]";

            var checkoutNode = new HtmlNode(checkout.Id, checkout, NodeType.Anchor);

            // checkout decision
            var checkoutDecision = new DecisionNode("Checkout?");

            // data input node
            var dataInputFinalPage = new DataInputNode("Input Quantity", new List<HtmlNode> { continueShoppingNode, updateBasketNode, checkoutNode, inputQuantityNode });

            // final node
            var end = new StartEndNode("end");

            htmlGraph.AddNode(start);
            htmlGraph.AddNode(addToBasketDecision);
            htmlGraph.AddNode(addToBasketInput);
            htmlGraph.AddNode(addToBasketDataInput);
            htmlGraph.AddNode(inputQuantityNode);
            htmlGraph.AddNode(continueShoppingNode);
            htmlGraph.AddNode(continueShoppingDecision);
            htmlGraph.AddNode(updateBasketNode);
            htmlGraph.AddNode(updateDecision);
            htmlGraph.AddNode(updateCartProcess);
            htmlGraph.AddNode(dataInputFinalPage);
            htmlGraph.AddNode(checkoutNode);
            htmlGraph.AddNode(checkoutDecision);
            htmlGraph.AddNode(end);

            /// make connections
            var connection1 = new Connection("1");
            htmlGraph.AddConnection(start, addToBasketDecision, connection1);

            var connectionN2 = new Connection("N 2");
            htmlGraph.AddConnection(addToBasketDecision, start, connectionN2);

            // dependency connections
            htmlGraph.AddConnection(addToBasketInput, addToBasketDataInput, new Connection(ConnectionType.INPUT_FOR));
            htmlGraph.AddConnection(addToBasketDataInput, addToBasketDecision, new Connection(ConnectionType.VALIDATES));

            var connectionY3 = new Connection("Y 3", addToBasketInput.Id);
            htmlGraph.AddConnection(addToBasketDecision, dataInputFinalPage, connectionY3);

            // dependency connections
            htmlGraph.AddConnection(inputQuantityNode, dataInputFinalPage, new Connection(ConnectionType.INPUT_FOR));
            htmlGraph.AddConnection(continueShoppingNode, dataInputFinalPage, new Connection(ConnectionType.INPUT_FOR));
            htmlGraph.AddConnection(updateBasketNode, dataInputFinalPage, new Connection(ConnectionType.INPUT_FOR));
            htmlGraph.AddConnection(checkoutNode, dataInputFinalPage, new Connection(ConnectionType.INPUT_FOR));
            htmlGraph.AddConnection(dataInputFinalPage, continueShoppingDecision, new Connection(ConnectionType.VALIDATES));
            htmlGraph.AddConnection(dataInputFinalPage, updateDecision, new Connection(ConnectionType.VALIDATES));
            htmlGraph.AddConnection(dataInputFinalPage, checkoutDecision, new Connection(ConnectionType.VALIDATES));

            var connection4 = new Connection("4");
            htmlGraph.AddConnection(dataInputFinalPage, continueShoppingDecision, connection4);

            var connectionY5 = new Connection("Y 5", continueShoppingNode.Id);
            htmlGraph.AddConnection(continueShoppingDecision, start, connectionY5);

            var connectionN6 = new Connection("N 6");
            htmlGraph.AddConnection(continueShoppingDecision, updateDecision, connectionN6);

            var connectionY7 = new Connection("Y 7", updateBasketNode.Id);
            htmlGraph.AddConnection(updateDecision, updateCartProcess, connectionY7);

            var connection8 = new Connection("8");
            htmlGraph.AddConnection(updateCartProcess, continueShoppingDecision, connection8);

            var connectionN9 = new Connection("N 9");
            htmlGraph.AddConnection(updateDecision, checkoutDecision, connectionN9);

            var connectionY10 = new Connection("Y 10", checkoutNode.Id);
            htmlGraph.AddConnection(checkoutDecision, end, connectionY10);

            var connectionN11 = new Connection("N 11");
            htmlGraph.AddConnection(checkoutDecision, continueShoppingDecision, connectionN11);


            graph = htmlGraph;
        }

        [TestMethod()]
        [Ignore] // Ignored because it writes to the database
        public void WriteTestFlowchartToFile1()
        {
            DatabaseConnector connector = new KeyVaultManager().ConnectToDatabase();

            bool res = false;
            try
            {
                Setup1();
                res = connector.WriteHtmlGraphAsync(graph).Result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Assert.Fail();
            }

            Assert.IsTrue(res, "Failed to write Instruction Set to database");
        }

        [TestMethod()]
        [Ignore] // Ignored because it writes to the database   
        public void WriteTestFlowchartToFile2()
        {
            DatabaseConnector connector = new KeyVaultManager().ConnectToDatabase();

            bool res = false;
            try
            {
                SetupTest2();
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
