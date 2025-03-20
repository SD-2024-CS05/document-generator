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
            var json = JsonConvert.SerializeObject(connection, new ConnectionSerializer());

            // Assert
            Assert.AreEqual(expectedJson, json);
        }

        [TestMethod]
        public void ReadJson_ShouldDeserializeConnectionCorrectly()
        {
            // Arrange
            var json = "{\"Label\":\"Test Connection\",\"Type\":\"GOES_TO\",\"SubmissionId\":\"12345\",\"URL\":\"http://example.com\",\"Conditions\":{\"NodeIds\":[\"Node1\",\"Node2\"],\"Operator\":\"AND\",\"InnerConditions\":{\"NodeIds\":[\"Node3\"],\"Operator\":\"OR\"}}}";

            // Act
            var connection = JsonConvert.DeserializeObject<Connection>(json, new ConnectionSerializer());

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
    }
}
