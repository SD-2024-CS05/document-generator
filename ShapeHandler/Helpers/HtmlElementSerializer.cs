using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using Microsoft.Extensions.Primitives;
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
                writer.WritePropertyName("\"\"tagName\"\"");
                writer.WriteValue("\"\"" + element.TagName + "\"\"");
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

        /// <summary>
        /// Why can't we use a JSON serialization library?
        /// Because VBA formulas and their format constraints.
        /// So, here is my own.
        /// </summary>
        /// <param name="value">The HTML element</param>
        /// <returns>JSON object</returns>
        public static string WriteJson(object value)
        {
            StringBuilder writer = new StringBuilder("[");
            if (value is IHtmlElement element)
            {
                writer.Append("{");
                writer.Append("{\"\"tagName\"\": \"\"" + element.TagName + "\"\", ");
                writer.Append("\"\"id\"\": \"\"" + element.Id + "\"\", ");
                writer.Append("\"\"classList\"\": [");
                foreach (var className in element.ClassList)
                {
                    writer.Append("\"\"" + className + "\"\", ");
                }
                writer.Append("], ");
                writer.Append("\"\"attributes\"\": {");
                foreach (var attribute in element.Attributes)
                {
                    writer.Append("\"\"" + attribute.Name + "\"\": ");
                    writer.Append("\"\"" + attribute.Value + "\"\", ");
                }
                writer.Append("}");
                writer.Append("}");
            }
            writer.Append(']');
            return writer.ToString();
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
