using eBPS.Application.DTOs.BuildingApplication;

namespace eBPS.Application.Interfaces.Repositories
{
     public interface  ILandInformationRepository
    {
        Task AddLandInformationAsync(List<LandInformationDTO> houseOwner, int applicationId, string connectionString);
    }
}
