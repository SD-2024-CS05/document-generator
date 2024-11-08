using System;

namespace ShapeHandler.Objects
{
    public class Condition
    {
        public string ElementType { get; set; } // e.g., "button", "input"
        public string Attribute { get; set; } // e.g., "id", "class"
        public string AttributeValue { get; set; } // e.g., "submit-button", "form-control"
        public bool IsActive { get; set; } // e.g., true if the condition is active
        public Func<string, bool> Validate { get; set; } // Validation function

        public override bool Equals(object obj)
        {
            if (!(obj is Condition otherCondition))
            {
                return false;
            }

            bool elementTypeEquals = ElementType == otherCondition.ElementType;
            bool attributeEquals = Attribute == otherCondition.Attribute;
            bool attributeValueEquals = AttributeValue == otherCondition.AttributeValue;
            bool isActiveEquals = IsActive == otherCondition.IsActive;

            return elementTypeEquals && attributeEquals && attributeValueEquals && isActiveEquals;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ElementType, Attribute, AttributeValue, IsActive, Validate);
        }
    }
}
