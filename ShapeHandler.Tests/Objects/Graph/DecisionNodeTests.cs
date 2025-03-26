using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapeHandler.Objects;
using System;
using System.Collections.Generic;

namespace ShapeHandler.Tests.Objects.Graph
{
    [TestClass]
    public class DecisionNodeTests
    {
        [TestMethod]
        public void Constructor_WithLabel_ShouldInitializeCorrectly()
        {
            // Arrange
            var label = "TestLabel";

            // Act
            var decisionNode = new DecisionNode(label);

            // Assert
            Assert.AreEqual(label, decisionNode.Label);
            Assert.AreEqual(NodeType.Decision, decisionNode.Type);
            Assert.IsNotNull(decisionNode.SubmissionNodes);
            Assert.AreEqual(0, decisionNode.SubmissionNodes.Count);
        }

        [TestMethod]
        public void Constructor_WithLabelAndSubmissionNodes_ShouldInitializeCorrectly()
        {
            // Arrange
            var label = "TestLabel";
            var submissionNodes = new List<HtmlNode> { new HtmlNode("html1"), new HtmlNode("html2") };

            // Act
            var decisionNode = new DecisionNode(label, submissionNodes);

            // Assert
            Assert.AreEqual(label, decisionNode.Label);
            Assert.AreEqual(NodeType.Decision, decisionNode.Type);
            Assert.AreEqual(submissionNodes, decisionNode.SubmissionNodes);
        }

        [TestMethod]
        public void Constructor_WithGuidLabelAndSubmissionNodes_ShouldInitializeCorrectly()
        {
            // Arrange
            var guid = Guid.NewGuid();
            var label = "TestLabel";
            var submissionNodes = new List<HtmlNode> { new HtmlNode("html1"), new HtmlNode("html2") };

            // Act
            var decisionNode = new DecisionNode(guid, label, submissionNodes);

            // Assert
            Assert.AreEqual(guid.ToString(), decisionNode.Id);
            Assert.AreEqual(label, decisionNode.Label);
            Assert.AreEqual(NodeType.Decision, decisionNode.Type);
            Assert.AreEqual(submissionNodes, decisionNode.SubmissionNodes);
        }
    }
}
