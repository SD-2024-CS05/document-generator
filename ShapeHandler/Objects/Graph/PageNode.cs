using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeHandler.Objects
{
    public class PageNode : FlowchartNode
    {
        public PageNode(string id) : base(id, NodeType.Page) { }
    }

}
