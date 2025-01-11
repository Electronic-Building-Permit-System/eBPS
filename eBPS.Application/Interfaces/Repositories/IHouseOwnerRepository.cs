using eBPS.Application.DTOs;
using eBPS.Domain.Entities;

namespace eBPS.Application.Interfaces.Repositories
{
    public interface IHouseOwnerRepository
    {
        Task AddHouseOwnerAsync(HouseOwner houseOwner, string connectionString);
    }
}
