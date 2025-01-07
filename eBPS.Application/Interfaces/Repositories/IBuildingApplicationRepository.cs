using eBPS.Application.DTOs;
using eBPS.Domain.Entities;

namespace eBPS.Application.Interfaces.Repositories
{
    public interface IBuildingApplicationRepository
    {
        Task<IEnumerable<BuildingApplicationDTO>> GetBuildingApplicationList();
        Task AddBuildingApplicationAsync(BuildingApplication buildingApplication, string connectionString);
        Task<IEnumerable<BuildingApplicationDTO>> GetActiveBuildingApplication();

    }
}
