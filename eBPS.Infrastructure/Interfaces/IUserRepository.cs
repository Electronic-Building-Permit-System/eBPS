using eBPS.Domain.Entities;

namespace eBPS.Infrastructure.Interfaces
{
    public interface IUserRepository
    {
        Task<Users> GetByUsernameAsync(string username);
        Task AddUserAsync(Users user);
        Task AddUserRolesAsync(int userId, int roleId);
    }
}
