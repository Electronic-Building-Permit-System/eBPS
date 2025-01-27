using eBPS.Application.DTOs.Shared;
using eBPS.Application.Interfaces;
using eBPS.Application.Interfaces.Repositories;
using eBPS.Domain.Entities;
using eBPS.Domain.Entities.Shared;

namespace eBPS.Application.Services.Shared
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

                /// Validate roles
                foreach (var roleId in userDto.RoleIds)
                {
                    var existingRole = await _roleRepository.GetByRoleIdAsync(roleId);
                    if (existingRole == null)
                    {
                        throw new Exception($"Role with ID {roleId} doesn't exist.");
                    }
                }

                // Validate organizations
                foreach (var orgId in userDto.OrgIds)
                {
                    var existingOrg = await _organizationRepository.GetByOrgIdAsync(orgId);
                    if (existingOrg == null)
                    {
                        throw new Exception($"Organization with ID {orgId} doesn't exist.");
                    }
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
                    CreatedDate = DateTime.UtcNow,
                    LastLoginOrgId = userDto.OrgIds.First(),
                    LastLoginRoleId = userDto.RoleIds.First(),
                };

                // Save the user to the database
                await _userRepository.AddUserAsync(user);

                // Save user roles and organizations to the database
                var userOrganizations = new List<UserOrganizations>();
                foreach (var roleId in userDto.RoleIds)
                {
                    foreach (var orgId in userDto.OrgIds)
                    {
                        userOrganizations.Add(new UserOrganizations
                        {
                            UserId = user.Id,
                            RoleId = roleId,
                            OrganizationId = orgId
                        });
                    }
                }

                // Bulk insert user organizations
                await _userRepository.AddUserOrganizationsAsync(userOrganizations);
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
            string token = _jwtToken.GenerateJwtToken(user);
            //if(!String.IsNullOrEmpty(token))
            //{
            //    await _userRepository.UpdateLastLogin(user.Id);
            //}
            return token;
        }
    }
}
