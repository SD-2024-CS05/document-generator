using AngleSharp.Html.Dom;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Neo4j.Driver;
using ShapeHandler.Database;
using ShapeHandler.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeHandler.Database.Tests
{
    [TestClass()]
    public class DatabaseConnectorTests
    {
        private Mock<IDriver> _mockDriver;
        private Mock<IAsyncSession> _mockSession;
        private Mock<IAsyncTransaction> _mockTransaction;

        [TestInitialize]
        public void Setup()
        {
            _mockDriver = new Mock<IDriver>();
            _mockSession = new Mock<IAsyncSession>();
            _mockTransaction = new Mock<IAsyncTransaction>();

            _mockDriver.Setup(d => d.TryVerifyConnectivityAsync()) // verification during construction
                       .Returns(Task.FromResult(true));

            _mockDriver.Setup(d => d.AsyncSession()) // creation of session to write to database
                       .Returns(_mockSession.Object);

            _mockSession.Setup(s => s.BeginTransactionAsync()) // creation of transaction to write to database
                        .ReturnsAsync(_mockTransaction.Object);

            _mockTransaction.Setup(t => t.RunAsync(It.IsAny<string>(), It.IsAny<object>())) // writing to database
                            .ReturnsAsync(Mock.Of<IResultCursor>());
        }

        [TestMethod()]
        public void DatabaseConnectorConstructorTest()
        {
            var connector = new DatabaseConnector(_mockDriver.Object);

            _mockDriver.Verify(d => d.TryVerifyConnectivityAsync(), Times.Once);

            Assert.IsNotNull(connector);
        }

        [TestMethod()]
        public void DisposeTest()
        {
            var connector = new DatabaseConnector(_mockDriver.Object);
            _mockDriver.Verify(d => d.TryVerifyConnectivityAsync(), Times.Once);

            connector.Dispose();
            _mockDriver.Verify(d => d.Dispose(), Times.Once);
        }

        [TestMethod()]
        public async Task WriteHtmlGraphAsyncTest()
        {
            var connector = new DatabaseConnector(_mockDriver.Object);

            _mockDriver.Verify(d => d.TryVerifyConnectivityAsync(), Times.Once);

            var graph = new HtmlGraph();

            var elementMock = new Mock<IHtmlElement>();
            var node1 = new HtmlNode(elementMock.Object);
            var node2 = new HtmlNode(elementMock.Object);

            Condition<Enum> condition = new Condition<Enum>
            {
                MatchValue = "test",
                Type = NodeType.HtmlElement,
                State = true,
                Validate = (s) => true
            };

            graph.AddNode(node1);
            graph.AddNode(node2);

            graph.AddConnection(node1, node2, condition);

            var result = await connector.WriteHtmlGraphAsync(graph);

            Assert.IsTrue(result);
            _mockTransaction.Verify(t => t.RunAsync(It.IsAny<string>(), It.IsAny<object>()), Times.AtLeastOnce);
            _mockTransaction.Verify(t => t.CommitAsync(), Times.Once);
        }
    }
}