using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ShapeHandler.Objects;
using System;
using System.Linq;

namespace ShapeHandler.Helpers
{
    internal class ConnectionSerializer : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            if (value is Connection connection)
            {
                writer.WritePropertyName("Label");
                writer.WriteValue(connection.Label);
                writer.WritePropertyName("Type");
                writer.WriteValue(connection.Type.ToString().ToUpper());
                if (!string.IsNullOrEmpty(connection.SubmissionId))
                {
                    writer.WritePropertyName("SubmissionId");
                    writer.WriteValue(connection.SubmissionId);
                }
                if (!string.IsNullOrEmpty(connection.URL))
                {
                    writer.WritePropertyName("URL");
                    writer.WriteValue(connection.URL);
                }
                if (connection.Conditions != null)
                {
                    writer.WritePropertyName("Conditions");
                    writer.WriteStartObject();

                    // need to write all inner conditions
                    var conditions = connection.Conditions;

                    while (conditions != null)
                    {
                        writer.WritePropertyName("NodeIds");
                        writer.WriteStartArray();
                        foreach (var nodeId in conditions.NodeIds)
                        {
                            writer.WriteValue(nodeId);
                        }
                        writer.WriteEndArray();

                        writer.WritePropertyName("Operator");
                        writer.WriteValue(conditions.Operator.ToString().ToUpper());

                        if (conditions.InnerConditions != null)
                        {
                            writer.WritePropertyName("InnerConditions");
                            writer.WriteStartObject();
                            conditions = conditions.InnerConditions;
                        }
                        else
                        {
                            conditions = null;
                        }
                    }

                    writer.WriteEndObject();
                }
            }
            writer.WriteEndObject();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // read the json object
            var obj = JObject.Load(reader);
            var label = obj["Label"].Value<string>();
            var type = obj["Type"].Value<string>();
            var submissionId = obj["SubmissionId"]?.Value<string>();
            var url = obj["URL"]?.Value<string>();

            var conditions = obj["Conditions"];
            Conditions condition = null;

            if (conditions != null)
            {
                var nodeIds = conditions["NodeIds"].Values<string>().ToList();
                var op = conditions["Operator"].Value<string>();

                var logicOp = (LogicalOperator)Enum.Parse(typeof(LogicalOperator), op);

                condition = new Conditions(logicOp, nodeIds);
                var innerConditions = conditions["InnerConditions"];

                while (innerConditions != null)
                {
                    var innerNodeIds = innerConditions["NodeIds"].Values<string>().ToList();
                    var innerOp = innerConditions["Operator"].Value<string>();

                    var innerLogicOp = (LogicalOperator)Enum.Parse(typeof(LogicalOperator), innerOp);

                    condition.InnerConditions = new Conditions(innerLogicOp, innerNodeIds);
                    innerConditions = innerConditions["InnerConditions"];
                }
            }
            return obj;
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Connection);
        }
    }
}
