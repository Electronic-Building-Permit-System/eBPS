using eBPS.Application.DTOs.BuildingApplication;

namespace eBPS.Application.Interfaces.Repositories
{
    public interface IBuildingPurposeRepository
    {
          Task<IEnumerable<BuildingPurposeDTO>> GetActiveBuildingPurpose();
    }
}
