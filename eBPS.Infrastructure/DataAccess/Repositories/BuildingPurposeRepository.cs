using Dapper;
using eBPS.Application.DTOs.BuildingApplication;
using eBPS.Application.Interfaces.Repositories;
using System.Data;

namespace eBPS.Infrastructure.DataAccess.Repositories
{
    public class BuildingPurposeRepository : IBuildingPurposeRepository
    {
        private readonly IDbConnection _dbConnection;

        public BuildingPurposeRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task<IEnumerable<BuildingPurposeDTO>> GetActiveBuildingPurpose()
        {
            const string query = "SELECT Id, Description FROM BuildingPurpose WHERE IsActive = 1";
            return await _dbConnection.QueryAsync<BuildingPurposeDTO>(query);
        }
    }
}