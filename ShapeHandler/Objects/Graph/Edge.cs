using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ShapeHandler.Objects
{
    public class Edge
    {
        public string Id { get; set; }
        public HtmlNode Source { get; set; }
        public HtmlNode Target { get; set; }
        public string Label { get; set; }

        public Edge(HtmlNode source, HtmlNode target, string label = "")
        {
            Id = Guid.NewGuid().ToString();
            Source = source;
            Target = target;
            Label = label;
        }
    }

}
