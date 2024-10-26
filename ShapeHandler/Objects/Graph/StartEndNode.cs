using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeHandler.Objects
{
    public class StartEndNode : FlowchartNode
    {
        public StartEndNode(string id) : base(id, NodeType.StartEnd) { }
    }

}
