using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeHandler
{
    public class Graph
    {
        public Dictionary<WebAction, Dictionary<WebAction, List<Condition<Enum>>>> AdjacencyList { get; set; }

        public Graph()
        {
            AdjacencyList = new Dictionary<WebAction, Dictionary<WebAction, List<Condition<Enum>>>>();
        }
    }
}
