using eBPS.Application.DTOs;

namespace eBPS.Application.Interfaces.Repositories
{
    public interface IOrganizationRepository
    {
        Task<IEnumerable<OrganizationDTO>> GetActiveOrganizations();
    }
}
