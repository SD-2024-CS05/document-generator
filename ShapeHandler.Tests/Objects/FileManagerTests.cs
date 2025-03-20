using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapeHandler.Objects;
using System;
using System.IO;

namespace ShapeHandler.Tests.Objects
{
    [TestClass]
    public class FileManagerTests
    {
        [TestMethod]
        public void GetFilePath_FileExists_ReturnsCorrectPath()
        {
            // Arrange
            string fileName = "existingFile.txt";
            string expectedPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            File.Create(expectedPath).Dispose();

            // Act
            string result = FileManager.GetFilePath(fileName);

            // Assert
            Assert.AreEqual(expectedPath, result);

            // Cleanup
            File.Delete(expectedPath);
        }

        [TestMethod]
        public void GetFilePath_FileDoesNotExist_ReturnsBinPath()
        {
            // Arrange
            string fileName = "nonExistingFile.txt";
            string expectedPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin", fileName);

            // Act
            string result = FileManager.GetFilePath(fileName);

            // Assert
            Assert.AreEqual(expectedPath, result);
        }

        [TestMethod]
        public void GetFilePath_ExceptionThrown_ReturnsNull()
        {
            // Arrange
            string fileName = null;

            // Act
            string result = FileManager.GetFilePath(fileName);

            // Assert
            Assert.IsNull(result);
        }
    }
}
