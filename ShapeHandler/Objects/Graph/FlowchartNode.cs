using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ShapeHandler.Objects
{
    public abstract class FlowchartNode
    {
        public string Id { get; }
        public string Label { get; set; }
        public NodeType Type { get; set; }

        protected FlowchartNode(string label, NodeType type)
        {
            Id = Guid.NewGuid().ToString();
            Label = label;
            Type = type;
        }

        public override string ToString()
        {
            return "{id: \"" + Id + "\", type: \"" + Type.ToString().ToUpper() + "\"}";
        }

    }

}
