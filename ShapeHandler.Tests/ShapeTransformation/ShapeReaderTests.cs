using System.Collections;
using System.Collections.Generic;
using Microsoft.Office.Interop.Visio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShapeHandler.Objects;
using ShapeHandler.ShapeTransformation;

namespace ShapeHandler.Tests.ShapeTransformation
{
    [TestClass()]
    public class ShapeReaderTests
    {
        [TestMethod()]
        [DataRow("TestShape.vsdx")]
        public void ReadShapeDataTest(string visioFileName)
        {
            // I need to make this test better. I know.
            Mock<Application> mockVisioApp = new Mock<Application>();
            Mock<Documents> mockDocuments = new Mock<Documents>();
            Mock<Document> mockDocument = new Mock<Document>();
            mockVisioApp.Setup(app => app.Documents).Returns(mockDocuments.Object);
            mockDocuments.Setup(docs => docs.Add(It.IsAny<string>())).Returns(mockDocument.Object);
            string visioPath = FileManager.GetFilePath(visioFileName);
            visioPath = System.IO.Path.Combine(visioPath, visioFileName);
            SetupVisioFile(mockVisioApp.Object, visioPath);
            IDictionary<string, string> result = ShapeReader.ReadShapeData(mockVisioApp.Object.ActivePage.Shapes.ContainingShape);
            Assert.IsTrue(result.Count > 0);
        }

        private static void SetupVisioFile(Application application, string visioPath)
        {
            application.Documents.Add(visioPath);
        }
    }
}
