using Moq;
using eBPS.Application.Interfaces.Repositories;
using eBPS.Application.DTOs.Shared;
using eBPS.Application.Services.Shared;

namespace eBPS.Application.Tests.Services
{
    [TestFixture]
    public class RoleServiceTests
    {
        private Mock<IRoleRepository> _mockRoleRepository;
        private RoleService _roleService;

        [SetUp]
        public void SetUp()
        {
            _mockRoleRepository = new Mock<IRoleRepository>();
            _roleService = new RoleService(_mockRoleRepository.Object);
        }

        [Test]
        public async Task GetActiveRoles_ShouldReturnListOfActiveRoles()
        {
            // Arrange
            var roles = new List<RolesDTO>
            {
                new RolesDTO { Id = 1, Name = "Admin" },
                new RolesDTO { Id = 2, Name = "User" }
            };

            _mockRoleRepository
                .Setup(repo => repo.GetActiveRoles())
                .ReturnsAsync(roles);

            // Act
            var result = await _roleService.GetActiveRoles();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.EquivalentTo(roles));
            _mockRoleRepository.Verify(repo => repo.GetActiveRoles(), Times.Once);
        }

        [Test]
        public async Task GetActiveRoles_ShouldReturnEmptyList_WhenNoActiveRolesExist()
        {
            // Arrange
            var roles = new List<RolesDTO>();

            _mockRoleRepository
                .Setup(repo => repo.GetActiveRoles())
                .ReturnsAsync(roles);

            // Act
            var result = await _roleService.GetActiveRoles();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.Empty);
            _mockRoleRepository.Verify(repo => repo.GetActiveRoles(), Times.Once);
        }
    }
}

