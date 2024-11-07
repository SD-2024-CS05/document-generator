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
            Application visioApp;
            try
            {
                visioApp = (Application)Marshal.GetActiveObject("Visio.Application");
            }
            catch (COMException)
            {
                visioApp = new Application();
            }

            string visioPath = FileManager.GetFilePath(visioFileName);

            visioPath = System.IO.Path.Combine(visioPath, visioFileName);

            var visioDoc = visioApp.Documents.Add(visioPath);

            // Act
            var result = ShapeDetector.CreateGraphFromFlowchart(visioApp);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}