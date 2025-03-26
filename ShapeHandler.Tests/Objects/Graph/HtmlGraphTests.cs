using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapeHandler.Objects;
using System;
using System.Collections.Generic;

namespace ShapeHandler.Tests.Objects.Graph
{
    [TestClass]
    public class HtmlGraphTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNode_ShouldThrowArgumentNullException_WhenNodeIsNull()
        {
            var graph = new HtmlGraph();
            graph.AddNode(null);
        }

        [TestMethod]
        public void AddNode_ShouldAddNode_WhenNodeIsValid()
        {
            var graph = new HtmlGraph();
            var node = new StartEndNode();
            graph.AddNode(node);

            var nodes = graph.GetNodes();
            Assert.IsTrue(nodes.Contains(node));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void AddNode_ShouldThrowException_WhenAddingMultipleStartNodes()
        {
            var graph = new HtmlGraph();
            var startNode1 = new StartEndNode { IsStart = true };
            var startNode2 = new StartEndNode { IsStart = true };

            graph.AddNode(startNode1);
            graph.AddNode(startNode2);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void AddNode_ShouldThrowException_WhenAddingMultipleEndNodes()
        {
            var graph = new HtmlGraph();
            var endNode1 = new StartEndNode { IsStart = false };
            var endNode2 = new StartEndNode { IsStart = false };

            graph.AddNode(endNode1);
            graph.AddNode(endNode2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddConnection_ShouldThrowArgumentNullException_WhenSourceIsNull()
        {
            var graph = new HtmlGraph();
            var target = new StartEndNode();
            var connection = new Connection();

            graph.AddConnection(null, target, connection);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddConnection_ShouldThrowArgumentNullException_WhenTargetIsNull()
        {
            var graph = new HtmlGraph();
            var source = new StartEndNode();
            var connection = new Connection();

            graph.AddConnection(source, null, connection);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void AddConnection_ShouldThrowException_WhenSourceNodeNotFound()
        {
            var graph = new HtmlGraph();
            var source = new StartEndNode();
            var target = new StartEndNode();
            var connection = new Connection();

            graph.AddConnection(source, target, connection);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void AddConnection_ShouldThrowException_WhenTargetNodeNotFound()
        {
            var graph = new HtmlGraph();
            var source = new StartEndNode();
            var target = new StartEndNode();
            var connection = new Connection();

            graph.AddNode(source);
            graph.AddConnection(source, target, connection);
        }

        [TestMethod]
        public void AddConnection_ShouldAddConnection_WhenNodesAreValid()
        {
            var graph = new HtmlGraph();
            var source = new StartEndNode() { IsStart = true };
            var target = new StartEndNode() { IsStart = false };
            var connection = new Connection();

            graph.AddNode(source);
            graph.AddNode(target);
            graph.AddConnection(source, target, connection);

            var connections = graph.GetConnections(source, target);
            Assert.IsTrue(connections.Contains(connection));
        }

        [TestMethod]
        public void GetNodes_ShouldReturnAllUniqueNodes()
        {
            var graph = new HtmlGraph();
            var node1 = new StartEndNode() { IsStart = true };
            var node2 = new StartEndNode() { IsStart = false };

            graph.AddNode(node1);
            graph.AddNode(node2);

            var nodes = graph.GetNodes();
            Assert.AreEqual(2, nodes.Count);
            Assert.IsTrue(nodes.Contains(node1));
            Assert.IsTrue(nodes.Contains(node2));
        }

        [TestMethod]
        public void Count_ShouldReturnNumberOfNodes()
        {
            var graph = new HtmlGraph();
            var node1 = new StartEndNode() { IsStart = true };
            var node2 = new StartEndNode() { IsStart = false };

            graph.AddNode(node1);
            graph.AddNode(node2);

            var count = graph.Count();
            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void GetConnectedNodesFrom_ShouldReturnConnectedNodes()
        {
            var graph = new HtmlGraph();
            var source = new StartEndNode() { IsStart = true };
            var target = new StartEndNode() { IsStart = false };
            var connection = new Connection();

            graph.AddNode(source);
            graph.AddNode(target);
            graph.AddConnection(source, target, connection);

            var connectedNodes = graph.GetConnectedNodesFrom(source);
            Assert.IsTrue(connectedNodes.ContainsKey(target));
            Assert.IsTrue(connectedNodes[target].Contains(connection));
        }

        [TestMethod]
        public void GetConnectedNodesTo_ShouldReturnConnectedNodes()
        {
            var graph = new HtmlGraph();
            var source = new StartEndNode() { IsStart = true };
            var target = new StartEndNode() { IsStart = false };
            var connection = new Connection();

            graph.AddNode(source);
            graph.AddNode(target);
            graph.AddConnection(source, target, connection);

            var connectedNodes = graph.GetConnectedNodesTo(target);
            Assert.IsTrue(connectedNodes.ContainsKey(source));
            Assert.IsTrue(connectedNodes[source].Contains(connection));
        }

        [TestMethod]
        public void GetConnections_ShouldReturnConnections()
        {
            var graph = new HtmlGraph();
            var source = new StartEndNode() { IsStart = true };
            var target = new StartEndNode() { IsStart = false };
            var connection = new Connection();

            graph.AddNode(source);
            graph.AddNode(target);
            graph.AddConnection(source, target, connection);

            var connections = graph.GetConnections(source, target);
            Assert.IsTrue(connections.Contains(connection));
        }

        [TestMethod]
        public void GetConditions_ShouldReturnConditions()
        {
            var graph = new HtmlGraph();
            var source = new StartEndNode() { IsStart = true };
            var target = new StartEndNode() { IsStart = false };
            var connection = new Connection { Conditions = new Conditions() };

            graph.AddNode(source);
            graph.AddNode(target);
            graph.AddConnection(source, target, connection);

            var conditions = graph.GetConditions(source, target);
            Assert.IsTrue(conditions.Contains(connection.Conditions));
        }

        [TestMethod]
        public void AddNode_ShouldAddDataInputNodeAndConnections_WhenNodeIsValid()
        {
            var graph = new HtmlGraph();
            var dataInputNode = new DataInputNode("DataInput", new List<HtmlNode> { new HtmlNode("HtmlNode1"), new HtmlNode("HtmlNode2") });

            graph.AddNode(dataInputNode);

            var nodes = graph.GetNodes();
            Assert.IsTrue(nodes.Contains(dataInputNode));
            Assert.AreEqual(3, nodes.Count); // DataInputNode + 2 HtmlNodes

            var connectedNodes = graph.GetConnectedNodesFrom(dataInputNode.DataInputNodes[0]);
            Assert.IsTrue(connectedNodes.ContainsKey(dataInputNode));
        }

        [TestMethod]
        public void AddNode_ShouldAddDecisionNodeAndConnections_WhenNodeIsValid()
        {
            var graph = new HtmlGraph();
            var decisionNode = new DecisionNode("Decision", new List<HtmlNode> { new HtmlNode("HtmlNode1"), new HtmlNode("HtmlNode2") });

            graph.AddNode(decisionNode);

            var nodes = graph.GetNodes();
            Assert.IsTrue(nodes.Contains(decisionNode));
            Assert.AreEqual(3, nodes.Count); // DecisionNode + 2 HtmlNodes

            var connectedNodes = graph.GetConnectedNodesFrom(decisionNode.SubmissionNodes[0]);
            Assert.IsTrue(connectedNodes.ContainsKey(decisionNode));
        }


        [TestMethod]
        public void AddConnection_ShouldValidateDecisionNodeConnections()
        {
            var graph = new HtmlGraph();
            var dataInputNode = new DataInputNode("DataInput", new List<HtmlNode> { new HtmlNode("HtmlNode1") });
            var decisionNode = new DecisionNode("Decision", new List<HtmlNode> { new HtmlNode("HtmlNode2") });
            var connection = new Connection { Conditions = new Conditions { NodeIds = new List<string> { "HtmlNode1" } } };

            graph.AddNode(dataInputNode);
            graph.AddNode(decisionNode);
            graph.AddConnection(dataInputNode, decisionNode, connection);

            var connections = graph.GetConnections(dataInputNode, decisionNode);
            Assert.IsTrue(connections.Contains(connection));
        }
    }
}
