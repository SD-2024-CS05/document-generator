using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ShapeHandler.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeHandler.Database
{
    internal class Neo4JSerializer : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JObject obj = new JObject();

            if (value is FlowchartNode node)
            {
                obj["id"] = node.Id;
                obj["type"] = node.Type.ToString().ToUpper();

                if (node is HtmlNode htmlNode)
                {
                    obj["element"] = JObject.FromObject(htmlNode.Element, serializer);
                }
                else if (node is DecisionNode decisionNode)
                {
                    JArray validationElementsArray = new JArray();
                    foreach (var element in decisionNode.ValidationElements)
                    {
                        validationElementsArray.Add(JObject.FromObject(element, serializer));
                    }
                    obj["validationElements"] = validationElementsArray;
                }
            }
            else if (value is Connection connection)
            {
                obj["label"] = connection.Label;
                obj["type"] = connection.Type.ToString().ToUpper();
                JArray conditionsArray = new JArray();
                foreach (var condition in connection.Conditions)
                {
                    JObject conditionObj = new JObject
                    {
                        ["elementType"] = condition.ElementType,
                        ["attribute"] = condition.Attribute,
                        ["attributeValue"] = condition.AttributeValue,
                        ["isActive"] = condition.IsActive,
                        ["nodeId"] = condition.NodeId
                    };
                    conditionsArray.Add(conditionObj);
                }
                obj["conditions"] = conditionsArray;
            }

            obj.WriteTo(writer);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException("Deserialization is not implemented for Neo4JSerializer.");
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(FlowchartNode).IsAssignableFrom(objectType) || typeof(Connection).IsAssignableFrom(objectType);
        }
    }
}
