using System;

namespace ShapeHandler.Objects
{
    public class ProcessNode : FlowchartNode
    {
        public ProcessNode(string label, bool isBackground = false) : base(label, isBackground ? NodeType.BackgroundProcess : NodeType.UserProcess)
        {
        }

        public ProcessNode(Guid guid, string label, bool isBackground = false) : base(guid, label, isBackground ? NodeType.BackgroundProcess : NodeType.UserProcess)
        {
        }
    }
}
