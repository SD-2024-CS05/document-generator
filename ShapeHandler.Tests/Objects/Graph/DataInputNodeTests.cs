using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapeHandler.Objects;
using System;
using System.Collections.Generic;

namespace ShapeHandler.Tests.Objects.Graph
{
    [TestClass]
    public class DataInputNodeTests
    {
        [TestMethod]
        public void Constructor_WithLabel_ShouldInitializeProperties()
        {
            // Arrange
            string label = "TestLabel";

            // Act
            var node = new DataInputNode(label);

            // Assert
            Assert.AreEqual(label, node.Label);
            Assert.AreEqual(NodeType.DataInput, node.Type);
            Assert.IsNotNull(node.DataInputNodes);
            Assert.AreEqual(0, node.DataInputNodes.Count);
        }

        [TestMethod]
        public void Constructor_WithLabelAndDataInputNodes_ShouldInitializeProperties()
        {
            // Arrange
            string label = "TestLabel";
            var dataInputNodes = new List<HtmlNode> { new HtmlNode("html1"), new HtmlNode("html2") };

            // Act
            var node = new DataInputNode(label, dataInputNodes);

            // Assert
            Assert.AreEqual(label, node.Label);
            Assert.AreEqual(NodeType.DataInput, node.Type);
            Assert.AreEqual(dataInputNodes, node.DataInputNodes);
        }

        [TestMethod]
        public void Constructor_WithGuidLabelAndDataInputNodes_ShouldInitializeProperties()
        {
            // Arrange
            Guid guid = Guid.NewGuid();
            string label = "TestLabel";
            var dataInputNodes = new List<HtmlNode> { new HtmlNode("html1"), new HtmlNode("html2") };

            // Act
            var node = new DataInputNode(guid, label, dataInputNodes);

            // Assert
            Assert.AreEqual(guid.ToString(), node.Id);
            Assert.AreEqual(label, node.Label);
            Assert.AreEqual(NodeType.DataInput, node.Type);
            Assert.AreEqual(dataInputNodes, node.DataInputNodes);
        }

        [TestMethod]
        public void Constructor_WithDataInputNodes_ShouldInitializeProperties()
        {
            // Arrange
            var dataInputNodes = new List<HtmlNode> { new HtmlNode("html1"), new HtmlNode("html2") };

            // Act
            var node = new DataInputNode(dataInputNodes);

            // Assert
            Assert.AreEqual(NodeType.DataInput, node.Type);
            Assert.AreEqual(dataInputNodes, node.DataInputNodes);
        }

        [TestMethod]
        public void Equals_WithSameId_ShouldReturnTrue()
        {
            // Arrange
            var guid = Guid.NewGuid();
            var node1 = new DataInputNode(guid, "Label1", new List<HtmlNode>());
            var node2 = new DataInputNode(guid, "Label2", new List<HtmlNode>());

            // Act
            var result = node1.Equals(node2);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Equals_WithDifferentId_ShouldReturnFalse()
        {
            // Arrange
            var node1 = new DataInputNode(Guid.NewGuid(), "Label1", new List<HtmlNode>());
            var node2 = new DataInputNode(Guid.NewGuid(), "Label2", new List<HtmlNode>());

            // Act
            var result = node1.Equals(node2);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ToString_ShouldReturnCorrectFormat()
        {
            // Arrange
            var guid = Guid.NewGuid();
            var dataInputNodes = new List<HtmlNode> { new HtmlNode("html1"), new HtmlNode("html2") };
            var node = new DataInputNode(guid, "TestLabel", dataInputNodes);
            string expected = $"{{id: \"{guid}\", type: \"DATAINPUT\", label: \"TestLabel\", dataInputNodes: [{dataInputNodes[0]}, {dataInputNodes[1]}, ]}}";

            // Act
            var result = node.ToString();

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
