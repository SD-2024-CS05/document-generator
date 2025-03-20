using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShapeHandler.Helpers
{
    internal class HtmlElementSerializer : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            if (value is IHtmlElement element)
            {
                // just write out the outer element
                writer.WritePropertyName("OuterHtml");
                writer.WriteValue(element.OuterHtml);
            }
            writer.WriteEndObject();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            try
            {
                JObject obj = JObject.Load(reader);
                string html = obj["OuterHtml"].Value<string>();
                HtmlParser parser = new HtmlParser();
                IHtmlElement element = parser.ParseFragment(html, null).First() as IHtmlElement;

                Dictionary<string, Func<IHtmlElement, IHtmlElement>> tagMappings = new Dictionary<string, Func<IHtmlElement, IHtmlElement>>
                    {
                        { "input", e => e.FindChild<IHtmlInputElement>() },
                        { "select", e => e.FindChild<IHtmlSelectElement>() },
                        { "a", e => e.FindChild<IHtmlAnchorElement>() },
                        { "img", e => e.FindChild<IHtmlImageElement>() },
                        { "button", e => e.FindChild<IHtmlButtonElement>() }
                    };

                var tag = element.TagName.ToLower();

                if (tagMappings.ContainsKey(tag))
                {
                    element = tagMappings[tag](element);
                }
                else
                {
                    var children = element.Children;

                    element = children.FirstOrDefault(child =>
                        child.TagName.ToLower() == "body") as IHtmlElement;

                    element = element.Children.FirstOrDefault() as IHtmlElement;

                    if (element == null)
                    {
                        throw new JsonSerializationException("Unable to deserialize the html element");
                    }
                }

                return element;
            }
            catch (Exception)
            {
                throw new JsonSerializationException("Unable to deserialize the html element");
            }
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(IHtmlElement).IsAssignableFrom(objectType);
        }
    }
}
