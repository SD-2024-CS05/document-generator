using System;
using System.Collections.Generic;

namespace ShapeHandler
{
    public class Image
    {
        public string Src { get; set; }
        public string Alt { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public List<Condition<ImageConditionType>> Conditions { get; set; }
    }

    public enum ImageConditionType
    {
        Src,
        Alt,
        Width,
        Height,
        Load
    }
}
