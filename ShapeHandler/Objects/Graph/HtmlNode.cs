﻿using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Io;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeHandler.Objects
{
    public class HtmlNode : FlowchartNode
    {
        public IHtmlElement Element { get; set; }

        public HtmlNode(string label, IHtmlElement element) : base(label, NodeType.HtmlElement)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }
            Element = element;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (!(obj is HtmlNode otherNode))
            {
                return false;
            }

            // make sure that the id is the same that is all that's needed
            return Element.Id == otherNode.Element.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            // return a string that prints all information regarding the Element in a way that neo4j can write it
            StringBuilder builder = new StringBuilder();
            builder.Append($"{{");
            builder.Append($"id: \"{Element.Id}\", ");
            builder.Append($"tag: \"{Element.TagName}\", ");
            builder.Append($"attributes: {{");
            foreach (var attribute in Element.Attributes)
            {
                builder.Append($"{attribute.Name}: \"{attribute.Value}\", ");
            }
            builder.Append($"}}");
            builder.Append($"}}");

            return builder.ToString();
        }
    }

}
