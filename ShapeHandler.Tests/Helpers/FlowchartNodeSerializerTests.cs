using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using ShapeHandler.Helpers;
using ShapeHandler.Objects;
using System;
using System.Collections.Generic;
using AngleSharp.Html.Dom;
using Moq;

namespace ShapeHandler.Tests.Helpers
{
    [TestClass]
    public class FlowchartNodeSerializerTests
    {
        [TestMethod]
        public void WriteJson_ShouldSerializeStartEndNode()
        {
            // Arrange
            var node = new StartEndNode(Guid.NewGuid(), "Start Node", true);
            var flowchartNodeSerializer = new FlowchartNodeSerializer();
            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.Converters.Add(flowchartNodeSerializer);

            // Act
            var json = JsonConvert.SerializeObject(node, serializerSettings);

            // Assert
            Assert.IsTrue(json.Contains("\"isStart\":true"));
            Assert.IsTrue(json.Contains("\"Type\":\"StartEnd\""));
        }

        [TestMethod]
        public void WriteJson_ShouldSerializeHtmlNode()
        {
            // Arrange
            var mockElement = new Mock<IHtmlElement>();
            var node = new HtmlNode(Guid.NewGuid(), "Html Node", mockElement.Object);
            var flowchartNodeSerializer = new FlowchartNodeSerializer();
            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.Converters.Add(flowchartNodeSerializer);

            // Act
            var json = JsonConvert.SerializeObject(node, serializerSettings);

            // Assert
            Assert.IsTrue(json.Contains("\"Type\":\"HtmlElement\""));
            Assert.IsTrue(json.Contains("\"Element\""));
        }

        [TestMethod]
        public void ReadJson_ShouldDeserializeStartEndNode()
        {
            // Arrange
            var json = "{\"Id\":\"" + Guid.NewGuid() + "\",\"Type\":\"StartEnd\",\"isStart\":true,\"Label\":\"Start Node\"}";
            var flowchartNodeSerializer = new FlowchartNodeSerializer();
            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.Converters.Add(flowchartNodeSerializer);

            // Act
            var node = JsonConvert.DeserializeObject<FlowchartNode>(json, serializerSettings) as StartEndNode;

            // Assert
            Assert.IsNotNull(node);
            Assert.IsTrue(node.IsStart);
            Assert.AreEqual("Start Node", node.Label);
        }

        [TestMethod]
        public void ReadJson_ShouldDeserializeHtmlNode()
        {
            // Arrange
            var json = "{\"Id\":\"" + Guid.NewGuid() + "\",\"Type\":\"HtmlElement\",\"Label\":\"Html Node\",\"Element\":{}}";
            var flowchartNodeSerializer = new FlowchartNodeSerializer();
            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.Converters.Add(flowchartNodeSerializer);

            // Act
            var node = JsonConvert.DeserializeObject<FlowchartNode>(json, serializerSettings) as HtmlNode;

            // Assert
            Assert.IsNotNull(node);
            Assert.AreEqual("Html Node", node.Label);
        }

        [TestMethod]
        public void CanConvert_ShouldReturnTrueForFlowchartNode()
        {
            // Arrange
            var flowchartNodeSerializer = new FlowchartNodeSerializer();

            // Act
            var canConvert = flowchartNodeSerializer.CanConvert(typeof(FlowchartNode));

            // Assert
            Assert.IsTrue(canConvert);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Unknown node type")]
        public void ReadJson_ShouldThrowExceptionForUnknownNodeType()
        {
            // Arrange
            var json = "{\"Id\":\"" + Guid.NewGuid() + "\",\"Type\":\"Unknown\",\"Label\":\"Unknown Node\"}";
            var flowchartNodeSerializer = new FlowchartNodeSerializer();
            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.Converters.Add(flowchartNodeSerializer);

            // Act
            JsonConvert.DeserializeObject<FlowchartNode>(json, serializerSettings);

            // Assert
            // Exception expected
        }
    }
}
