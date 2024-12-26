using eBPS.Application.DTOs;
using eBPS.Domain.Entities;

namespace eBPS.Application.Interfaces.Repositories
{
    public interface IRoleRepository
    {
        Task<Roles> GetByRoleIdAsync(int roleId);
        Task<IEnumerable<RolesDTO>> GetActiveRoles();
    }
}
