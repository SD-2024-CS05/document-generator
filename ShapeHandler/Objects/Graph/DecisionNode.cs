using AngleSharp.Html.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeHandler.Objects
{
    public class DecisionElement : HtmlNode
    {
        public Dictionary<string, HtmlNode> OutgoingPaths { get; set; } = new Dictionary<string, HtmlNode>();

        public DecisionElement(IHtmlBaseElement element) : base(element) { }

        // Add a new path option for the decision
        public void AddPath(string condition, HtmlNode targetNode)
        {
            OutgoingPaths[condition] = targetNode;
        }
    }

}
