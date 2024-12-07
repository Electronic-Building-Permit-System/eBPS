using eBPS.Application.DTOs;
using System.Text;
using System.Security.Cryptography;
using eBPS.Application.Interfaces;
using eBPS.Infrastructure.Interfaces;
using eBPS.Domain.Entities;

namespace eBPS.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task RegisterUserAsync(RegisterUserDto userDto)
        {
            // Check if the user already exists
            var existingUser = await _userRepository.GetByUsernameAsync(userDto.Username);
            if (existingUser != null)
            {
                throw new Exception("Username already exists.");
            }

            // Hash the password
            var passwordHash = HashPassword(userDto.Password);

            // Create a new user
            var user = new Users
            {
                Username = userDto.Username,
                Email = userDto.Email,
                PasswordHash = passwordHash,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            // Save the user to the database
            await _userRepository.AddUserAsync(user);
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }
}
