using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapeHandler.Objects;
using AngleSharp.Html.Dom;
using Moq;
using System;

namespace ShapeHandler.Tests.Objects.Graph
{
    [TestClass]
    public class HtmlNodeTests
    {
        [TestMethod]
        public void Constructor_WithLabelAndElement_ShouldInitializeProperties()
        {
            // Arrange
            var label = "testLabel";
            var mockElement = new Mock<IHtmlElement>();
            mockElement.Setup(e => e.Id).Returns("testId");

            // Act
            var node = new HtmlNode(label, mockElement.Object);

            // Assert
            Assert.AreEqual(label, node.Label);
            Assert.AreEqual(mockElement.Object, node.Element);
            Assert.AreEqual(NodeType.HtmlElement, node.Type);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_WithNullElement_ShouldThrowArgumentNullException()
        {
            // Arrange
            var label = "testLabel";

            // Act
            var node = new HtmlNode(label, null);

            // Assert is handled by ExpectedException
        }

        [TestMethod]
        public void Equals_WithSameElementId_ShouldReturnTrue()
        {
            // Arrange
            var label = "testLabel";
            var mockElement1 = new Mock<IHtmlElement>();
            mockElement1.Setup(e => e.Id).Returns("testId");
            var node1 = new HtmlNode(label, mockElement1.Object);

            var mockElement2 = new Mock<IHtmlElement>();
            mockElement2.Setup(e => e.Id).Returns("testId");
            var node2 = new HtmlNode(label, mockElement2.Object);

            // Act
            var result = node1.Equals(node2);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Equals_WithDifferentElementId_ShouldReturnFalse()
        {
            // Arrange
            var label = "testLabel";
            var mockElement1 = new Mock<IHtmlElement>();
            mockElement1.Setup(e => e.Id).Returns("testId1");
            var node1 = new HtmlNode(label, mockElement1.Object);

            var mockElement2 = new Mock<IHtmlElement>();
            mockElement2.Setup(e => e.Id).Returns("testId2");
            var node2 = new HtmlNode(label, mockElement2.Object);

            // Act
            var result = node1.Equals(node2);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ToString_ShouldReturnCorrectFormat()
        {
            // Arrange
            var label = "testLabel";
            var mockElement = new Mock<IHtmlElement>();
            mockElement.Setup(e => e.Id).Returns("testId");
            mockElement.Setup(e => e.TagName).Returns("div");

            var mockNamedNodeMap = new Mock<AngleSharp.Dom.INamedNodeMap>();
            mockElement.Setup(e => e.Attributes).Returns(mockNamedNodeMap.Object);

            var node = new HtmlNode(label, mockElement.Object);

            // Act
            var result = node.ToString();

            // Assert
            StringAssert.Contains(result, "id: \"");
            StringAssert.Contains(result, "type: \"HTMLELEMENT\"");
            StringAssert.Contains(result, "label: \"testLabel\"");
            StringAssert.Contains(result, "element: { id: \"testId\"");
            StringAssert.Contains(result, "tag: \"div\"");
        }
    }
}
