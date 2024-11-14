using System;
using System.Collections.Generic;
using AngleSharp.Html.Dom;
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
        public DecisionNode ConstructorTest(string label, List<string> elements)
        {
            DecisionNode target = new DecisionNode(label);
            PexAssert.IsNotNull(target);
            return target;
        }
    }
}
