using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeHandler.Objects
{
    public class ProcessNode : FlowchartNode
    {
        public ProcessNode(string label, bool isBackground = false): base(label, isBackground ? NodeType.BackgroundProcess : NodeType.UserProcess)
        {
            Label = label;
        }
    }
}
