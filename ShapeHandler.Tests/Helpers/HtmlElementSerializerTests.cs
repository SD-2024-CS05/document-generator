using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using ShapeHandler.Helpers;
using System;

namespace ShapeHandler.Tests.Helpers
{
    [TestClass]
    public class HtmlElementSerializerTests
    {
        private HtmlElementSerializer _serializer;
        private HtmlParser _parser;

        [TestInitialize]
        public void Setup()
        {
            _serializer = new HtmlElementSerializer();
            _parser = new HtmlParser();
        }

        [TestMethod]
        public void WriteJson_ShouldSerializeHtmlElement()
        {
            // Arrange
            string html = "<div id='test'>Hello World</div>";
            IHtmlElement element = _parser.ParseDocument(html).Body.FirstElementChild as IHtmlElement;
            string expectedJson = "{\"OuterHtml\":\"<div id=\\\"test\\\">Hello World</div>\"}";

            // Act
            string json = JsonConvert.SerializeObject(element, _serializer);

            // Assert
            Assert.AreEqual(expectedJson, json);
        }

        [TestMethod]
        public void ReadJson_ShouldDeserializeToHtmlElement()
        {
            // Arrange
            string json = "{\"OuterHtml\":\"<div id=\\\"test\\\">Hello World</div>\"}";
            string expectedHtml = "<div id=\"test\">Hello World</div>";

            // Act
            IHtmlElement element = JsonConvert.DeserializeObject<IHtmlElement>(json, _serializer);

            // Assert
            Assert.IsNotNull(element);
            Assert.AreEqual(expectedHtml, element.OuterHtml);
        }

        [TestMethod]
        [ExpectedException(typeof(JsonSerializationException))]
        public void ReadJson_ShouldThrowExceptionForInvalidJson()
        {
            // Arrange
            string invalidJson = "{\"InvalidProperty\":\"InvalidValue\"}";

            // Act
            JsonConvert.DeserializeObject<IHtmlElement>(invalidJson, _serializer);
        }

        [TestMethod]
        public void ReadJson_ShouldDeserializeToHtmlInputElement()
        {
            // Arrange
            string json = "{\"OuterHtml\":\"<input type=\\\"text\\\" id=\\\"testInput\\\" />\"}";
            string expectedHtml = "<input type=\"text\" id=\"testInput\">";

            // Act
            IHtmlElement element = JsonConvert.DeserializeObject<IHtmlElement>(json, _serializer);

            // Assert
            Assert.IsNotNull(element);
            Assert.IsInstanceOfType(element, typeof(IHtmlInputElement));
            Assert.AreEqual(expectedHtml, element.OuterHtml);
        }

        [TestMethod]
        public void ReadJson_ShouldDeserializeToHtmlAnchorElement()
        {
            // Arrange
            string json = "{\"OuterHtml\":\"<a href=\\\"#\\\" id=\\\"testAnchor\\\">Link</a>\"}";
            string expectedHtml = "<a href=\"#\" id=\"testAnchor\">Link</a>";

            // Act
            IHtmlElement element = JsonConvert.DeserializeObject<IHtmlElement>(json, _serializer);

            // Assert
            Assert.IsNotNull(element);
            Assert.IsInstanceOfType(element, typeof(IHtmlAnchorElement));
            Assert.AreEqual(expectedHtml, element.OuterHtml);
        }

        [TestMethod]
        public void ReadJson_ShouldDeserializeToHtmlImageElement()
        {
            // Arrange
            string json = "{\"OuterHtml\":\"<img src=\\\"test.jpg\\\" id=\\\"testImage\\\" />\"}";
            string expectedHtml = "<img src=\"test.jpg\" id=\"testImage\">";

            // Act
            IHtmlElement element = JsonConvert.DeserializeObject<IHtmlElement>(json, _serializer);

            // Assert
            Assert.IsNotNull(element);
            Assert.IsInstanceOfType(element, typeof(IHtmlImageElement));
            Assert.AreEqual(expectedHtml, element.OuterHtml);
        }

        [TestMethod]
        public void ReadJson_ShouldDeserializeToHtmlButtonElement()
        {
            // Arrange
            string json = "{\"OuterHtml\":\"<button id=\\\"testButton\\\">Click me</button>\"}";
            string expectedHtml = "<button id=\"testButton\">Click me</button>";

            // Act
            IHtmlElement element = JsonConvert.DeserializeObject<IHtmlElement>(json, _serializer);

            // Assert
            Assert.IsNotNull(element);
            Assert.IsInstanceOfType(element, typeof(IHtmlButtonElement));
            Assert.AreEqual(expectedHtml, element.OuterHtml);
        }

        [TestMethod]
        public void ReadJson_ShouldDeserializeToHtmlSelectElement()
        {
            // Arrange
            string json = "{\"OuterHtml\":\"<select id=\\\"testSelect\\\"><option value=\\\"1\\\">Option 1</option><option value=\\\"2\\\">Option 2</option></select>\"}";
            string expectedHtml = "<select id=\"testSelect\"><option value=\"1\">Option 1</option><option value=\"2\">Option 2</option></select>";
            
            // Act
            IHtmlElement element = JsonConvert.DeserializeObject<IHtmlElement>(json, _serializer);
            
            // Assert
            Assert.IsNotNull(element);
            Assert.IsInstanceOfType(element, typeof(IHtmlSelectElement));
            Assert.AreEqual(expectedHtml, element.OuterHtml);
        }

        [TestMethod]
        public void CanConvert_ShouldReturnTrueForIHtmlElement()
        {
            // Act
            bool canConvert = _serializer.CanConvert(typeof(IHtmlElement));

            // Assert
            Assert.IsTrue(canConvert);
        }

        [TestMethod]
        public void CanConvert_ShouldReturnFalseForNonIHtmlElement()
        {
            // Act
            bool canConvert = _serializer.CanConvert(typeof(string));

            // Assert
            Assert.IsFalse(canConvert);
        }

    }
}
