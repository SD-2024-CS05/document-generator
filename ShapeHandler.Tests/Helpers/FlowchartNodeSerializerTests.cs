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
        private FlowchartNodeSerializer _flowchartNodeSerializer;
        private JsonSerializerSettings _serializerSettings;

        [TestInitialize]
        public void TestInitialize()
        {
            _flowchartNodeSerializer = new FlowchartNodeSerializer();
            _serializerSettings = new JsonSerializerSettings();
            _serializerSettings.Converters.Add(_flowchartNodeSerializer);
        }

        [TestMethod]
        public void WriteJson_ShouldSerializeStartEndNode()
        {
            // Arrange
            var node = new StartEndNode(Guid.NewGuid(), "Start Node", true);

            // Act
            var json = JsonConvert.SerializeObject(node, _serializerSettings);

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

            // Act
            var json = JsonConvert.SerializeObject(node, _serializerSettings);

            // Assert
            Assert.IsTrue(json.Contains("\"Type\":\"HtmlElement\""));
            Assert.IsTrue(json.Contains("\"Element\""));
        }

        [TestMethod]
        public void ReadJson_ShouldDeserializeStartEndNode()
        {
            // Arrange
            var json = "{\"Id\":\"" + Guid.NewGuid() + "\",\"Type\":\"StartEnd\",\"isStart\":true,\"Label\":\"Start Node\"}";

            // Act
            var node = JsonConvert.DeserializeObject<FlowchartNode>(json, _serializerSettings) as StartEndNode;

            // Assert
            Assert.IsNotNull(node);
            Assert.IsTrue(node.IsStart);
            Assert.AreEqual("Start Node", node.Label);
        }

        [TestMethod]
        [ExpectedException(typeof(JsonSerializationException), "Unable to deserialize the html element")]
        public void ReadJson_ShouldThrowExceptionForDefaultHtmlType()
        {
            // Arrange
            var json = "{\"Id\":\"" + Guid.NewGuid() + "\",\"Type\":\"HtmlElement\",\"Label\":\"Html Node\",\"Element\":{\"OuterHtml\":\"null\"}}";

            // Act
            var node = JsonConvert.DeserializeObject<FlowchartNode>(json, _serializerSettings) as HtmlNode;

            // Assert
        }

        [TestMethod]
        public void CanConvert_ShouldReturnTrueForFlowchartNode()
        {
            // Act
            var canConvert = _flowchartNodeSerializer.CanConvert(typeof(FlowchartNode));

            // Assert
            Assert.IsTrue(canConvert);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Unknown node type")]
        public void ReadJson_ShouldThrowExceptionForUnknownNodeType()
        {
            // Arrange
            var json = "{\"Id\":\"" + Guid.NewGuid() + "\",\"Type\":\"Unknown\",\"Label\":\"Unknown Node\"}";

            // Act
            JsonConvert.DeserializeObject<FlowchartNode>(json, _serializerSettings);

            // Assert
            // Exception expected
        }
    }
}
