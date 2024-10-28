using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapeHandler.Objects;

namespace ShapeHandler.Objects.Tests
{
    /// <summary>This class contains parameterized unit tests for HtmlGraph</summary>
    [TestClass]
    [PexClass(typeof(HtmlGraph))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class HtmlGraphTest
    {

        /// <summary>Test stub for .ctor()</summary>
        [PexMethod]
        public HtmlGraph ConstructorTest()
        {
            HtmlGraph target = new HtmlGraph();
            PexAssert.IsNotNull(target);
            return target;
        }

        /// <summary>Test stub for AddConnection(FlowchartNode, FlowchartNode, String, String)</summary>
        [PexMethod]
        public void AddConnectionTest(
            [PexAssumeUnderTest] HtmlGraph target01,
            FlowchartNode source,
            FlowchartNode target,
            string label,
            string behavior
        )
        {
            target01.AddConnection(source, target, label, behavior);
            PexAssert.IsNotNull(target01);
        }

        /// <summary>Test stub for AddNode(FlowchartNode)</summary>
        [PexMethod]
        public void AddNodeTest([PexAssumeUnderTest] HtmlGraph target, FlowchartNode node)
        {
            target.AddNode(node);
            PexAssert.IsNotNull(target);
        }
    }
}
