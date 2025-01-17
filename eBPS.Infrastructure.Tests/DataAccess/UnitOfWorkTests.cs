using Moq;
using NUnit.Framework;
using System.Data;
using System.Threading.Tasks;
using eBPS.Infrastructure.DataAccess;
using Microsoft.Data.SqlClient;
using System.Reflection;

namespace eBPS.Infrastructure.Tests.DataAccess
{
    [TestFixture]
    public class UnitOfWorkTests
    {
        private Mock<IDbConnection> _mockDbConnection;
        private Mock<IDbTransaction> _mockDbTransaction;
        private UnitOfWork _unitOfWork;

        [SetUp]
        public void SetUp()
        {
            // Mock the IDbConnection and IDbTransaction
            _mockDbConnection = new Mock<IDbConnection>();
            _mockDbTransaction = new Mock<IDbTransaction>();

            // Setup the mock to return a mock transaction
            _mockDbConnection.Setup(conn => conn.BeginTransaction()).Returns(_mockDbTransaction.Object);

            // Create the UnitOfWork instance using the mocked IDbConnection
            _unitOfWork = new UnitOfWork(_mockDbConnection.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _unitOfWork?.Dispose(); // Dispose of the controller if it implements IDisposable
        }

        [Test]
        public void Constructor_ShouldOpenConnection()
        {
            // Assert that the connection is opened in the constructor
            _mockDbConnection.Verify(conn => conn.Open(), Times.Once);
        }

        [Test]
        public async Task BeginTransactionAsync_ShouldBeginTransaction()
        {
            // Act
            await _unitOfWork.BeginTransactionAsync();

            // Assert that BeginTransaction was called on the connection
            _mockDbConnection.Verify(conn => conn.BeginTransaction(), Times.Once);
            Assert.That(_unitOfWork.Transaction, Is.Not.Null);
        }

        [Test]
        public async Task CommitTransactionAsync_ShouldCommitTransaction()
        {
            // Arrange
            await _unitOfWork.BeginTransactionAsync();

            // Act
            await _unitOfWork.CommitTransactionAsync();

            // Assert that Commit was called on the transaction
            _mockDbTransaction.Verify(trans => trans.Commit(), Times.Once);
            Assert.That(_unitOfWork.Transaction, Is.Null);
        }

        [Test]
        public async Task RollbackTransactionAsync_ShouldRollbackTransaction()
        {
            // Arrange
            await _unitOfWork.BeginTransactionAsync();

            // Act
            await _unitOfWork.RollbackTransactionAsync();

            // Assert that Rollback was called on the transaction
            _mockDbTransaction.Verify(trans => trans.Rollback(), Times.Once);
            Assert.That(_unitOfWork.Transaction, Is.Null);
        }

        [Test]
        public void Dispose_ShouldDisposeTransactionAndConnection()
        {
            // Act
            _unitOfWork.Dispose();

            // Assert that Dispose was called on both the transaction and the connection
            _mockDbConnection.Verify(conn => conn.Dispose(), Times.Once);
        }
    }
}
