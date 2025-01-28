using System.Collections;
using System.Collections.Generic;
using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
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
        [Ignore]
        [DataRow("TestShape.vsdx")]
        public void ReadShapeDataTest(string visioFileName)
        {
            // I need to make this test better. I know.
            Mock<Application> mockVisioApp = new Mock<Application>();
            Mock<Documents> mockDocuments = new Mock<Documents>();
            Mock<Microsoft.Office.Interop.Visio.Document> mockDocument = new Mock<Microsoft.Office.Interop.Visio.Document>();
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

        [TestMethod]
        public void ConvertAngleSharp()
        {
            IBrowsingContext context = BrowsingContext.New(Configuration.Default);
            IDocument document = context.OpenNewAsync().Result;
            IHtmlInputElement input = document.CreateElement("input") as IHtmlInputElement;
            input.Type = "number";
            input.Id = "inputUseless";
            input.Minimum = "420";
            input.Maximum = "1337";
            input.ValueAsNumber = 999; 
            input.ClassList.Add("form-control");
            Assert.IsTrue(input.ValueAsNumber >= int.Parse(input.Minimum) && input.ValueAsNumber <= int.Parse(input.Maximum));
        }
    }
}
