// <copyright file="ShapeDetectorTest.cs">Copyright ©  2024</copyright>
using System;
using Microsoft.Office.Tools;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapeHandler;

namespace ShapeHandler.Tests
{
    /// <summary>This class contains parameterized unit tests for ShapeDetector</summary>
    [PexClass(typeof(ShapeDetector))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class ShapeDetectorTest
    {
        /// <summary>Test stub for .ctor(Factory, IServiceProvider)</summary>
        [PexMethod]
        public ShapeDetector ConstructorTest(Factory factory, IServiceProvider serviceProvider)
        {
            ShapeDetector target = new ShapeDetector(factory, serviceProvider);
            return target;
            // TODO: add assertions to method ShapeDetectorTest.ConstructorTest(Factory, IServiceProvider)
        }
    }
}
