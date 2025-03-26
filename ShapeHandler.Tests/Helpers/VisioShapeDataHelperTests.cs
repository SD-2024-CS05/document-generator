using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapeHandler.Objects;
using System.Collections.Generic;
using AngleSharp.Html.Dom;
using Moq;
using Visio = Microsoft.Office.Interop.Visio;
using Microsoft.Office.Tools;
using System;

namespace ShapeHandler.Tests.Helpers
{

    [Ignore("Ignoring while figuring out how to get Factory mocked")]
    [TestClass]
    public class VisioShapeDataHelperTests
    {
        private Mock<Visio.Shape> _mockShape;
        private Mock<Visio.Page> _mockPage;
        private Mock<Visio.Application> _mockApplication;

        [TestInitialize]
        public void TestInitialize()
        {

            _mockShape = new Mock<Visio.Shape>();
            _mockPage = new Mock<Visio.Page>();
            _mockApplication = new Mock<Visio.Application>();

            var mockFactory = new Mock<Factory>();
            var mockServiceProvider = new Mock<IServiceProvider>();
            var mockHostItemProvider = new Mock<IHostItemProvider>();
            var mockAddInExtension = new Mock<IAddInExtension>();

            // Mock the CreateAddIn method to return a valid AddInBase object
            mockFactory.Setup(factory => factory.CreateAddIn(
                It.IsAny<IServiceProvider>(),
                It.IsAny<IHostItemProvider>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<object>(),
                It.IsAny<IAddInExtension>()
            )).Returns((IServiceProvider serviceProvider, IHostItemProvider hostItemProvider, string primaryCookie, string identifier, object containerComponent, IAddInExtension extension) =>
            {
                return (AddIn)new Mock<AddInBase>(mockFactory.Object, serviceProvider, primaryCookie, identifier).Object;
            });

            Globals.ShapeDetector = new ShapeDetector(mockFactory.Object, mockServiceProvider.Object);
            Globals.ShapeDetector.Application = _mockApplication.Object;
            _mockApplication.Setup(app => app.ActivePage).Returns(_mockPage.Object);
            _mockPage.Setup(page => page.Shapes.get_ItemFromID(It.IsAny<int>())).Returns(_mockShape.Object);
        }


        [TestMethod]
        public void AddShapeData_AddsDataCorrectly()
        {
            // Arrange
            int shapeId = 1;
            string schema = "Test Schema";
            string label = "Test Label";

            _mockShape.Setup(shape => shape.get_RowCount(It.IsAny<short>())).Returns(0);
            _mockShape.Setup(shape => shape.AddRow(It.IsAny<short>(), It.IsAny<short>(), It.IsAny<short>()));

            // Act
            VisioShapeDataHelper.AddShapeData(shapeId, schema, label);

            // Assert
            _mockShape.Verify(shape => shape.AddRow(It.IsAny<short>(), It.IsAny<short>(), It.IsAny<short>()), Times.Once);
        }

        [TestMethod]
        public void GetShapeData_ReturnsCorrectData()
        {
            // Arrange
            int shapeId = 1;
            var shapeData = new Dictionary<string, object>
            {
                { "Label", "Test Label" },
                { "Value", "Test Value" }
            };

            _mockShape.Setup(shape => shape.get_RowCount(It.IsAny<short>())).Returns(1);
            _mockShape.SetupSequence(shape => shape.get_CellsSRC(It.IsAny<short>(), It.IsAny<short>(), It.IsAny<short>()).get_ResultStrU(It.IsAny<string>()))
                .Returns("Test Label")
                .Returns("Test Value");

            // Act
            var result = VisioShapeDataHelper.GetShapeData(shapeId);

            // Assert
            Assert.AreEqual(shapeData["Label"], result["Label"]);
            Assert.AreEqual(shapeData["Value"], result["Value"]);
        }

        [TestMethod]
        public void GetNodeType_ReturnsCorrectNodeType()
        {
            // Arrange
            int shapeId = 1;
            var shapeData = new Dictionary<string, object>
            {
                { "Node Type", "Button" }
            };

            _mockShape.Setup(shape => shape.get_RowCount(It.IsAny<short>())).Returns(1);
            _mockShape.Setup(shape => shape.get_CellsSRC(It.IsAny<short>(), It.IsAny<short>(), It.IsAny<short>()).get_ResultStrU(It.IsAny<string>()))
                .Returns("Button");

            // Act
            var result = VisioShapeDataHelper.GetNodeType(shapeId);

            // Assert
            Assert.AreEqual(NodeType.Button, result);
        }

        [TestMethod]
        public void GetHtmlElements_ReturnsCorrectHtmlElements()
        {
            // Arrange
            int shapeId = 1;
            var shapeData = new Dictionary<string, object>
            {
                { "Node Type", "Button" },
                { "HtmlElement", "{\"tagName\":\"button\"}" }
            };

            _mockShape.Setup(shape => shape.get_RowCount(It.IsAny<short>())).Returns(2);
            _mockShape.SetupSequence(shape => shape.get_CellsSRC(It.IsAny<short>(), It.IsAny<short>(), It.IsAny<short>()).get_ResultStrU(It.IsAny<string>()))
                .Returns("Button")
                .Returns("{\"tagName\":\"button\"}");

            // Act
            var result = VisioShapeDataHelper.GetHtmlElements(shapeId);

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("button", result[0].TagName);
        }

        [TestMethod]
        public void CheckIfRowsExist_ReturnsTrueIfRowsExist()
        {
            // Arrange
            int shapeId = 1;

            _mockShape.Setup(shape => shape.get_RowCount(It.IsAny<short>())).Returns(1);

            // Act
            var result = VisioShapeDataHelper.CheckIfRowsExist(shapeId);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckIfRowsExist_ReturnsFalseIfNoRowsExist()
        {
            // Arrange
            int shapeId = 1;

            _mockShape.Setup(shape => shape.get_RowCount(It.IsAny<short>())).Returns(0);

            // Act
            var result = VisioShapeDataHelper.CheckIfRowsExist(shapeId);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
