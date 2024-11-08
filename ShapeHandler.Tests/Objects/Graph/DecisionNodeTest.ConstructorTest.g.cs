using Microsoft.Pex.Framework.Generated;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Pex.Framework;
using ShapeHandler.Objects;
// <copyright file="DecisionNodeTest.ConstructorTest.g.cs">Copyright ©  2024</copyright>
// <auto-generated>
// This file contains automatically generated tests.
// Do not modify this file manually.
// 
// If the contents of this file becomes outdated, you can delete it.
// For example, if it no longer compiles.
// </auto-generated>
using System;
using AngleSharp;
using AngleSharp.Html.Dom;
using System.Collections.Generic;

namespace ShapeHandler.Objects.Tests
{
    public partial class DecisionNodeTest
    {

        [TestMethod]
        [PexGeneratedBy(typeof(DecisionNodeTest))]
        public void ConstructorTest180()
        {
            var context = BrowsingContext.New(Configuration.Default);
            var document = context.OpenNewAsync().Result;

            DecisionNode decisionNode;
            var elementList = new List<IHtmlElement> { (IHtmlElement)document.CreateElement("input") };
            decisionNode = this.ConstructorTest("testId", elementList);
            PexAssert.IsNotNull((object)decisionNode);
            PexAssert.IsNotNull(decisionNode.Elements);
            PexAssert.AreEqual<int>(0, decisionNode.Elements.Capacity);
            PexAssert.AreEqual<int>(0, decisionNode.Elements.Count);
            PexAssert.AreEqual<string>((string)null, ((FlowchartNode)decisionNode).Id);
            PexAssert.AreEqual<NodeType>
                (NodeType.Decision, ((FlowchartNode)decisionNode).Type);
        }
    }
}
