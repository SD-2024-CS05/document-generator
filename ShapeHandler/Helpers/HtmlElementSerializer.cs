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

                Dictionary<string, Type> tagMappings = new Dictionary<string, Type>
                {
                    { "input", typeof(IHtmlInputElement) },
                    { "select", typeof(IHtmlSelectElement) },
                    { "a", typeof(IHtmlAnchorElement) },
                    { "img", typeof(IHtmlImageElement) },
                    { "button", typeof(IHtmlButtonElement) }
                };

                foreach (KeyValuePair<string, Type> tagMapping in tagMappings)
                {
                    AngleSharp.Dom.IHtmlCollection<AngleSharp.Dom.IElement> elements = element.GetElementsByTagName(tagMapping.Key);
                    if (elements.Any())
                    {
                        return elements.FirstOrDefault();
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
