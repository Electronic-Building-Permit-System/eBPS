using eBPS.Domain.Entities;

namespace eBPS.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<Users> GetByUsernameAsync(string username);
        Task AddUserAsync(Users user);
        Task AddUserRolesAsync(int userId, int roleId);
    }
}
