using AngleSharp.Html.Dom;
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapeHandler.Objects;

namespace ShapeHandler.Objects.Tests
{
    /// <summary>This class contains parameterized unit tests for HtmlNode</summary>
    [TestClass]
    [PexClass(typeof(HtmlNode))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class HtmlNodeTest
    {

        /// <summary>Test stub for .ctor(IHtmlElement)</summary>
        [PexMethod]
        public HtmlNode ConstructorTest(IHtmlElement element)
        {
            HtmlNode target = new HtmlNode(element);
            PexAssert.IsNotNull(target);
            return target;
        }
    }
}
