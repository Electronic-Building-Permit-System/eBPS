using eBPS.Application.DTOs;
using eBPS.Application.Interfaces.Repositories;
namespace eBPS.Application.Services
{
    public interface IApplicationService
    {
        Task<IEnumerable<BuildingPurposeDTO>> GetActiveBuildingPurpose();
        Task<IEnumerable<StructureTypeDTO>> GetActiveStructureType();
        Task<IEnumerable<NBCClassDTO>> GetActiveNBCClass();

    }

    public class ApplicationService : IApplicationService
    {
        private readonly IBuildingPurposeRepository _buildingPurposeRepository;
        private readonly IStructureTypeRepository _structureTypeRepository;
        private readonly INBCClassRepository _nbcClassRepository;

        public ApplicationService(IBuildingPurposeRepository buildingPurposeRepository, IStructureTypeRepository structureTypeRepository, INBCClassRepository nbcClassRepository)
        {
            _buildingPurposeRepository = buildingPurposeRepository;
            _structureTypeRepository = structureTypeRepository;
            _nbcClassRepository = nbcClassRepository;
        }
        
        public async Task<IEnumerable<BuildingPurposeDTO>> GetActiveBuildingPurpose()
        {
            return await _buildingPurposeRepository.GetActiveBuildingPurpose();
        }
        public async Task<IEnumerable<StructureTypeDTO>> GetActiveStructureType()
        {
            return await _structureTypeRepository.GetActiveStructureType();
        }

        public async Task<IEnumerable<NBCClassDTO>> GetActiveNBCClass()
        {
            return await _nbcClassRepository.GetActiveNBCClass();
        }

    }
}
