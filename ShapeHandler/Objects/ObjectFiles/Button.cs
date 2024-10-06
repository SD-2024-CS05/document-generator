using System.Collections.Generic;

namespace ShapeHandler
{
    public class Button : WebAction
    {
        public string Type { get; set; }
        public string Value { get; set; }
        public bool Disabled { get; set; }
        public string Name { get; set; }
        public List<Condition<ButtonConditionType>> Conditions { get; set; }
    }

    public enum ButtonConditionType
    {
        Click,
        DoubleClick,
        Disabled,
        Text
    }
}
