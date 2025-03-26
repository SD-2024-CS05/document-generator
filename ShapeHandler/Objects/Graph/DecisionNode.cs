using System;
using System.Collections.Generic;

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

        public DecisionNode(Guid guid, string label, List<HtmlNode> submissionNodes) : base(guid, label, NodeType.Decision)
        {
            Label = label;
            SubmissionNodes = submissionNodes;
        }
    }
}
