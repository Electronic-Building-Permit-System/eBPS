using eBPS.Application.DTOs;

namespace eBPS.Application.Interfaces
{
    public interface IUserService
    {
        Task RegisterUserAsync(RegisterUserDto userDto);
    }
}
