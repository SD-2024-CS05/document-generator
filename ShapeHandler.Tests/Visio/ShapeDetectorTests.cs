using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShapeHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Visio;
using System.IO;
using ShapeHandler.Objects;
using System.Runtime.InteropServices;

namespace ShapeHandler.Tests
{
    [TestClass()]
    public class ShapeDetectorTests
    {
        [TestMethod()]
        [DataRow("TestFlowDiagram.vsdx")]
        public void CreateGraphTest(string visioFileName)
        {
            // Arrange
            var mockVisioApp = new Mock<Application>();
            var mockDocuments = new Mock<Documents>();
            var mockDocument = new Mock<Document>();

            mockVisioApp.Setup(app => app.Documents).Returns(mockDocuments.Object);
            mockDocuments.Setup(docs => docs.Add(It.IsAny<string>())).Returns(mockDocument.Object);

            string visioPath = FileManager.GetFilePath(visioFileName);
            visioPath = System.IO.Path.Combine(visioPath, visioFileName);

            SetupVisioFile(mockVisioApp.Object, visioPath);

            // Act
            var result = ShapeDetector.CreateGraphFromFlowchart(mockVisioApp.Object);

            // Assert
            Assert.IsNotNull(result);
        }

        private static void SetupVisioFile(Application application, string visioPath)
        {
            application.Documents.Add(visioPath);
        }
    }
}