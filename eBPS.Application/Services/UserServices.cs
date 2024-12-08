using eBPS.Application.DTOs;
using eBPS.Application.Interfaces;
using eBPS.Infrastructure.Interfaces;
using eBPS.Domain.Entities;
using eBPS.Domain.Interfaces;

namespace eBPS.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IJwtTokenGenerator _jwtToken;
        private readonly IPasswordHasher _passwordHasher;
        public UserService(IUserRepository userRepository, IRoleRepository roleRepository, IJwtTokenGenerator jwtToken, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _jwtToken = jwtToken;
            _passwordHasher = passwordHasher;
        }

        public async Task RegisterUserAsync(RegisterUserDto userDto)
        {
            // Check if the user already exists
            var existingUser = await _userRepository.GetByUsernameAsync(userDto.Username);
            if (existingUser != null)
            {
                throw new Exception("Username already exists.");
            }

            // Check if the role already exists
            var existingRole = await _roleRepository.GetByRoleIdAsync(userDto.RoleId);
            if (existingRole == null)
            {
                throw new Exception("Role doesn't exists.");
            }

            // Hash the password
            var passwordHash = _passwordHasher.HashPassword(userDto.Password);

            // Create a new user
            var user = new Users
            {
                Username = userDto.Username,
                Email = userDto.Email,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                PhoneNumber = userDto.PhoneNumber,
                PasswordHash = passwordHash,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            // Save the user to the database
            await _userRepository.AddUserAsync(user);

            // Save the userRole to the database
            await _userRepository.AddUserRolesAsync(user.Id, userDto.RoleId);
        }


        public async Task<string> LoginUserAsync(LoginUserDto loginDto)
        {
            var user = await _userRepository.GetByUsernameAsync(loginDto.Username);
            if (user == null || !_passwordHasher.VerifyPassword(loginDto.Password, user.PasswordHash))
            {
                throw new Exception("Invalid username or password.");
            }
            if (user.IsActive == false)
            {
                throw new Exception("User is not active.");
            }
            return _jwtToken.GenerateJwtToken(user);
        }
    }
}
