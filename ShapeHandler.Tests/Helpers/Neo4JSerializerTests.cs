using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ShapeHandler.Database;
using ShapeHandler.Objects;
using System;
using System.IO;

namespace ShapeHandler.Tests.Helpers
{
    [TestClass]
    public class Neo4JSerializerTests
    {
        private Neo4JSerializer _serializer;

        [TestInitialize]
        public void TestInitialize()
        {
            _serializer = new Neo4JSerializer();
        }

        [TestMethod]
        public void WriteJson_StartEndNode_SerializesCorrectly()
        {
            var node = new StartEndNode(Guid.NewGuid(), "Start Node", true)
            {
                URL = "http://example.com"
            };

            var json = SerializeObject(node);

            var expectedJson = NormalizeJson(JObject.FromObject(new
            {
                type = "STARTEND",
                isStart = true,
                Label = "Start Node",
                URL = "http://example.com"
            }).ToString());

            Assert.AreEqual(expectedJson, json);
        }

        [TestMethod]
        public void WriteJson_PageNode_SerializesCorrectly()
        {
            var node = new PageNode(Guid.NewGuid(), "Page Node")
            {
                URL = "http://example.com"
            };

            var json = SerializeObject(node);

            var expectedJson = NormalizeJson(JObject.FromObject(new
            {
                type = "PAGE",
                Label = "Page Node",
                URL = "http://example.com"
            }).ToString());

            Assert.AreEqual(expectedJson, json);
        }

        [TestMethod]
        public void WriteJson_DecisionNode_SerializesCorrectly()
        {
            var node = new DecisionNode("Decision Node")
            {
                URL = "http://example.com"
            };

            var json = SerializeObject(node);

            var expectedJson = NormalizeJson(JObject.FromObject(new
            {
                type = "DECISION",
                Label = "Decision Node",
                URL = "http://example.com"
            }).ToString());

            Assert.AreEqual(expectedJson, json);
        }

        [TestMethod]
        public void WriteJson_Connection_SerializesCorrectly()
        {
            var connection = new Connection
            {
                Type = ConnectionType.GOES_TO,
                Label = "Connection Label",
                SubmissionId = "123",
                URL = "http://example.com",
                Conditions = new Conditions()
                {
                    NodeIds = new System.Collections.Generic.List<string> { "Node1", "Node2" },
                    Operator = LogicalOperator.OR,
                    InnerConditions = new Conditions()
                    {
                        NodeIds = new System.Collections.Generic.List<string> { "Node3" },
                        Operator = LogicalOperator.AND
                    }
                }
            };

            var json = SerializeObject(connection);

            var expectedJson = NormalizeJson(JObject.FromObject(new
            {
                Label = "Connection Label",
                type = "GOES_TO",
                submissionId = "123",
                URL = "http://example.com",
                Conditions = JObject.FromObject(new
                {
                    NodeIds = new System.Collections.Generic.List<string> { "Node1", "Node2" },
                    Operator = "OR",
                    InnerConditions = JObject.FromObject(new
                    {
                        NodeIds = new System.Collections.Generic.List<string> { "Node3" },
                        Operator = "AND"
                    }).ToString()
                }).ToString()
            }).ToString());

            Assert.AreEqual(expectedJson, json);
        }

        private string SerializeObject(object obj)
        {
            return NormalizeJson(JsonConvert.SerializeObject(obj, _serializer));
        }

        private string NormalizeJson(string json)
        {
            return JObject.Parse(json).ToString(Formatting.Indented);
        }
    }
}
