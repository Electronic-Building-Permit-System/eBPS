using Dapper;
using eBPS.Application.DTOs.BuildingApplication;
using eBPS.Application.Interfaces.Repositories;
using eBPS.Domain.Entities;
using Microsoft.Data.SqlClient;
using System.Data;

namespace eBPS.Infrastructure.DataAccess.Repositories
{
    public class TransactionTypeRepository: ITransactionTypeRepository
    {
        private readonly IDbConnection _dbConnection;

        public TransactionTypeRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }


        public async Task<IEnumerable<TransactionTypeDTO>> GetActiveTransactionType()
        {
            const string query = "SELECT Id, Description FROM TransactionType WHERE IsActive = 1";
            return await _dbConnection.QueryAsync<TransactionTypeDTO>(query);
        }
    }
}
