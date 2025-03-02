using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeHandler.Objects
{
    public class PageNode : FlowchartNode
    {
        public PageNode(string label) : base(label, NodeType.Page) { }

        public PageNode(Guid guid, string label) : base(guid, label, NodeType.Page) { }

    }

}
