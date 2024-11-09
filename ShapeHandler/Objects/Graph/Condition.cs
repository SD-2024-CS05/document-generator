using System;
using System.Text;

namespace ShapeHandler.Objects
{
    public class Condition
    {
        public string ElementType { get; set; } // e.g., "button", "input"
        public string Attribute { get; set; } // e.g., "id", "class"
        public string AttributeValue { get; set; } // e.g., "submit-button", "form-control"
        public bool IsActive { get; set; } // e.g., true if the condition is active
        public string NodeId { get; set; } // Associated HtmlNode id

        public Func<string, bool> Validate { get; set; } // Validation function against the other attributes

        public override bool Equals(object obj)
        {
            if (!(obj is Condition otherCondition))
            {
                return false;
            }

            return ElementType == otherCondition.ElementType &&
                   Attribute == otherCondition.Attribute &&
                   AttributeValue == otherCondition.AttributeValue &&
                   IsActive == otherCondition.IsActive &&
                   NodeId == otherCondition.NodeId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ElementType, Attribute, AttributeValue, IsActive, NodeId);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"{{");
            builder.Append($"elementType: \"{ElementType}\", ");
            builder.Append($"attribute: \"{Attribute}\", ");
            builder.Append($"attributeValue: \"{AttributeValue}\", ");
            builder.Append($"isActive: \"{IsActive}\", ");
            builder.Append($"node: \"{NodeId}\"");
            builder.Append($"}}");

            return builder.ToString();
        }
    }
}
