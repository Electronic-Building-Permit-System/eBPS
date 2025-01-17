using Dapper;
using eBPS.Application.DTOs.BuildingApplication;
using eBPS.Application.Interfaces.Repositories;
using System.Data;

namespace eBPS.Infrastructure.DataAccess.Repositories
{
    public class LandscapeTypeRepository : ILandscapeTypeRepository
    {
        private readonly IDbConnection _dbConnection;

        public LandscapeTypeRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

       
        public async Task<IEnumerable<LandscapeTypeDTO>> GetActiveLandscapeType()
        {
            const string query = "SELECT Id, Description FROM LandscapeType WHERE IsActive = 1";
            return await _dbConnection.QueryAsync<LandscapeTypeDTO>(query);
        }
    }
}
