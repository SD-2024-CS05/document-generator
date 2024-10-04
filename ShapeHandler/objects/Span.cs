using System;
using System.Collections.Generic;

namespace ShapeHandler
{
    public class Span
    {
        public string Id { get; set; }
        public string Class { get; set; }
        public List<Condition<SpanConditionType>> Conditions { get; set; }
    }

    public enum SpanConditionType
    {
        InnerText,
        Visibility
    }
}
