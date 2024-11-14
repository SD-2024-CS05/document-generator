using System;
using System.Collections.Generic;
using System.Text;

namespace ShapeHandler.Objects
{
    public class Condition
    {
        public string NodeId { get; set; }

        public Dictionary<string, object> Attributes { get; set; }

        public Func<string, bool> Validate { get; set; } // Validation function against the other attributes

        public override bool Equals(object obj)
        {
            if (!(obj is Condition otherCondition))
            {
                return false;
            }

            return NodeId == otherCondition.NodeId;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"{{");
            builder.Append($"nodeId: \"{NodeId}\", ");
            builder.Append($"attributes: {{");
            foreach (var attribute in Attributes)
            {
                builder.Append($"{attribute.Key}: {attribute.Value}, ");
            }
            builder.Append($"}}");
            builder.Append($"}}");
            foreach (var attribute in Attributes) {
                builder.Append($"{attribute.Key}: {attribute.Value}, ");
            }
            return builder.ToString();
        }
    }
}
