using eBPS.Application.DTOs;

namespace eBPS.Application.Interfaces.Repositories
{
    public interface IBuildingPurposeRepository
    {
          Task<IEnumerable<BuildingPurposeDTO>> GetActiveBuildingPurpose();
    }
}
