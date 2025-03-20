using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapeHandler.Objects;
using System;

namespace ShapeHandler.Tests.Objects.Graph
{
    [TestClass]
    public class FlowchartNodeTests
    {
        private class TestFlowchartNode : FlowchartNode
        {
            public TestFlowchartNode(string label, NodeType type) : base(label, type) { }
            public TestFlowchartNode(Guid id, string label, NodeType type) : base(id, label, type) { }
        }

        [TestMethod]
        public void Constructor_ShouldGenerateId_WhenLabelIsNull()
        {
            // Arrange
            var type = NodeType.UserProcess;

            // Act
            var node = new TestFlowchartNode(null, type);

            // Assert
            Assert.IsNotNull(node.Id);
            Assert.AreEqual(node.Label, node.Id);
            Assert.AreEqual(node.Type, type);
        }

        [TestMethod]
        public void Constructor_ShouldGenerateId_WhenLabelIsEmpty()
        {
            // Arrange
            var type = NodeType.UserProcess;

            // Act
            var node = new TestFlowchartNode("", type);

            // Assert
            Assert.IsNotNull(node.Id);
            Assert.AreEqual(node.Label, node.Id);
            Assert.AreEqual(node.Type, type);
        }

        [TestMethod]
        public void Constructor_ShouldSetLabel_WhenLabelIsProvided()
        {
            // Arrange
            var label = "Test Node";
            var type = NodeType.UserProcess;

            // Act
            var node = new TestFlowchartNode(label, type);

            // Assert
            Assert.IsNotNull(node.Id);
            Assert.AreEqual(node.Label, label);
            Assert.AreEqual(node.Type, type);
        }

        [TestMethod]
        public void Constructor_ShouldGenerateId_WhenIdIsEmpty()
        {
            // Arrange
            var label = "Test Node";
            var type = NodeType.UserProcess;

            // Act
            var node = new TestFlowchartNode(Guid.Empty, label, type);

            // Assert
            Assert.IsNotNull(node.Id);
            Assert.AreEqual(node.Label, label);
            Assert.AreEqual(node.Type, type);
        }

        [TestMethod]
        public void Constructor_ShouldSetId_WhenIdIsProvided()
        {
            // Arrange
            var id = Guid.NewGuid();
            var label = "Test Node";
            var type = NodeType.UserProcess;

            // Act
            var node = new TestFlowchartNode(id, label, type);

            // Assert
            Assert.AreEqual(node.Id, id.ToString());
            Assert.AreEqual(node.Label, label);
            Assert.AreEqual(node.Type, type);
        }

        [TestMethod]
        public void ToString_ShouldReturnCorrectFormat()
        {
            // Arrange
            var label = "Test Node";
            var type = NodeType.UserProcess;
            var node = new TestFlowchartNode(label, type);

            // Act
            var result = node.ToString();

            // Assert
            Assert.AreEqual(result, "{id: \"" + node.Id + "\", type: \"" + type.ToString().ToUpper() + "\"}");
        }

        [TestMethod]
        public void Equals_ShouldReturnTrue_WhenIdsAreEqual()
        {
            // Arrange
            var id = Guid.NewGuid();
            var node1 = new TestFlowchartNode(id, "Node 1", NodeType.UserProcess);
            var node2 = new TestFlowchartNode(id, "Node 2", NodeType.Decision);

            // Act
            var result = node1.Equals(node2);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Equals_ShouldReturnFalse_WhenIdsAreNotEqual()
        {
            // Arrange
            var node1 = new TestFlowchartNode("Node 1", NodeType.UserProcess);
            var node2 = new TestFlowchartNode("Node 2", NodeType.Decision);

            // Act
            var result = node1.Equals(node2);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
