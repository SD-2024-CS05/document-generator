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

            _mockDriver.Setup(d => d.AsyncSession(It.IsAny<Action<SessionConfigBuilder>>()))
                       .Returns(_mockSession.Object);
            _mockSession.Setup(s => s.BeginTransactionAsync(It.IsAny<Action<TransactionConfigBuilder>>()))
                        .ReturnsAsync(_mockTransaction.Object);
        }

        [TestMethod()]
        public void DatabaseConnectorTest()
        {

            _mockDriver.Setup(d => d.TryVerifyConnectivityAsync())
                       .Returns(Task.FromResult(true));

            var connector = new DatabaseConnector(_mockDriver.Object);

            _mockDriver.Verify(d => d.TryVerifyConnectivityAsync(), Times.Once);

            Assert.IsNotNull(connector);
        }

        [TestMethod()]
        public void DisposeTest()
        {

            _mockDriver.Setup(d => d.TryVerifyConnectivityAsync())
                       .Returns(Task.FromResult(true));

            var connector = new DatabaseConnector(_mockDriver.Object);
            _mockDriver.Verify(d => d.TryVerifyConnectivityAsync(), Times.Once);

            connector.Dispose();
            _mockDriver.Verify(d => d.Dispose(), Times.Once);
        }

        [TestMethod()]
        public async Task WriteHtmlGraphAsyncTest()
        {
            _mockDriver.Setup(d => d.TryVerifyConnectivityAsync())
                       .Returns(Task.FromResult(true));

            var connector = new DatabaseConnector(_mockDriver.Object);

            _mockDriver.Verify(d => d.TryVerifyConnectivityAsync(), Times.Once);

            var graph = new HtmlGraph();
            var elementMock = new Mock<IHtmlElement>();
            var node = new HtmlNode(elementMock.Object);

            _mockDriver.Setup(d => d.AsyncSession())
                       .Returns(_mockSession.Object);

            _mockSession.Setup(s => s.BeginTransactionAsync(It.IsAny<Action<TransactionConfigBuilder>>()))
                        .ReturnsAsync(_mockTransaction.Object);

            _mockTransaction.Setup(t => t.CommitAsync())
                .Returns(Task.CompletedTask);

            _mockTransaction.Setup(t => t.RunAsync(It.IsAny<string>(), It.IsAny<object>()))
                            .ReturnsAsync(Mock.Of<IResultCursor>());

            var result = await connector.WriteHtmlGraphAsync(graph);

            Assert.IsTrue(result);
            _mockTransaction.Verify(t => t.RunAsync(It.IsAny<string>(), It.IsAny<object>()), Times.AtLeastOnce);
            _mockTransaction.Verify(t => t.CommitAsync(), Times.Once);
        }
    }
}