using eBPS.Domain.Entities;

namespace eBPS.Infrastructure.Interfaces
{
    public interface IRoleRepository
    {
        Task<Roles> GetByRoleIdAsync(int roleId);
    }
}
