using AngleSharp.Html.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeHandler.Objects
{
    public class DataInputWrapperNode : FlowchartNode
    {
        public List<HtmlNode> DataInputNodes { get; set; }

        public DataInputWrapperNode(string label, NodeType type = NodeType.DataInput) : base(label, type)
        {
            DataInputNodes = new List<HtmlNode>();
        }

        public DataInputWrapperNode(string label, List<HtmlNode> dataInputNodes, NodeType type = NodeType.DataInput) : base(label, type)
        {
            DataInputNodes = dataInputNodes;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (!(obj is DataInputWrapperNode otherNode))
            {
                return false;
            }

            // make sure that the id is the same that is all that's needed
            return Id == otherNode.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"{{");
            builder.Append($"id: \"{Id}\", ");
            builder.Append($"type: \"{Type.ToString().ToUpper()}\", ");
            builder.Append($"label: \"{Label}\", ");
            builder.Append($"dataInputNodes: [");
            foreach (var node in DataInputNodes)
            {
                builder.Append($"{node}, ");
            }
            builder.Append($"]");
            builder.Append($"}}");

            return builder.ToString();
        }
    }
}
