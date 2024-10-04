using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeHandler
{
    public class Condition<T>
    {
        public T Type { get; set; }
        public bool State { get; set; }
        public string MatchValue { get; set; }
    }
}
