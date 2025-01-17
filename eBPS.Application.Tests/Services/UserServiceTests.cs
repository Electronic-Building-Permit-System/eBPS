using Moq;
using eBPS.Application.DTOs;
using eBPS.Application.Interfaces;
using eBPS.Application.Interfaces.Repositories;
using eBPS.Application.Services;
using eBPS.Domain.Entities;

namespace eBPS.Application.Tests.Services
{
    [TestFixture]
    public class UserServiceTests
    {
        private Mock<IUserRepository> _mockUserRepository;
        private Mock<IRoleRepository> _mockRoleRepository;
        private Mock<IOrganizationRepository> _mockOrganizationRepository;
        private Mock<IJwtTokenGenerator> _mockJwtTokenGenerator;
        private Mock<IPasswordHasher> _mockPasswordHasher;
        private Mock<IUnitOfWork> _mockUnitOfWork;

        private UserService _userService;

        [SetUp]
        public void SetUp()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _mockRoleRepository = new Mock<IRoleRepository>();
            _mockOrganizationRepository = new Mock<IOrganizationRepository>();
            _mockJwtTokenGenerator = new Mock<IJwtTokenGenerator>();
            _mockPasswordHasher = new Mock<IPasswordHasher>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();

            _userService = new UserService(
                _mockUserRepository.Object,
                _mockRoleRepository.Object,
                _mockOrganizationRepository.Object,
                _mockJwtTokenGenerator.Object,
                _mockPasswordHasher.Object,
                _mockUnitOfWork.Object
            );
        }

        [Test]
        public async Task RegisterUser_ShouldRegisterUserSuccessfully()
        {
            // Arrange
            var userDto = new RegisterUserDTO
            {
                Username = "testuser",
                Email = "testuser@example.com",
                FirstName = "Test",
                LastName = "User",
                PhoneNumber = "1234567890",
                Password = "Password123",
                RoleIds = new List<int> { 1 },
                OrgIds = new List<int> { 100 }
            };

            _mockUserRepository.Setup(repo => repo.GetByUsernameAsync(userDto.Username))
                .ReturnsAsync((Users)null);
            _mockRoleRepository.Setup(repo => repo.GetByRoleIdAsync(1))
                .ReturnsAsync(new Roles { Id = 1, Name = "Admin" });
            _mockOrganizationRepository.Setup(repo => repo.GetByOrgIdAsync(100))
                .Returns(Task.FromResult(new OrganizationDTO { Id = 100, Name = "Organization A" }));
            _mockPasswordHasher.Setup(hasher => hasher.HashPassword(userDto.Password))
                .Returns("hashedpassword");
            _mockUserRepository.Setup(repo => repo.AddUserAsync(It.IsAny<Users>()))
                .Returns(Task.CompletedTask);
            _mockUserRepository.Setup(repo => repo.AddUserOrganizationsAsync(It.IsAny<List<UserOrganizations>>()))
                .Returns(Task.CompletedTask);
            _mockUnitOfWork.Setup(uow => uow.BeginTransactionAsync())
                .Returns(Task.CompletedTask);
            _mockUnitOfWork.Setup(uow => uow.CommitTransactionAsync())
                .Returns(Task.CompletedTask);

            // Act
            await _userService.RegisterUser(userDto);

            // Assert
            _mockUserRepository.Verify(repo => repo.GetByUsernameAsync(userDto.Username), Times.Once);
            _mockRoleRepository.Verify(repo => repo.GetByRoleIdAsync(1), Times.Once);
            _mockOrganizationRepository.Verify(repo => repo.GetByOrgIdAsync(100), Times.Once);
            _mockPasswordHasher.Verify(hasher => hasher.HashPassword(userDto.Password), Times.Once);
            _mockUserRepository.Verify(repo => repo.AddUserAsync(It.IsAny<Users>()), Times.Once);
            _mockUserRepository.Verify(repo => repo.AddUserOrganizationsAsync(It.IsAny<List<UserOrganizations>>()), Times.Once);
            _mockUnitOfWork.Verify(uow => uow.BeginTransactionAsync(), Times.Once);
            _mockUnitOfWork.Verify(uow => uow.CommitTransactionAsync(), Times.Once);
        }

        [Test]
        public void RegisterUser_ShouldThrowException_WhenUsernameAlreadyExists()
        {
            // Arrange
            var userDto = new RegisterUserDTO
            {
                Username = "testuser",
                Password = "Password123",
                RoleIds = new List<int> { 1 },
                OrgIds = new List<int> { 100 }
            };

            _mockUserRepository.Setup(repo => repo.GetByUsernameAsync(userDto.Username))
                .ReturnsAsync(new Users());

            // Act & Assert
            var ex = Assert.ThrowsAsync<Exception>(() => _userService.RegisterUser(userDto));
            Assert.That(ex.Message, Is.EqualTo("Username already exists."));
            _mockUserRepository.Verify(repo => repo.GetByUsernameAsync(userDto.Username), Times.Once);
        }

        [Test]
        public async Task LoginUser_ShouldReturnJwtToken_WhenCredentialsAreValid()
        {
            // Arrange
            var loginDto = new LoginUserDTO
            {
                Username = "testuser",
                Password = "Password123"
            };

            var user = new Users
            {
                Username = "testuser",
                PasswordHash = "hashedpassword",
                IsActive = true
            };

            _mockUserRepository.Setup(repo => repo.GetByUsernameAsync(loginDto.Username))
                .ReturnsAsync(user);
            _mockPasswordHasher.Setup(hasher => hasher.VerifyPassword(loginDto.Password, user.PasswordHash))
                .Returns(true);
            _mockJwtTokenGenerator.Setup(generator => generator.GenerateJwtToken(user))
                .Returns("jwt-token");

            // Act
            var token = await _userService.LoginUser(loginDto);

            // Assert
            Assert.That(token, Is.EqualTo("jwt-token"));
            _mockUserRepository.Verify(repo => repo.GetByUsernameAsync(loginDto.Username), Times.Once);
            _mockPasswordHasher.Verify(hasher => hasher.VerifyPassword(loginDto.Password, user.PasswordHash), Times.Once);
            _mockJwtTokenGenerator.Verify(generator => generator.GenerateJwtToken(user), Times.Once);
        }

        [Test]
        public void LoginUser_ShouldThrowException_WhenUserNotFound()
        {
            // Arrange
            var loginDto = new LoginUserDTO
            {
                Username = "testuser",
                Password = "Password123"
            };

            _mockUserRepository.Setup(repo => repo.GetByUsernameAsync(loginDto.Username))
                .ReturnsAsync((Users)null);

            // Act & Assert
            var ex = Assert.ThrowsAsync<Exception>(() => _userService.LoginUser(loginDto));
            Assert.That(ex.Message, Is.EqualTo("Invalid username or password."));
            _mockUserRepository.Verify(repo => repo.GetByUsernameAsync(loginDto.Username), Times.Once);
        }
    }
}
