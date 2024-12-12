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
        public string Url { get; set; }
        public StartEndNode(string label) : base(label, NodeType.StartEnd) { }
    }

}
