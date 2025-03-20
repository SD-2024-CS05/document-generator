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
                    Conditions conditions = connection.Conditions;

                    while (conditions != null)
                    {
                        writer.WritePropertyName("NodeIds");
                        writer.WriteStartArray();
                        foreach (string nodeId in conditions.NodeIds)
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
            JObject obj = JObject.Load(reader);
            string label = obj["Label"].Value<string>();
            string type = obj["Type"].Value<string>();
            string submissionId = obj["SubmissionId"]?.Value<string>();
            string url = obj["URL"]?.Value<string>();
            JToken conditions = obj["Conditions"];

            bool success = ConnectionType.TryParse(type, true, out ConnectionType conType);

            if (!success)
            {
                throw new Exception("Unknown connection type");
            }

            Conditions condition = null;

            if (conditions != null)
            {
                System.Collections.Generic.List<string> nodeIds = conditions["NodeIds"].Values<string>().ToList();
                string op = conditions["Operator"].Value<string>();

                condition = CreateCondition(nodeIds, op);

                JToken innerConditions = conditions["InnerConditions"];
                Conditions currentCondition = condition;

                while (innerConditions != null)
                {
                    System.Collections.Generic.List<string> innerNodeIds = innerConditions["NodeIds"].Values<string>().ToList();
                    string innerOp = innerConditions["Operator"].Value<string>();

                    Conditions newCondition = CreateCondition(innerNodeIds, innerOp);
                    currentCondition.InnerConditions = newCondition;
                    currentCondition = newCondition;

                    innerConditions = innerConditions["InnerConditions"];
                }
            }

            Connection connection = new Connection
            {
                Label = label,
                Type = conType,
                SubmissionId = submissionId,
                URL = url,
                Conditions = condition
            };

            return connection;
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Connection);
        }

        private Conditions CreateCondition(System.Collections.Generic.List<string> nodeIds, string op)
        {
            bool success = Enum.TryParse<LogicalOperator>(op, true, out LogicalOperator logicOp);

            if (!success)
            {
                throw new Exception("Unknown logical operator");
            }

            return new Conditions(logicOp, nodeIds);
        }
    }
}
