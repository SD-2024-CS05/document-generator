using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapeHandler.Objects;

namespace ShapeHandler.Objects.Tests
{
    /// <summary>This class contains parameterized unit tests for PageNode</summary>
    [TestClass]
    [PexClass(typeof(PageNode))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class PageNodeTest
    {

        /// <summary>Test stub for .ctor(String)</summary>
        [PexMethod]
        public PageNode ConstructorTest(string id)
        {
            PageNode target = new PageNode(id);
            PexAssert.IsNotNull(target);
            return target;
        }
    }
}
