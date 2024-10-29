using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapeHandler.Objects;

namespace ShapeHandler.Objects.Tests
{
    /// <summary>This class contains parameterized unit tests for StartEndNode</summary>
    [TestClass]
    [PexClass(typeof(StartEndNode))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class StartEndNodeTest
    {

        [PexMethod]
        public StartEndNode Constructor(string id)
        {
            StartEndNode target = new StartEndNode(id);
            return target;
            // TODO: add assertions to method StartEndNodeTest.Constructor(String)
        }
    }
}
