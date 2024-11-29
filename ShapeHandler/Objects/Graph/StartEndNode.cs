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

        public StartEndNode(string label, string url) : base(label, NodeType.StartEnd) { }
    }

}
