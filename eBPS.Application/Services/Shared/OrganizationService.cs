using eBPS.Application.DTOs.Shared;
using eBPS.Application.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;

namespace eBPS.Application.Services.Shared
{
    public interface IOrganizationService
    {
        Task<IEnumerable<OrganizationDTO>> GetActiveOrganizations();
        Task<IEnumerable<OrganizationDTO>> GetUserOrganizations(int userId);
        int GetUserIdFromToken(HttpContext httpContext);
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
        public async Task<IEnumerable<OrganizationDTO>> GetUserOrganizations(int userId)
        {
            return await _organizationRepository.GetUserOrganizations(userId);
        }

        public int GetUserIdFromToken(HttpContext httpContext)
        {
            var userIdClaim = httpContext.User.Claims.FirstOrDefault(c => c.Type == "userId");
            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out var userId))
            {
                return userId;
            }
            throw new UnauthorizedAccessException("User ID not found in token.");
        }
    }

}
