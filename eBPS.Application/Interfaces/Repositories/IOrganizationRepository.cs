using eBPS.Application.DTOs;

namespace eBPS.Application.Interfaces.Repositories
{
    public interface IOrganizationRepository
    {
        Task<OrganizationDTO> GetByOrgIdAsync(int orgId);
        Task<IEnumerable<OrganizationDTO>> GetActiveOrganizations();
        Task<IEnumerable<OrganizationDTO>> GetUserOrganizations(int userId);
        Task<string?> GetOrganizationsConfig(int orgId);
        Task<object> GetData(string connectionString);
    }
}
