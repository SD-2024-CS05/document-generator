using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Io;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeHandler.Objects
{
    public class HtmlNode : FlowchartNode
    {
        public IHtmlElement Element { get; set; }

        public HtmlNode(IHtmlElement element) : base(element.Id, NodeType.HtmlElement)
        {
            Element = element;
        }
    }

}
