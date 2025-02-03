
using eBPS.Application.DTOs.BuildingApplication;

namespace eBPS.Application.Interfaces.Repositories
{
    public interface ICharkillaRepository
    {
        Task AddCharkillaAsync(List<CharkillaDTO> houseOwner, int applicationId, string connectionString);
    }
    
       
    
}
