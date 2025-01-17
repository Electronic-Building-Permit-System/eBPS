using eBPS.Application.DTOs.BuildingApplication;

namespace eBPS.Application.Interfaces.Repositories
{
    public interface IStructureTypeRepository
    {
        Task<IEnumerable<StructureTypeDTO>> GetActiveStructureType();
    }
}
