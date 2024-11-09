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

        public List<HtmlNode> ValidationElements { get; set; }

        public DecisionNode(string label, List<HtmlNode> elements) : base(label, NodeType.Decision)
        {
            ValidationElements = elements;
        }
    }
}
