using eBPS.Application.DTOs.BuildingApplication;
using eBPS.Application.DTOs.BuildingApplication.Dashboard;
using eBPS.Domain.Entities;

namespace eBPS.Application.Interfaces.Repositories
{
    public interface IBuildingApplicationRepository
    {
        Task<IEnumerable<ApplicationDTO>> GetBuildingApplicationList();
        Task AddBuildingApplicationAsync(BuildingApplication buildingApplication, string connectionString);
        Task<BuildingApplication> GetBuildingApplicationById(int id, string connectionString);
    }
}
