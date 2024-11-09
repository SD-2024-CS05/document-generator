using Microsoft.Pex.Framework.Generated;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Pex.Framework;
using ShapeHandler.Objects;
// <copyright file="StartEndNodeTest.Constructor.g.cs">Copyright ©  2024</copyright>
// <auto-generated>
// This file contains automatically generated tests.
// Do not modify this file manually.
// 
// If the contents of this file becomes outdated, you can delete it.
// For example, if it no longer compiles.
// </auto-generated>
using System;

namespace ShapeHandler.Objects.Tests
{
    public partial class StartEndNodeTest
    {

        [TestMethod]
        [PexGeneratedBy(typeof(StartEndNodeTest))]
        public void Constructor889()
        {
            StartEndNode startEndNode;
            startEndNode = this.Constructor((string)null);
            PexAssert.IsNotNull((object)startEndNode);
            PexAssert.IsNotNull(((FlowchartNode)startEndNode).Id);
            PexAssert.AreEqual<NodeType>
                (NodeType.StartEnd, ((FlowchartNode)startEndNode).Type);
        }
    }
}
