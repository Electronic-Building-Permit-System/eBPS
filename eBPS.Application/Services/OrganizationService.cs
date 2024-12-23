using eBPS.Application.DTOs;
using eBPS.Application.Interfaces.Repositories;

namespace eBPS.Application.Services
{
    public interface IOrganizationService
    {
        Task<IEnumerable<OrganizationDTO>> GetActiveOrganizations();
    }

    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepository _organizationRepository;

        public OrganizationService(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        public async Task<IEnumerable<OrganizationDTO>> GetActiveOrganizations()
        {
            return await _organizationRepository.GetActiveOrganizations();
        }
    }

}
