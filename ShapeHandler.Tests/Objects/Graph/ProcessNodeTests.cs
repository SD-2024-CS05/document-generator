using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapeHandler.Objects;
using System;

namespace ShapeHandler.Tests.Objects.Graph
{
    [TestClass]
    public class ProcessNodeTests
    {
        [TestMethod]
        public void Constructor_WithLabel_CreatesUserProcessNode()
        {
            // Arrange
            string label = "Test Node";

            // Act
            ProcessNode node = new ProcessNode(label);

            // Assert
            Assert.AreEqual(label, node.Label);
            Assert.AreEqual(NodeType.UserProcess, node.Type);
        }

        [TestMethod]
        public void Constructor_WithLabelAndIsBackgroundTrue_CreatesBackgroundProcessNode()
        {
            // Arrange
            string label = "Test Node";

            // Act
            ProcessNode node = new ProcessNode(label, true);

            // Assert
            Assert.AreEqual(label, node.Label);
            Assert.AreEqual(NodeType.BackgroundProcess, node.Type);
        }

        [TestMethod]
        public void Constructor_WithGuidAndLabel_CreatesUserProcessNode()
        {
            // Arrange
            Guid guid = Guid.NewGuid();
            string label = "Test Node";

            // Act
            ProcessNode node = new ProcessNode(guid, label);

            // Assert
            Assert.AreEqual(guid, node.Id);
            Assert.AreEqual(label, node.Label);
            Assert.AreEqual(NodeType.UserProcess, node.Type);
        }

        [TestMethod]
        public void Constructor_WithGuidLabelAndIsBackgroundTrue_CreatesBackgroundProcessNode()
        {
            // Arrange
            Guid guid = Guid.NewGuid();
            string label = "Test Node";

            // Act
            ProcessNode node = new ProcessNode(guid, label, true);

            // Assert
            Assert.AreEqual(guid, node.Id);
            Assert.AreEqual(label, node.Label);
            Assert.AreEqual(NodeType.BackgroundProcess, node.Type);
        }
    }
}
