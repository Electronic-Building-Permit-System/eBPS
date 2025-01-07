using eBPS.Application.DTOs;

namespace eBPS.Application.Interfaces.Repositories
{
    public interface ILandUseSubZoneRepository
    {
        Task<IEnumerable<LandUseSubZoneDTO>> GetActiveLandUseSubZone();
    }
}
