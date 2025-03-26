using AngleSharp.Html.Dom;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ShapeHandler.Objects;
using System;
using System.Collections.Generic;

namespace ShapeHandler.Helpers
{
    public class FlowchartNodeSerializer : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            HtmlElementSerializer htmlElementSerializer = new HtmlElementSerializer();
            writer.WriteStartObject();
            if (value is FlowchartNode node)
            {
                writer.WritePropertyName("Id");
                writer.WriteValue(node.Id);
                writer.WritePropertyName("Type");
                writer.WriteValue(node.Type.ToString());
                if (node is StartEndNode startEndNode)
                {
                    writer.WritePropertyName("isStart");
                    writer.WriteValue(startEndNode.IsStart);
                }
                else if (node is HtmlNode htmlNode)
                {
                    writer.WritePropertyName("Element");
                    htmlElementSerializer.WriteJson(writer, htmlNode.Element, serializer);
                }
                else if (node is DataInputNode diNode)
                {
                    writer.WritePropertyName("DataInputNodes");
                    writer.WriteStartArray();
                    foreach (HtmlNode hNode in diNode.DataInputNodes)
                    {
                        WriteJson(writer, hNode, serializer);
                    }
                    writer.WriteEndArray();
                }
                else if (node is DecisionNode decisionNode)
                {
                    writer.WritePropertyName("SubmissionNodes");
                    writer.WriteStartArray();
                    foreach (HtmlNode hNode in decisionNode.SubmissionNodes)
                    {
                        WriteJson(writer, hNode, serializer);
                    }
                    writer.WriteEndArray();
                }

                writer.WritePropertyName("Label");
                writer.WriteValue(node.Label ?? node.Id);

                if (!string.IsNullOrEmpty(node.URL))
                {
                    writer.WritePropertyName("URL");
                    writer.WriteValue(node.URL);
                }
            }
            writer.WriteEndObject();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jsonObject = JObject.Load(reader);

            string id = jsonObject["Id"]?.ToString();
            string type = jsonObject["Type"]?.ToString();
            string label = jsonObject["Label"]?.ToString();
            string url = jsonObject["URL"]?.ToString();

            FlowchartNode node = null;

            if (!Guid.TryParse(id, out Guid guid))
            {
                throw new Exception("Invalid guid");
            }

            if (!NodeType.TryParse(type, out NodeType nodeType))
            {
                throw new Exception("Unknown node type");
            }

            switch (nodeType)
            {
                case NodeType.StartEnd:
                    bool isStart = jsonObject["isStart"]?.ToObject<bool>() ?? false;
                    node = new StartEndNode(guid, label, isStart);
                    break;
                case NodeType.Decision:
                    List<HtmlNode> submissionNodes = new List<HtmlNode>();
                    foreach (JToken submissionHtmlNode in jsonObject["SubmissionNodes"])
                    {
                        submissionNodes.Add(ParseHtmlNode(submissionHtmlNode));
                    }
                    node = new DecisionNode(guid, label, submissionNodes);
                    break;
                case NodeType.DataInput:
                    List<HtmlNode> dataInputNodes = new List<HtmlNode>();
                    foreach (JToken dataInputNode in jsonObject["DataInputNodes"])
                    {
                        dataInputNodes.Add(ParseHtmlNode(dataInputNode));
                    }
                    node = new DataInputNode(guid, label, dataInputNodes);
                    break;
                case NodeType.Page:
                    node = new PageNode(guid, label);
                    break;
                case NodeType.BackgroundProcess:
                    node = new ProcessNode(guid, label, true);
                    break;
                case NodeType.UserProcess:
                    node = new ProcessNode(guid, label, false);
                    break;
                case NodeType.HtmlElement:
                case NodeType.Button:
                case NodeType.Input:
                case NodeType.Select:
                case NodeType.Anchor:
                case NodeType.Image:
                    IHtmlElement element = JsonConvert.DeserializeObject<IHtmlElement>(jsonObject["Element"].ToString(), new HtmlElementSerializer());
                    node = new HtmlNode(guid, label, element);
                    break;
                default:
                    throw new Exception("Unknown node type");
            }

            if (node != null)
            {
                node.Label = label ?? id;
                node.URL = url;
            }

            return node;
        }

        private HtmlNode ParseHtmlNode(JToken token)
        {
            IHtmlElement e = JsonConvert.DeserializeObject<IHtmlElement>(token["Element"].ToString(), new HtmlElementSerializer());
            string nodeId = token["Id"]?.ToString();
            string nodeLabel = token["Label"]?.ToString();
            if (!NodeType.TryParse(token["Type"]?.ToString(), out NodeType nodeType))
            {
                throw new Exception("Unknown node type");
            }
            Guid.TryParse(nodeId, out Guid nodeGuid);
            return new HtmlNode(nodeGuid, nodeLabel, e, nodeType);
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(FlowchartNode).IsAssignableFrom(objectType);
        }
    }
}
