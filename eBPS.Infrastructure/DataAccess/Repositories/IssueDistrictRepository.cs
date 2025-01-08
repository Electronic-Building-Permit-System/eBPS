using Dapper;
using eBPS.Application.DTOs;
using eBPS.Application.Interfaces.Repositories;
using eBPS.Domain.Entities;
using Microsoft.Data.SqlClient;
using System.Data;

namespace eBPS.Infrastructure.DataAccess.Repositories
{
    public class IssueDistrictRepository : IIssueDistrictRepository
    {
        private readonly IDbConnection _dbConnection;

        public IssueDistrictRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }


        public async Task<IEnumerable<IssueDistrictDTO>> GetActiveIssueDistrict()
        {
            const string query = "SELECT Id, Description FROM IssueDistrict WHERE IsActive = 1";
            return await _dbConnection.QueryAsync<IssueDistrictDTO>(query);
        }
    }
}
