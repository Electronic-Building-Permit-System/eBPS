using eBPS.Application.DTOs.BuildingApplication;

namespace eBPS.Application.Interfaces.Repositories
{
    public interface ILandUseSubZoneRepository
    {
        Task<IEnumerable<LandUseSubZoneDTO>> GetActiveLandUseSubZone();
    }
}
