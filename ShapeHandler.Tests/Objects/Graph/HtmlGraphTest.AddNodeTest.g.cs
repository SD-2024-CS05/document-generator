using AngleSharp;
using AngleSharp.Html.Dom;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Generated;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapeHandler.Objects;
// <copyright file="HtmlGraphTest.AddNodeTest.g.cs">Copyright ©  2024</copyright>
// <auto-generated>
// This file contains automatically generated tests.
// Do not modify this file manually.
// 
// If the contents of this file becomes outdated, you can delete it.
// For example, if it no longer compiles.
// </auto-generated>
using System;
using System.Collections.Generic;

namespace ShapeHandler.Objects.Tests
{
    public partial class HtmlGraphTest
    {

        [TestMethod]
        [PexGeneratedBy(typeof(HtmlGraphTest))]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNodeTestThrowsArgumentNullException946()
        {
            HtmlGraph htmlGraph;
            htmlGraph = new HtmlGraph();
            this.AddNodeTest(htmlGraph, (FlowchartNode)null);
        }

        [TestMethod]
        [PexGeneratedBy(typeof(HtmlGraphTest))]
        public void AddNodeTest503()
        {
            HtmlGraph htmlGraph;
            PageNode pageNode;
            htmlGraph = new HtmlGraph();
            pageNode = new PageNode((string)null);
            this.AddNodeTest(htmlGraph, (FlowchartNode)pageNode);
            PexAssert.IsNotNull((object)htmlGraph);
        }

        [TestMethod]
        [PexGeneratedBy(typeof(HtmlGraphTest))]
        public void AddNodeTest616()
        {
            HtmlGraph htmlGraph;
            StartEndNode startEndNode;
            htmlGraph = new HtmlGraph();
            startEndNode = new StartEndNode((string)null);
            this.AddNodeTest(htmlGraph, (FlowchartNode)startEndNode);
            PexAssert.IsNotNull((object)htmlGraph);
        }

        [TestMethod]
        [PexGeneratedBy(typeof(HtmlGraphTest))]
        public void AddNodeTest911()
        {
            HtmlGraph htmlGraph;
            DecisionNode decisionNode;
            htmlGraph = new HtmlGraph();
            decisionNode = new DecisionNode("test1");
            this.AddNodeTest(htmlGraph, (FlowchartNode)decisionNode);
            PexAssert.IsNotNull((object)htmlGraph);
        }
    }
}
