using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeHandler.Objects
{
    public class Connection
    {
        public string Label { get; set; }
        public string Behavior { get; set; } // Action or meaning of the connection
        public FlowchartNode Source { get; set; }
        public FlowchartNode Target { get; set; }

        public Connection(string label, string behavior, FlowchartNode source, FlowchartNode target)
        {
            Label = label;
            Behavior = behavior;
            Source = source;
            Target = target;
        }
    }

}
