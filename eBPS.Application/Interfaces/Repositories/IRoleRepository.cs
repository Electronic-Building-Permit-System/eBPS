using eBPS.Application.DTOs.Shared;
using eBPS.Domain.Entities.Shared;

namespace eBPS.Application.Interfaces.Repositories
{
    public interface IRoleRepository
    {
        Task<Roles> GetByRoleIdAsync(int roleId);
        Task<IEnumerable<RolesDTO>> GetActiveRoles();
    }
}
