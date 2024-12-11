using eBPS.Domain.Entities;

namespace eBPS.Domain.Interfaces.Repositories
{
    public interface IRoleRepository
    {
        Task<Roles> GetByRoleIdAsync(int roleId);
    }
}
