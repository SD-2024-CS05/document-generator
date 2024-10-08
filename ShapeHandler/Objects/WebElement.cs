using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ShapeHandler
{
    [JsonConverter(typeof(WebElementConverter))]
    public abstract class WebElement
    {
        public string Id { get; set; }
        public string[] Classes { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            WebElement webAction = (WebElement)obj;
            return Id == webAction.Id && Classes.SequenceEqual(webAction.Classes);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Classes);
        }

        public static WebElement FromXElement(XElement element)
        {
            return null;
        }
    }

    public class WebElementConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(WebElement);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jsonObject = JObject.Load(reader);
            var webAction = default(WebElement);

            // handle the different types of web actions
            if (jsonObject != null)
            {
                if (jsonObject["actionType"] != null)
                {
                    string actionType = jsonObject["actionType"].Value<string>();
                    switch (actionType)
                    {
                        case "button":
                            webAction = new Button();
                            break;
                        case "input":
                            webAction = new Input();
                            break;
                        case "span":
                            webAction = new Span();
                            break;
                        case "img":
                            webAction = new Image();
                            break;
                        case "a":
                            webAction = new Anchor();
                            break;
                        case "select":
                            webAction = new Select();
                            break;
                        default:
                            throw new InvalidCastException("Invalid action type");
                    }
                }
            }

            serializer.Populate(jsonObject.CreateReader(), webAction);
            return webAction;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
