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
        public List<HtmlNode> SubmissionNodes { get; set; } = new List<HtmlNode>();
        public DecisionNode(string label) : base(label, NodeType.Decision) 
        {
            Label = label;
        }

        public DecisionNode(string label, List<HtmlNode> submissionNodes) : base(label, NodeType.Decision)
        {
            Label = label;
            SubmissionNodes = submissionNodes;
        }
    }
}
