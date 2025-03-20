using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ShapeHandler.Objects;
using System;

namespace ShapeHandler.Database
{
    internal class Neo4JSerializer : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JObject obj = new JObject();

            if (value is FlowchartNode node)
            {
                if (node is StartEndNode startEndNode)
                {
                    obj.Add("type", startEndNode.Type.ToString().ToUpper());
                    obj.Add("isStart", startEndNode.IsStart);
                }
                else if (node is PageNode pageNode)
                {
                    obj.Add("type", pageNode.Type.ToString().ToUpper());
                }
                else if (node is DecisionNode decisionNode)
                {
                    obj.Add("type", decisionNode.Type.ToString().ToUpper());
                }
                obj.Add("Label", node.Label ?? node.Id);
                if (!string.IsNullOrEmpty(node.URL))
                {
                    obj.Add("URL", node.URL);
                }
            }
            else if (value is Connection connection)
            {
                if (!string.IsNullOrEmpty(connection.Label))
                {
                    obj.Add("Label", connection.Label);
                }
                obj.Add("type", connection.Type.ToString().ToUpper());
                if (!string.IsNullOrEmpty(connection.SubmissionId))
                {
                    obj.Add("submissionId", connection.SubmissionId);
                }
                if (!string.IsNullOrEmpty(connection.URL))
                {
                    obj.Add("URL", connection.URL);
                }
                if (connection.Conditions != null)
                {
                    // turn the Conditions object into a serialized JSON string
                    obj.Add("Conditions", CreateConditionToken(connection.Conditions, serializer));
                }
            }

            obj.WriteTo(writer);
        }

        string CreateConditionToken(Conditions conditions, JsonSerializer serializer)
        {
            JObject obj = new JObject
            {
                { "NodeIds", JToken.FromObject(conditions.NodeIds) },
                { "Operator", conditions.Operator.ToString().ToUpper() }
            };
            if (conditions.InnerConditions != null)
            {
                obj.Add("InnerConditions", CreateConditionToken(conditions.InnerConditions, serializer));
            }

            return obj.ToString();
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
