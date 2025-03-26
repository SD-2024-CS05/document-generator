using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using ShapeHandler.Helpers;
using ShapeHandler.Objects;
using System.Collections.Generic;

namespace ShapeHandler.Tests.Helpers
{
    [TestClass]
    public class ConnectionSerializerTests
    {
        private ConnectionSerializer _serializer;

        [TestInitialize]
        public void Setup()
        {
            _serializer = new ConnectionSerializer();
        }

        [TestMethod]
        public void WriteJson_ShouldSerializeConnectionCorrectly()
        {
            // Arrange
            var connection = new Connection
            {
                Label = "Test Connection",
                Type = ConnectionType.GOES_TO,
                SubmissionId = "12345",
                URL = "http://example.com",
                Conditions = new Conditions
                {
                    NodeIds = new List<string> { "Node1", "Node2" },
                    Operator = LogicalOperator.OR,
                    InnerConditions = new Conditions
                    {
                        NodeIds = new List<string> { "Node3" },
                        Operator = LogicalOperator.AND
                    }
                }
            };

            var expectedJson = "{\"Label\":\"Test Connection\",\"Type\":\"GOES_TO\",\"SubmissionId\":\"12345\",\"URL\":\"http://example.com\",\"Conditions\":{\"NodeIds\":[\"Node1\",\"Node2\"],\"Operator\":\"OR\",\"InnerConditions\":{\"NodeIds\":[\"Node3\"],\"Operator\":\"AND\"}}}";

            // Act
            var json = JsonConvert.SerializeObject(connection, _serializer);

            // Assert
            Assert.AreEqual(expectedJson, json);
        }

        [TestMethod]
        public void ReadJson_ShouldDeserializeConnectionCorrectly()
        {
            // Arrange
            var json = "{\"Label\":\"Test Connection\",\"Type\":\"GOES_TO\",\"SubmissionId\":\"12345\",\"URL\":\"http://example.com\",\"Conditions\":{\"NodeIds\":[\"Node1\",\"Node2\"],\"Operator\":\"AND\",\"InnerConditions\":{\"NodeIds\":[\"Node3\"],\"Operator\":\"OR\"}}}";

            // Act
            var connection = JsonConvert.DeserializeObject<Connection>(json, _serializer);

            // Assert
            Assert.IsNotNull(connection);
            Assert.AreEqual("Test Connection", connection.Label);
            Assert.AreEqual(ConnectionType.GOES_TO, connection.Type);
            Assert.AreEqual("12345", connection.SubmissionId);
            Assert.AreEqual("http://example.com", connection.URL);
            Assert.IsNotNull(connection.Conditions);
            Assert.AreEqual(2, connection.Conditions.NodeIds.Count);
            Assert.AreEqual(LogicalOperator.AND, connection.Conditions.Operator);
            Assert.IsNotNull(connection.Conditions.InnerConditions);
            Assert.AreEqual(1, connection.Conditions.InnerConditions.NodeIds.Count);
            Assert.AreEqual(LogicalOperator.OR, connection.Conditions.InnerConditions.Operator);
        }

        [TestMethod]
        public void WriteJson_ShouldSerializeConnectionCorrectlyDeepConditions()
        {
            // Arrange
            var connection = new Connection
            {
                Label = "Test Connection",
                Type = ConnectionType.GOES_TO,
                SubmissionId = "12345",
                URL = "http://example.com",
                Conditions = new Conditions
                {
                    NodeIds = new List<string> { "Node1", "Node2" },
                    Operator = LogicalOperator.OR,
                    InnerConditions = new Conditions
                    {
                        NodeIds = new List<string> { "Node3" },
                        Operator = LogicalOperator.AND,
                        InnerConditions = new Conditions
                        {
                            NodeIds = new List<string> { "Node4" },
                            Operator = LogicalOperator.OR
                        }
                    }
                }
            };

            var expectedJson = "{\"Label\":\"Test Connection\",\"Type\":\"GOES_TO\",\"SubmissionId\":\"12345\",\"URL\":\"http://example.com\",\"Conditions\":{\"NodeIds\":[\"Node1\",\"Node2\"],\"Operator\":\"OR\",\"InnerConditions\":{\"NodeIds\":[\"Node3\"],\"Operator\":\"AND\",\"InnerConditions\":{\"NodeIds\":[\"Node4\"],\"Operator\":\"OR\"}}}}";

            // Act
            var json = JsonConvert.SerializeObject(connection, _serializer);
            Assert.AreEqual(expectedJson, json);
        }

        [TestMethod]
        public void ReadJson_ShouldDeserializeConnectionCorrectlyDeepConditions()
        {
            // Arrange
            var json = "{\"Label\":\"Test Connection\",\"Type\":\"GOES_TO\",\"SubmissionId\":\"12345\",\"URL\":\"http://example.com\",\"Conditions\":{\"NodeIds\":[\"Node1\",\"Node2\"],\"Operator\":\"OR\",\"InnerConditions\":{\"NodeIds\":[\"Node3\"],\"Operator\":\"AND\",\"InnerConditions\":{\"NodeIds\":[\"Node4\"],\"Operator\":\"OR\"}}}}";
            var connection = new Connection
            {
                Label = "Test Connection",
                Type = ConnectionType.GOES_TO,
                SubmissionId = "12345",
                URL = "http://example.com",
                Conditions = new Conditions
                {
                    NodeIds = new List<string> { "Node1", "Node2" },
                    Operator = LogicalOperator.OR,
                    InnerConditions = new Conditions
                    {
                        NodeIds = new List<string> { "Node3" },
                        Operator = LogicalOperator.AND,
                        InnerConditions = new Conditions
                        {
                            NodeIds = new List<string> { "Node4" },
                            Operator = LogicalOperator.OR
                        }
                    }
                }
            };

            // Act
            var deserializedConnection = JsonConvert.DeserializeObject<Connection>(json, _serializer);

            // Assert
            Assert.IsNotNull(deserializedConnection);
            Assert.AreEqual(connection.Label, deserializedConnection.Label);
            Assert.AreEqual(connection.Type, deserializedConnection.Type);
            Assert.AreEqual(connection.SubmissionId, deserializedConnection.SubmissionId);
            Assert.AreEqual(connection.URL, deserializedConnection.URL);
            Assert.IsNotNull(deserializedConnection.Conditions);
            Assert.AreEqual(connection.Conditions.NodeIds.Count, deserializedConnection.Conditions.NodeIds.Count);
            Assert.AreEqual(connection.Conditions.Operator, deserializedConnection.Conditions.Operator);
            Assert.IsNotNull(deserializedConnection.Conditions.InnerConditions);
            Assert.AreEqual(connection.Conditions.InnerConditions.NodeIds.Count, deserializedConnection.Conditions.InnerConditions.NodeIds.Count);
            Assert.AreEqual(connection.Conditions.InnerConditions.Operator, deserializedConnection.Conditions.InnerConditions.Operator);
            Assert.IsNotNull(deserializedConnection.Conditions.InnerConditions.InnerConditions);
            Assert.AreEqual(connection.Conditions.InnerConditions.InnerConditions.NodeIds.Count, deserializedConnection.Conditions.InnerConditions.InnerConditions.NodeIds.Count);
            Assert.AreEqual(connection.Conditions.InnerConditions.InnerConditions.Operator, deserializedConnection.Conditions.InnerConditions.InnerConditions.Operator);
        }
    }
}
