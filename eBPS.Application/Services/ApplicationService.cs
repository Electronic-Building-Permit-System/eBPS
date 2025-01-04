using eBPS.Application.DTOs;
using eBPS.Application.Interfaces.Repositories;
namespace eBPS.Application.Services
{
    public interface IApplicationService
    {
        Task<IEnumerable<BuildingPurposeDTO>> GetActiveBuildingPurpose();
        Task<IEnumerable<NBCClassDTO>> GetActiveNBCClass();

    }

    public class ApplicationService : IApplicationService
    {
        private readonly IBuildingPurposeRepository _buildingPurposeRepository;
        private readonly INBCClassRepository _nbcClassRepository;

        public ApplicationService(IBuildingPurposeRepository buildingPurposeRepository, INBCClassRepository nbcClassRepository)
        {
            _buildingPurposeRepository = buildingPurposeRepository;
            _nbcClassRepository = nbcClassRepository;
        }
        public async Task<IEnumerable<BuildingPurposeDTO>> GetActiveBuildingPurpose()
        {
            return await _buildingPurposeRepository.GetActiveBuildingPurpose();
        }
        public async Task<IEnumerable<NBCClassDTO>> GetActiveNBCClass()
        {
            return await _nbcClassRepository.GetActiveNBCClass();
        }

    }
}
