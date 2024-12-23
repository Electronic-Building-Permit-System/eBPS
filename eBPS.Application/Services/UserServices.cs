using eBPS.Application.DTOs;
using eBPS.Application.Interfaces;
using eBPS.Application.Interfaces.Repositories;
using eBPS.Domain.Entities;

namespace eBPS.Application.Services
{
    public interface IUserService
    {
        Task RegisterUser(RegisterUserDTO userDto);
        Task<string> LoginUser(LoginUserDTO userDto);
    }
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IJwtTokenGenerator _jwtToken;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUserRepository userRepository, IRoleRepository roleRepository, IOrganizationRepository organizationRepository, IJwtTokenGenerator jwtToken, IPasswordHasher passwordHasher, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _organizationRepository = organizationRepository;
            _jwtToken = jwtToken;
            _passwordHasher = passwordHasher;
            _unitOfWork = unitOfWork;
        }

        public async Task RegisterUser(RegisterUserDTO userDto)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();
                // Check if the user already exists
                var existingUser = await _userRepository.GetByUsernameAsync(userDto.Username);
                if (existingUser != null)
                {
                    throw new Exception("Username already exists.");
                }

                //// Check if the role already exists
                //var existingRole = await _roleRepository.GetByRoleIdAsync(userDto.RoleId);
                //if (existingRole == null)
                //{
                //    throw new Exception("Role doesn't exists.");
                //}

                //var existingOrg = await _organizationRepository.GetByOrgIdAsync(userDto.OrgId);
                //if (existingRole == null)
                //{
                //    throw new Exception("Organization doesn't exists.");
                //}

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
                    CreatedDate = DateTime.UtcNow
                };

                // Save the user to the database
                await _userRepository.AddUserAsync(user);

                // Save the userRole to the database
                await _userRepository.AddUserOrganizationsAsync(user.Id, userDto.RoleId, userDto.OrgId);
                await _unitOfWork.CommitTransactionAsync();
            }
            catch (Exception)
            {
                // Rollback if any exception occurs.
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }

        public async Task<string> LoginUser(LoginUserDTO loginDto)
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
