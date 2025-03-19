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

            NodeType.TryParse(type, true, out NodeType nodeType);

            FlowchartNode node = null;
            Guid.TryParse(id, out Guid guid);

            switch (nodeType)
            {
                case NodeType.StartEnd:
                    bool isStart = jsonObject["isStart"]?.ToObject<bool>() ?? false;
                    node = new StartEndNode(guid, label, isStart);
                    break;
                case NodeType.Decision:
                    List<HtmlNode> submissionNodes = new List<HtmlNode>();
                    foreach (JToken submissionNode in jsonObject["SubmissionNodes"])
                    {
                        IHtmlElement e = JsonConvert.DeserializeObject<IHtmlElement>(submissionNode["Element"].ToString(), new HtmlElementSerializer());
                        string subId = submissionNode["Id"]?.ToString();
                        string subLabel = submissionNode["Label"]?.ToString();
                        NodeType.TryParse(submissionNode["Type"]?.ToString(), out NodeType subType);
                        Guid.TryParse(subId, out Guid subGuid);

                        submissionNodes.Add(new HtmlNode(subGuid, subLabel, e, subType));
                    }
                    node = new DecisionNode(guid, label, submissionNodes);
                    break;
                case NodeType.DataInput:
                    List<HtmlNode> dataInputNodes = new List<HtmlNode>();
                    foreach (JToken dataInputNode in jsonObject["DataInputNodes"])
                    {
                        IHtmlElement e = JsonConvert.DeserializeObject<IHtmlElement>(dataInputNode["Element"].ToString(), new HtmlElementSerializer());
                        string diId = dataInputNode["Id"]?.ToString();
                        string diLabel = dataInputNode["Label"]?.ToString();
                        NodeType.TryParse(dataInputNode["Type"]?.ToString(), out NodeType diType);
                        Guid.TryParse(diId, out Guid diGuid);

                        dataInputNodes.Add(new HtmlNode(diGuid, diLabel, e, diType));
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

        public override bool CanConvert(Type objectType)
        {
            return typeof(FlowchartNode).IsAssignableFrom(objectType);
        }
    }
}
