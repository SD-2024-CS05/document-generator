using System;
using System.Collections.Generic;

namespace ShapeHandler
{
    public enum AnchorConditionType
    {
        Click,
        Href,
        Rel
    }

    public class Anchor
    {
        public string Href { get; set; }
        public string Target { get; set; }
        public string Rel { get; set; }
        public List<Condition<AnchorConditionType>> Conditions { get; set; }
    }
}
