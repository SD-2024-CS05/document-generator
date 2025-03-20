using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapeHandler.Objects;
using System;

namespace ShapeHandler.Tests.Objects.Graph
{
    [TestClass]
    public class PageNodeTests
    {
        [TestMethod]
        public void Constructor_WithLabel_ShouldSetProperties()
        {
            // Arrange
            var label = "TestLabel";

            // Act
            var pageNode = new PageNode(label);

            // Assert
            Assert.AreEqual(label, pageNode.Label);
            Assert.AreEqual(NodeType.Page, pageNode.Type);
        }

        [TestMethod]
        public void Constructor_WithGuidAndLabel_ShouldSetProperties()
        {
            // Arrange
            var guid = Guid.NewGuid();
            var label = "TestLabel";

            // Act
            var pageNode = new PageNode(guid, label);

            // Assert
            Assert.AreEqual(guid, pageNode.Guid);
            Assert.AreEqual(label, pageNode.Label);
            Assert.AreEqual(NodeType.Page, pageNode.Type);
        }
    }
}
