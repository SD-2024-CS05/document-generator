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

        public StartEndNode(string label) : base(label, NodeType.StartEnd) { }

        public StartEndNode(string label, bool isStart) : base(label, NodeType.StartEnd)
        {
            IsStart = isStart;
        }
        public StartEndNode(Guid guid, string label, bool isStart) : base(guid, label, NodeType.StartEnd)
        {
            IsStart = isStart;
        }
    }

}
