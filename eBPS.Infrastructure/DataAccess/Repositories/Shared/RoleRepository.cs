using System.Data;
using Dapper;
using eBPS.Application.Interfaces.Repositories;
using eBPS.Domain.Entities.Shared;
using eBPS.Application.DTOs.Shared;
using eBPS.Application.Interfaces;

namespace eBPS.Infrastructure.DataAccess.Repositories.Shared
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoleRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Roles> GetByRoleIdAsync(int roleId)
        {
            var query = "SELECT * FROM Roles WHERE Id = @Id";
            return await _unitOfWork.Connection.QuerySingleOrDefaultAsync<Roles>(query, new { Id = roleId }, _unitOfWork.Transaction);
        }

        public async Task<IEnumerable<RolesDTO>> GetActiveRoles()
        {
            var query = "SELECT Id, Name FROM Roles WHERE IsActive = 1";
            return await _unitOfWork.Connection.QueryAsync<RolesDTO>(query, _unitOfWork.Transaction);
        }
    }
}
