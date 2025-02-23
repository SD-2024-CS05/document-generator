using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                var obj = JObject.Load(reader);
                var html = obj["OuterHtml"].Value<string>();
                var parser = new HtmlParser();
                var element = parser.ParseFragment(html, null).First() as IHtmlElement;

                var inputElements = element.GetElementsByTagName("input");
                var selectElements = element.GetElementsByTagName("select");
                var anchorElements = element.GetElementsByTagName("a");
                var imageElements = element.GetElementsByTagName("img");
                var buttonElements = element.GetElementsByTagName("button");
                if (inputElements.Any())
                {
                    return inputElements.FirstOrDefault() as IHtmlInputElement;
                }
                else if (anchorElements.Any())
                {
                    return anchorElements.FirstOrDefault() as IHtmlAnchorElement;
                }
                else if (imageElements.Any())
                {
                    return imageElements.FirstOrDefault() as IHtmlImageElement;
                }
                else if (selectElements.Any())
                {
                    return selectElements.FirstOrDefault() as IHtmlSelectElement;
                }
                else if (buttonElements.Any())
                {
                    return buttonElements.FirstOrDefault() as IHtmlButtonElement;
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
