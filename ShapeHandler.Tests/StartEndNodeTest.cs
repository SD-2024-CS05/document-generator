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
    }
}
