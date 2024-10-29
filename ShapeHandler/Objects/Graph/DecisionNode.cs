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
        public List<Condition<string>> Conditions { get; set; }

        public DecisionNode(string id) : base(id, NodeType.Decision)
        {
            Conditions = new List<Condition<string>>();
        }
    }
}
