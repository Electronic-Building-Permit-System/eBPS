using Dapper;
using eBPS.Application.DTOs.BuildingApplication;
using eBPS.Application.Interfaces.Repositories;
using System.Data;

namespace eBPS.Infrastructure.DataAccess.Repositories.Shared
{
    public class WardRepository : IWardRepository
    {
        private readonly IDbConnection _dbConnection;
        public WardRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task<IEnumerable<WardDTO>> GetActiveWard()
        {
            const string query = "SELECT Id, WardNumber FROM Ward WHERE IsActive = 1";
            return await _dbConnection.QueryAsync<WardDTO>(query);
        }
    }
}
