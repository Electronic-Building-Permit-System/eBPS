using eBPS.Application.Interfaces;

namespace eBPS.Infrastructure.DataAccess
{
    using System.Data;
    using Microsoft.Data.SqlClient;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly string _connectionString;
        private IDbTransaction _transaction;

        public UnitOfWork(string connectionString)
        {
            _connectionString = connectionString;
            Connection = new SqlConnection(_connectionString);
            Connection.Open(); // Open the connection immediately
        }

        public IDbConnection Connection { get; private set; }
        public IDbTransaction Transaction => _transaction;

        public async Task BeginTransactionAsync()
        {
            if (_transaction == null)
            {
                _transaction = await Task.FromResult(Connection.BeginTransaction());
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
            Connection?.Dispose();
        }
    }

}
