using System.Data;
using Dapper;
using eBPS.Application.Interfaces.Repositories;
using eBPS.Domain.Entities.Shared;
using eBPS.Application.DTOs.Shared;

namespace eBPS.Infrastructure.DataAccess.Repositories.Shared
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IDbConnection _dbConnection;

        public RoleRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<Roles> GetByRoleIdAsync(int roleId)
        {
            var query = "SELECT * FROM Roles WHERE Id = @Id";
            return await _dbConnection.QuerySingleOrDefaultAsync<Roles>(query, new { Id = roleId });
        }

        public async Task<IEnumerable<RolesDTO>> GetActiveRoles()
        {
            var query = "SELECT Id, Name FROM Roles WHERE IsActive = 1";
            return await _dbConnection.QueryAsync<RolesDTO>(query);
        }
    }
}
