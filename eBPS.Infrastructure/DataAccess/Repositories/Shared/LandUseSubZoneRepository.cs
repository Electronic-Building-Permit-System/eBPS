using Dapper;
using eBPS.Application.DTOs.BuildingApplication;
using eBPS.Application.Interfaces.Repositories;
using System.Data;


namespace eBPS.Infrastructure.DataAccess.Repositories.Shared
{
    public class LandUseSubZoneRepository : ILandUseSubZoneRepository
    {
        private readonly IDbConnection _dbConnection;

        public LandUseSubZoneRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task<IEnumerable<LandUseSubZoneDTO>> GetActiveLandUseSubZone()
        {
            const string query = "SELECT Id, Description FROM LandUseSubZone WHERE IsActive = 1";
            return await _dbConnection.QueryAsync<LandUseSubZoneDTO>(query);
        }
    }
}
