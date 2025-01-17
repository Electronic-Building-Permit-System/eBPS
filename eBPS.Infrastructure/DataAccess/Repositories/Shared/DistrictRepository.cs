using Dapper;
using eBPS.Application.DTOs.BuildingApplication;
using eBPS.Application.Interfaces.Repositories;
using eBPS.Domain.Entities;
using Microsoft.Data.SqlClient;
using System.Data;

namespace eBPS.Infrastructure.DataAccess.Repositories.Shared
{
    public class DistrictRepository : IDistrictRepository
    {
        private readonly IDbConnection _dbConnection;

        public DistrictRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }


        public async Task<IEnumerable<DistrictDTO>> GetActiveIssueDistrict()
        {
            const string query = "SELECT Id, Description FROM District WHERE IsActive = 1";
            return await _dbConnection.QueryAsync<DistrictDTO>(query);
        }
    }
}
