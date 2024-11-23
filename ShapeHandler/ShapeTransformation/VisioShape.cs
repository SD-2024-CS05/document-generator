using System.Collections.Generic;
using ShapeHandler.Objects;

namespace ShapeHandler.ShapeTransformation
{
    public class VisioShape
    {
        public string Name { get; set; }
        public NodeType Type { get; set; }
        public IDictionary<string, string> ShapeData { get; set; }
    }
}