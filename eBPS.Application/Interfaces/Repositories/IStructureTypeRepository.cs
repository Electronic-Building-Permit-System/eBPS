using eBPS.Application.DTOs;

namespace eBPS.Application.Interfaces.Repositories
{
    public interface IStructureTypeRepository
    {
        Task<IEnumerable<StructureTypeDTO>> GetActiveStructureType();
    }
}
