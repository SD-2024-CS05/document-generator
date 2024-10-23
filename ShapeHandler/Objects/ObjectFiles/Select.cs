using System;
using System.Collections.Generic;

namespace ShapeHandler
{
    public class Select : WebElement
    {
        public string Name { get; set; }
        public bool Disabled { get; set; }
        public List<Option> Options { get; set; }
        public List<Condition<SelectConditionType>> Conditions { get; set; }
    }

    public class Option
    {
        public string Value { get; set; }
        public string Label { get; set; }
        public bool Disabled { get; set; }
    }

    public enum SelectConditionType
    {
        SelectedOption,
        Disabled
    }
}
