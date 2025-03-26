using System;

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
            if (label == null || label == "")
            {
                Label = Id;
            }
            else
            {
                Label = label;
            }
            Type = type;
        }

        protected FlowchartNode(Guid id, string label, NodeType type)
        {
            if (id == Guid.Empty)
            {
                Id = Guid.NewGuid().ToString();
            }
            else
            {
                Id = id.ToString();
            }

            if (label == null || label == "")
            {
                Label = Id;
            }
            else
            {
                Label = label;
            }
            Type = type;
        }

        public override string ToString()
        {
            return "{id: \"" + Id + "\", type: \"" + Type.ToString().ToUpper() + "\"}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is FlowchartNode))
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
