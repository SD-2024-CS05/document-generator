using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeHandler.Objects
{
    
    // adding url
    public class PageNode : FlowchartNode
    {
        public string Url { get; set; }
        public PageNode(string label) : base(label, NodeType.Page) { }
    }

}
