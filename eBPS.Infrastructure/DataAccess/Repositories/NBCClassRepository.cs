using Dapper;
using eBPS.Application.Interfaces.Repositories;
using System.Data;
using eBPS.Application.DTOs.BuildingApplication;

namespace eBPS.Infrastructure.DataAccess.Repositories
{
    public class NBCClassRepository : INBCClassRepository
    {
        private readonly IDbConnection _dbConnection;

        public NBCClassRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task<IEnumerable<NBCClassDTO>> GetActiveNBCClass()
        {
            const string query = "SELECT Id, Description FROM NBCClass WHERE IsActive = 1";
            return await _dbConnection.QueryAsync<NBCClassDTO>(query);
        }

    }
}
