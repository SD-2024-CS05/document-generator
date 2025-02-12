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
        public string URL { get; set; }
        public NodeType Type { get; set; }

        protected FlowchartNode(string label, NodeType type)
        {
            Id = Guid.NewGuid().ToString();
            Label = label ?? Id;
            Type = type;
        }

        public override string ToString()
        {
            return "{id: \"" + Id + "\", type: \"" + Type.ToString().ToUpper() + "\"}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            FlowchartNode node = (FlowchartNode)obj;
            return Id == node.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }

}
