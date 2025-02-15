using System.Collections;
using System.Collections.Generic;
using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using Microsoft.Office.Interop.Visio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShapeHandler.Objects;
using ShapeHandler.ShapeTransformation;

namespace ShapeHandler.Tests.ShapeTransformation
{
    [TestClass()]
    public class ShapeReaderTests
    {
        [TestMethod]
        public void ConvertAngleSharp()
        {
            IBrowsingContext context = BrowsingContext.New(Configuration.Default);
            IDocument document = context.OpenNewAsync().Result;
            IHtmlInputElement input = document.CreateElement("input") as IHtmlInputElement;
            input.Type = "number";
            input.Id = "inputUseless";
            input.Minimum = "420";
            input.Maximum = "1337";
            input.ValueAsNumber = 999; 
            input.ClassList.Add("form-control");
            Assert.IsTrue(input.ValueAsNumber >= int.Parse(input.Minimum) && input.ValueAsNumber <= int.Parse(input.Maximum));
        }
    }
}
