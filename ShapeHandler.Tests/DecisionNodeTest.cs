using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapeHandler.Objects;

namespace ShapeHandler.Objects.Tests
{
    /// <summary>This class contains parameterized unit tests for DecisionNode</summary>
    [TestClass]
    [PexClass(typeof(DecisionNode))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class DecisionNodeTest
    {

        /// <summary>Test stub for .ctor(String)</summary>
        [PexMethod]
        public DecisionNode ConstructorTest(string id)
        {
            DecisionNode target = new DecisionNode(id);
            PexAssert.IsNotNull(target);
            return target;
        }
    }
}
