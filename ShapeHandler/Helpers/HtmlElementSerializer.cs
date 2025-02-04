using AngleSharp.Html.Dom;
using Newtonsoft.Json;
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
            writer.WriteStartArray();
            if (value is IHtmlElement element)
            {
                writer.WriteStartObject();
                writer.WritePropertyName("tagName");
                writer.WriteValue(element.TagName);
                writer.WritePropertyName("id");
                writer.WriteValue(element.Id);
                writer.WritePropertyName("classList");
                writer.WriteStartArray();
                foreach (var className in element.ClassList)
                {
                    writer.WriteValue(className);
                }
                writer.WriteEndArray();
                writer.WritePropertyName("attributes");
                writer.WriteStartObject();
                foreach (var attribute in element.Attributes)
                {
                    writer.WritePropertyName(attribute.Name);
                    writer.WriteValue(attribute.Value);
                }
                writer.WriteEndObject();
                writer.WriteEndObject();
            }
            writer.WriteEndArray();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException("Deserialization is not implemented for HtmlElementSerializer.");
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(IHtmlElement).IsAssignableFrom(objectType);
        }
    }
}
