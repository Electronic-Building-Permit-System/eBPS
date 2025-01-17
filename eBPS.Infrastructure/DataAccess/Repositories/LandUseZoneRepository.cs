using Dapper;
using eBPS.Application.DTOs.BuildingApplication;
using eBPS.Application.Interfaces.Repositories;
using System.Data;

namespace eBPS.Infrastructure.DataAccess.Repositories
{
    public class LandUseZoneRepository : ILandUseZoneRepository
    {
        private readonly IDbConnection _dbConnection;
        public LandUseZoneRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task<IEnumerable<LandUseZoneDTO>> GetActiveLandUseZone()
        {
            const string query = "SELECT Id, Description FROM LandUseZone WHERE IsActive = 1";
            return await _dbConnection.QueryAsync<LandUseZoneDTO>(query);
        }
    }
}
