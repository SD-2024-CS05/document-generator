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

        public List<string> DecisionElementIds { get; set; }

        public DecisionNode(string label, List<string> elements) : base(label, NodeType.Decision)
        {
            Label = label;
            DecisionElementIds = elements;
        }

        public DecisionNode(string label) : base(label, NodeType.Decision)
        {
            Label = label;
            DecisionElementIds = new List<string>();
        }
    }
}
