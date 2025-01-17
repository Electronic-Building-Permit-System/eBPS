using eBPS.Application.DTOs.BuildingApplication;
using eBPS.Domain.Entities;

namespace eBPS.Application.Interfaces.Repositories
{
    public interface IHouseOwnerRepository
    {
        Task AddHouseOwnerAsync(List<HouseOwnerDTO> houseOwner, int applicationId, string connectionString);
    }
}
