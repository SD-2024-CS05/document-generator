﻿using AngleSharp.Html.Dom;
using System;
using System.Text;

namespace ShapeHandler.Objects
{
    public class HtmlNode : FlowchartNode
    {
        public IHtmlElement Element { get; set; }

        public HtmlNode(string label, NodeType type = NodeType.HtmlElement) : base(label, type)
        {

        }

        public HtmlNode(string label, IHtmlElement element, NodeType type = NodeType.HtmlElement) : base(label, type)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }
            Element = element;
        }

        public HtmlNode(Guid guid, string label, IHtmlElement element, NodeType type = NodeType.HtmlElement) : base(guid, label, type)
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
            builder.Append($"id: \"{Id}\", ");
            builder.Append($"type: \"{Type.ToString().ToUpper()}\", ");
            builder.Append($"label: \"{Label}\", ");
            builder.Append(
                $"element: {{ ");
            builder.Append(
                $"id: \"{Element.Id}\", ");
            builder.Append($"tag: \"{Element.TagName}\", ");
            builder.Append($"attributes: {{");
            foreach (AngleSharp.Dom.IAttr attribute in Element.Attributes)
            {
                builder.Append($"{attribute.Name}: \"{attribute.Value}\", ");
            }
            builder.Append($"}}");
            builder.Append($"}}");

            return builder.ToString();
        }
    }

}
