using System.Data;
using Dapper;
using eBPS.Application.DTOs.Shared;
using eBPS.Application.Interfaces.Repositories;
using eBPS.Domain.Entities;
using Microsoft.Data.SqlClient;

namespace eBPS.Infrastructure.DataAccess.Repositories.Shared
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly IDbConnection _dbConnection;

        public OrganizationRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task<OrganizationDTO> GetByOrgIdAsync(int orgId)
        {
            var query = "SELECT * FROM Roles WHERE Id = @Id";
            return await _dbConnection.QuerySingleOrDefaultAsync<OrganizationDTO>(query, new { Id = orgId });
        }
        public async Task<IEnumerable<OrganizationDTO>> GetActiveOrganizations()
        {
            const string query = "SELECT Id, Name FROM Organizations WHERE IsActive = 1";
            return await _dbConnection.QueryAsync<OrganizationDTO>(query);
        }
        public async Task<IEnumerable<OrganizationDTO>> GetUserOrganizations(int userId)
        {
            const string query = "SELECT DISTINCT Org.Id, Org.Name FROM UserOrganizations UserOrg INNER JOIN Organizations Org ON UserOrg.OrganizationId = Org.Id where UserOrg.UserId = @UserId";
            return await _dbConnection.QueryAsync<OrganizationDTO>(query, new { UserId = userId });
        }

        public async Task<string> GetOrganizationsConfig(int orgId)
        {
            const string query = "SELECT ConnectionString FROM OrganizationsConfig where OrganizationId = @OrgId";
            return await _dbConnection.QuerySingleOrDefaultAsync<string>(query, new { OrgId = orgId });
        }

        public async Task<object> GetData(string connectionString)
        {
            using var connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM TableA"; // Adjust query as needed
            return await connection.QueryAsync<dynamic>(query);
        }
    }
}
