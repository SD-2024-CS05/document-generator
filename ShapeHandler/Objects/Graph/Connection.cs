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
        public List<Condition> Conditions { get; set; }

        public Connection(string label)
        {
            Label = label;
            Conditions = new List<Condition>();
        }

        public Connection(string label, List<Condition> conditions)
        {
            Label = label;
            Conditions = conditions;
        }
    }

}
