using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeHandler
{
    public class Input : WebElement
    {
        public string Type { get; set; }
        public string Value { get; set; }
        public bool Disabled { get; set; }
        public string Name { get; set; }
        public string Placeholder { get; set; }
        public List<Condition<InputConditionType>> Conditions { get; set; }
    }

    public enum InputConditionType
    {
        Value,
        Focus,
        Disabled
    }
}
