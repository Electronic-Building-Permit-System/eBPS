using eBPS.Application.Interfaces;
using System.Data;

namespace eBPS.Infrastructure.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbConnection _connection;
        private IDbTransaction _transaction;

        // Constructor accepts IDbConnection for easier testing
        public UnitOfWork(IDbConnection connection)
        {
            _connection = connection;
            _connection.Open(); // Open the connection immediately
        }

        public IDbConnection Connection => _connection;
        public IDbTransaction Transaction => _transaction;

        public async Task BeginTransactionAsync()
        {
            if (_transaction == null)
            {
                _transaction = await Task.FromResult(_connection.BeginTransaction());
            }
        }

        public async Task CommitTransactionAsync()
        {
            if (_transaction != null)
            {
                await Task.Run(() => _transaction.Commit());
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public async Task RollbackTransactionAsync()
        {
            if (_transaction != null)
            {
                await Task.Run(() => _transaction.Rollback());
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _connection?.Dispose();
        }
    }
}
