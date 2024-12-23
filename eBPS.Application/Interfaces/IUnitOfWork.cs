using System.Data;

namespace eBPS.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }
    }
}
