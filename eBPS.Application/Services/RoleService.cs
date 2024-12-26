using eBPS.Application.DTOs;
using eBPS.Application.Interfaces.Repositories;

namespace eBPS.Application.Services
{
    public interface IRoleService
    {
        Task<IEnumerable<RolesDTO>> GetActiveRoles();
    }

    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<IEnumerable<RolesDTO>> GetActiveRoles()
        {
            return await _roleRepository.GetActiveRoles();
        }
    }

}
