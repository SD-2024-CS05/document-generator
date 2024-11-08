using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapeHandler.Objects;

namespace ShapeHandler.Objects.Tests
{
    /// <summary>This class contains parameterized unit tests for Connection</summary>
    [TestClass]
    [PexClass(typeof(Connection))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class ConnectionTest
    {

        /// <summary>Test stub for .ctor(String, String, FlowchartNode, FlowchartNode)</summary>
        [PexMethod]
        public Connection ConstructorTest(
            string label
        )
        {
            Connection target01 = new Connection(label);
            PexAssert.IsNotNull(target01);
            return target01;
        }
    }
}
