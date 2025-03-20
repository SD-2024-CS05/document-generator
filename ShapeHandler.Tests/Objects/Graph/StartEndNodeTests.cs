using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapeHandler.Objects;
using System;

namespace ShapeHandler.Tests.Objects.Graph
{
    [TestClass]
    public class StartEndNodeTests
    {
        [TestMethod]
        public void DefaultConstructor_ShouldInitializeWithDefaults()
        {
            // Arrange & Act
            var node = new StartEndNode();

            // Assert
            Assert.IsNotNull(node);
            Assert.IsFalse(node.IsStart);
            Assert.AreEqual(NodeType.StartEnd, node.Type);
        }

        [TestMethod]
        public void Constructor_WithLabel_ShouldInitializeWithLabel()
        {
            // Arrange
            var label = "TestLabel";

            // Act
            var node = new StartEndNode(label);

            // Assert
            Assert.IsNotNull(node);
            Assert.AreEqual(label, node.Label);
            Assert.IsFalse(node.IsStart);
            Assert.AreEqual(NodeType.StartEnd, node.Type);
        }

        [TestMethod]
        public void Constructor_WithLabelAndIsStart_ShouldInitializeWithLabelAndIsStart()
        {
            // Arrange
            var label = "TestLabel";
            var isStart = true;

            // Act
            var node = new StartEndNode(label, isStart);

            // Assert
            Assert.IsNotNull(node);
            Assert.AreEqual(label, node.Label);
            Assert.AreEqual(isStart, node.IsStart);
            Assert.AreEqual(NodeType.StartEnd, node.Type);
        }

        [TestMethod]
        public void Constructor_WithGuidLabelAndIsStart_ShouldInitializeWithGuidLabelAndIsStart()
        {
            // Arrange
            var guid = Guid.NewGuid();
            var label = "TestLabel";
            var isStart = true;

            // Act
            var node = new StartEndNode(guid, label, isStart);

            // Assert
            Assert.IsNotNull(node);
            Assert.AreEqual(guid, node.Id);
            Assert.AreEqual(label, node.Label);
            Assert.AreEqual(isStart, node.IsStart);
            Assert.AreEqual(NodeType.StartEnd, node.Type);
        }
    }
}
