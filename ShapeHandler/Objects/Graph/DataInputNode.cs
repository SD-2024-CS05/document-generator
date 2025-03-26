using System;
using System.Collections.Generic;
using System.Text;

namespace ShapeHandler.Objects
{
    public class DataInputNode : FlowchartNode
    {
        public List<HtmlNode> DataInputNodes { get; set; } = new List<HtmlNode>();

        public DataInputNode(string label, NodeType type = NodeType.DataInput) : base(label, type)
        {
            DataInputNodes = new List<HtmlNode>();
        }

        public DataInputNode(string label, List<HtmlNode> dataInputNodes, NodeType type = NodeType.DataInput) : base(label, type)
        {
            DataInputNodes = dataInputNodes;
        }

        public DataInputNode(Guid guid, string label, List<HtmlNode> dataInputNodes, NodeType type = NodeType.DataInput) : base(guid, label, type)
        {
            DataInputNodes = dataInputNodes;
        }

        public DataInputNode(List<HtmlNode> dataInputNodes) : base("", NodeType.DataInput)
        {
            DataInputNodes = dataInputNodes;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (!(obj is DataInputNode otherNode))
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
            foreach (HtmlNode node in DataInputNodes)
            {
                builder.Append($"{node}, ");
            }
            builder.Append($"]");
            builder.Append($"}}");

            return builder.ToString();
        }
    }
}
