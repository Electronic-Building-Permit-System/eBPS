using eBPS.Application.DTOs.BuildingApplication;

namespace eBPS.Application.Interfaces.Repositories
{
    public interface INBCClassRepository
    {
        Task<IEnumerable<NBCClassDTO>> GetActiveNBCClass();

    }
}
