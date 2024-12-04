using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeHandler.Objects
{
    public class StartEndNode : FlowchartNode
    {
        public bool IsStart { get; set; } = false;
        // Adding URL
        public string url { get; set; };
        public StartEndNode(string label) : base(label, NodeType.StartEnd) { }
    }

}
