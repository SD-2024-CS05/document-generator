using AngleSharp.Html.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeHandler.Objects
{
    public class DecisionNode : FlowchartNode
    {

        public List<IHtmlElement> Elements { get; set; }

        public DecisionNode(string label, List<IHtmlElement> elements) : base(label, NodeType.Decision)
        {
            Elements = elements;
        }
    }
}
