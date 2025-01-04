using eBPS.Application.DTOs;

namespace eBPS.Application.Interfaces.Repositories
{
    public interface INBCClassRepository
    {
        Task<IEnumerable<NBCClassDTO>> GetActiveNBCClass();

    }
}
