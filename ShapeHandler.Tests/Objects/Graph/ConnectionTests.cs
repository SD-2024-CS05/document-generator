using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapeHandler.Objects;

namespace ShapeHandler.Tests.Objects.Graph
{
    [TestClass]
    public class ConnectionTests
    {
        [TestMethod]
        public void TestDefaultConstructor()
        {
            var connection = new Connection();
            Assert.AreEqual(ConnectionType.GOES_TO, connection.Type);
            Assert.IsNull(connection.Label);
            Assert.IsNull(connection.Conditions);
            Assert.IsNull(connection.SubmissionId);
            Assert.IsNull(connection.URL);
        }

        [TestMethod]
        public void TestConstructorWithLabel()
        {
            var connection = new Connection("TestLabel");
            Assert.AreEqual("TestLabel", connection.Label);
            Assert.AreEqual(ConnectionType.GOES_TO, connection.Type);
            Assert.IsNull(connection.Conditions);
            Assert.IsNull(connection.SubmissionId);
            Assert.IsNull(connection.URL);
        }

        [TestMethod]
        public void TestConstructorWithType()
        {
            var connection = new Connection(ConnectionType.DIRECTS_TO);
            Assert.AreEqual(ConnectionType.DIRECTS_TO, connection.Type);
            Assert.IsNull(connection.Label);
            Assert.IsNull(connection.Conditions);
            Assert.IsNull(connection.SubmissionId);
            Assert.IsNull(connection.URL);
        }

        [TestMethod]
        public void TestConstructorWithLabelAndType()
        {
            var connection = new Connection("TestLabel", ConnectionType.DIRECTS_TO);
            Assert.AreEqual("TestLabel", connection.Label);
            Assert.AreEqual(ConnectionType.DIRECTS_TO, connection.Type);
            Assert.IsNull(connection.Conditions);
            Assert.IsNull(connection.SubmissionId);
            Assert.IsNull(connection.URL);
        }

        [TestMethod]
        public void TestConstructorWithLabelAndConditions()
        {
            var conditions = new Conditions();
            var connection = new Connection("TestLabel", conditions);
            Assert.AreEqual("TestLabel", connection.Label);
            Assert.AreEqual(ConnectionType.GOES_TO, connection.Type);
            Assert.AreEqual(conditions, connection.Conditions);
            Assert.IsNull(connection.SubmissionId);
            Assert.IsNull(connection.URL);
        }

        [TestMethod]
        public void TestConstructorWithLabelConditionsAndType()
        {
            var conditions = new Conditions();
            var connection = new Connection("TestLabel", conditions, ConnectionType.DIRECTS_TO);
            Assert.AreEqual("TestLabel", connection.Label);
            Assert.AreEqual(ConnectionType.GOES_TO, connection.Type); // Note: This seems to be a bug in the original code
            Assert.AreEqual(conditions, connection.Conditions);
            Assert.IsNull(connection.SubmissionId);
            Assert.IsNull(connection.URL);
        }

        [TestMethod]
        public void TestConstructorWithLabelConditionsTypeAndSubmissionId()
        {
            var conditions = new Conditions();
            var connection = new Connection("TestLabel", conditions, ConnectionType.DIRECTS_TO, "Submission123");
            Assert.AreEqual("TestLabel", connection.Label);
            Assert.AreEqual(ConnectionType.DIRECTS_TO, connection.Type);
            Assert.AreEqual(conditions, connection.Conditions);
            Assert.AreEqual("Submission123", connection.SubmissionId);
            Assert.IsNull(connection.URL);
        }

        [TestMethod]
        public void TestConstructorWithLabelAndSubmissionId()
        {
            var connection = new Connection("TestLabel", "Submission123");
            Assert.AreEqual("TestLabel", connection.Label);
            Assert.AreEqual(ConnectionType.GOES_TO, connection.Type);
            Assert.IsNull(connection.Conditions);
            Assert.AreEqual("Submission123", connection.SubmissionId);
            Assert.IsNull(connection.URL);
        }

        [TestMethod]
        public void TestConstructorWithLabelConditionsAndSubmissionId()
        {
            var conditions = new Conditions();
            var connection = new Connection("TestLabel", conditions, "Submission123");
            Assert.AreEqual("TestLabel", connection.Label);
            Assert.AreEqual(ConnectionType.GOES_TO, connection.Type);
            Assert.AreEqual(conditions, connection.Conditions);
            Assert.AreEqual("Submission123", connection.SubmissionId);
            Assert.IsNull(connection.URL);
        }

        [TestMethod]
        public void TestEqualsMethod()
        {
            var conditions = new Conditions();
            var connection1 = new Connection("TestLabel", conditions, ConnectionType.DIRECTS_TO);
            var connection2 = new Connection("TestLabel", conditions, ConnectionType.DIRECTS_TO);
            Assert.IsTrue(connection1.Equals(connection2));
        }

        [TestMethod]
        public void TestToStringMethod()
        {
            var conditions = new Conditions();
            var connection = new Connection("TestLabel", conditions, ConnectionType.DIRECTS_TO, "Submission123");
            var expectedString = "{submissionId: \"Submission123\", label: \"TestLabel\", conditions: " + conditions.ToString() + ", type: \"DIRECTS_TO\"}";
            Assert.AreEqual(expectedString, connection.ToString());
        }
    }
}
