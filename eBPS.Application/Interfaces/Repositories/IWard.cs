using eBPS.Application.DTOs;

namespace eBPS.Application.Interfaces.Repositories
{
    public interface IWardRepository
    {
        Task<IEnumerable<WardDTO>> GetActiveWard();

    }
}
