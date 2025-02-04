using eBPS.Domain.Entities.Shared;

namespace eBPS.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<Users> GetByUsernameAsync(string username);
        Task AddUserAsync(Users user);
        Task AddUserOrganizationsAsync(IEnumerable<UserOrganizations> userOrganizations);
        
    }
}
