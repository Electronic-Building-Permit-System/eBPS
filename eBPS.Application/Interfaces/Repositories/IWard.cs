using eBPS.Application.DTOs.BuildingApplication;

namespace eBPS.Application.Interfaces.Repositories
{
    public interface IWardRepository
    {
        Task<IEnumerable<WardDTO>> GetActiveWard();

    }
}
