using AngleSharp.Html.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeHandler.Objects
{
    public class HtmlNode
    {
        public IHtmlBaseElement Element { get; set; }
        public List<Edge> OutgoingEdges { get; set; } = new List<Edge>();

        public HtmlNode(IHtmlBaseElement element)
        {
            Element = element;
        }
    }

}
