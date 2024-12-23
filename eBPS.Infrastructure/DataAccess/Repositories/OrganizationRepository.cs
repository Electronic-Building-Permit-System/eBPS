using System.Data;
using Dapper;
using eBPS.Application.DTOs;
using eBPS.Application.Interfaces.Repositories;
using eBPS.Domain.Entities;

namespace eBPS.Infrastructure.DataAccess.Repositories
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
    }
}
