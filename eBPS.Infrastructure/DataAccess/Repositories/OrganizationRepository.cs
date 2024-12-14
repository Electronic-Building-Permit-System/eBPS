using System.Data;
using Dapper;
using eBPS.Application.DTOs;
using eBPS.Application.Interfaces.Repositories;

namespace eBPS.Infrastructure.DataAccess.Repositories
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly IDbConnection _dbConnection;

        public OrganizationRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<OrganizationDTO>> GetActiveOrganizations()
        {
            const string query = "SELECT Id, Name FROM Organizations WHERE IsActive = 1";
            return await _dbConnection.QueryAsync<OrganizationDTO>(query);
        }
    }
}
