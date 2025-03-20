using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapeHandler.Objects;
using System.Collections.Generic;

namespace ShapeHandler.Tests.Objects.Graph
{
    [TestClass]
    public class ConditionsTests
    {
        [TestMethod]
        public void TestDefaultConstructor()
        {
            var conditions = new Conditions();
            Assert.AreEqual(LogicalOperator.AND, conditions.Operator);
            Assert.IsNotNull(conditions.NodeIds);
            Assert.AreEqual(0, conditions.NodeIds.Count);
            Assert.IsNull(conditions.InnerConditions);
        }

        [TestMethod]
        public void TestConstructorWithOperator()
        {
            var conditions = new Conditions(LogicalOperator.OR);
            Assert.AreEqual(LogicalOperator.OR, conditions.Operator);
            Assert.IsNotNull(conditions.NodeIds);
            Assert.AreEqual(0, conditions.NodeIds.Count);
            Assert.IsNull(conditions.InnerConditions);
        }

        [TestMethod]
        public void TestConstructorWithOperatorAndNodeIds()
        {
            var nodeIds = new List<string> { "node1", "node2" };
            var conditions = new Conditions(LogicalOperator.NOT, nodeIds);
            Assert.AreEqual(LogicalOperator.NOT, conditions.Operator);
            Assert.AreEqual(nodeIds, conditions.NodeIds);
            Assert.IsNull(conditions.InnerConditions);
        }

        [TestMethod]
        public void TestToStringWithoutInnerConditions()
        {
            var nodeIds = new List<string> { "node1", "node2" };
            var conditions = new Conditions(LogicalOperator.XOR, nodeIds);
            var expected = "{\"operator\": \"XOR\", \"nodeIds\": [\"node1\", \"node2\"]}";
            Assert.AreEqual(expected, conditions.ToString());
        }

        [TestMethod]
        public void TestToStringWithInnerConditions()
        {
            var innerConditions = new Conditions(LogicalOperator.NOR, new List<string> { "innerNode1" });
            var conditions = new Conditions(LogicalOperator.NAND, new List<string> { "node1", "node2" })
            {
                InnerConditions = innerConditions
            };
            var expected = "{\"operator\": \"NAND\", \"nodeIds\": [\"node1\", \"node2\"], \"innerCondition\": {\"operator\": \"NOR\", \"nodeIds\": [\"innerNode1\"]}}";
            Assert.AreEqual(expected, conditions.ToString());
        }
    }
}
