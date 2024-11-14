using Microsoft.Pex.Framework.Generated;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Pex.Framework;
using ShapeHandler.Objects;
// <copyright file="PageNodeTest.ConstructorTest.g.cs">Copyright ©  2024</copyright>
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
    public partial class PageNodeTest
    {

        [TestMethod]
        [PexGeneratedBy(typeof(PageNodeTest))]
        public void ConstructorTest512()
        {
            PageNode pageNode;
            pageNode = this.ConstructorTest((string)null);
            PexAssert.IsNotNull((object)pageNode);
            PexAssert.IsNotNull(((FlowchartNode)pageNode).Id);
            PexAssert.AreEqual<NodeType>(NodeType.Page, ((FlowchartNode)pageNode).Type);
        }
    }
}
