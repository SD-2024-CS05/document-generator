using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ShapeHandler.Objects
{
    public abstract class FlowchartNode
    {
        public string Id { get; set; }
        public NodeType Type { get; set; }
        
        protected FlowchartNode(string id, NodeType type)
        {
            Id = id;
            Type = type;
        }

    }

}
