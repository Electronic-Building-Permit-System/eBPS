using eBPS.Application.DTOs.Shared;
using eBPS.Application.Interfaces.Repositories;
using eBPS.Application.Services.Shared;
using Microsoft.AspNetCore.Http;
using Moq;
using System.Security.Claims;

namespace eBPS.Application.Tests.Services
{
    [TestFixture]
    public class OrganizationServiceTests
    {
        private Mock<IOrganizationRepository> _organizationRepositoryMock;
        private OrganizationService _organizationService;

        [SetUp]
        public void SetUp()
        {
            _organizationRepositoryMock = new Mock<IOrganizationRepository>();
            _organizationService = new OrganizationService(_organizationRepositoryMock.Object);
        }

        [Test]
        public async Task GetActiveOrganizations_ShouldReturnActiveOrganizations()
        {
            // Arrange
            var organizations = new List<OrganizationDTO>
            {
                new OrganizationDTO { Id = 1, Name = "Org1" },
                new OrganizationDTO { Id = 2, Name = "Org2" }
            };

            _organizationRepositoryMock.Setup(r => r.GetActiveOrganizations())
                .ReturnsAsync(organizations);

            // Act
            var result = await _organizationService.GetActiveOrganizations();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(2));
            _organizationRepositoryMock.Verify(r => r.GetActiveOrganizations(), Times.Once);
        }

        [Test]
        public async Task GetUserOrganizations_ShouldReturnUserOrganizations()
        {
            // Arrange
            var userId = 1;
            var organizations = new List<OrganizationDTO>
            {
                new OrganizationDTO { Id = 1, Name = "Org1" },
                new OrganizationDTO { Id = 2, Name = "Org2" }
            };

            _organizationRepositoryMock.Setup(r => r.GetUserOrganizations(userId))
                .ReturnsAsync(organizations);

            // Act
            var result = await _organizationService.GetUserOrganizations(userId);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(2));
            _organizationRepositoryMock.Verify(r => r.GetUserOrganizations(userId), Times.Once);
        }

        [Test]
        public async Task GetOrganizationsConfig_ShouldReturnOrganizationConfig()
        {
            // Arrange
            var orgId = 1;
            var connectionString = "Server=localhost;Database=TestDb;";
            var data = new { ConfigKey = "Value" };

            _organizationRepositoryMock.Setup(r => r.GetOrganizationsConfig(orgId))
                .ReturnsAsync(connectionString);
            _organizationRepositoryMock.Setup(r => r.GetData(connectionString))
                .ReturnsAsync(data);

            // Act
            var result = await _organizationService.GetOrganizationsConfig(orgId);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.EqualTo(data));
            _organizationRepositoryMock.Verify(r => r.GetOrganizationsConfig(orgId), Times.Once);
            _organizationRepositoryMock.Verify(r => r.GetData(connectionString), Times.Once);
        }

        [Test]
        public void GetUserIdFromToken_ShouldReturnUserId_WhenTokenIsValid()
        {
            // Arrange
            var userId = 123;
            var claims = new List<Claim> { new Claim("userId", userId.ToString()) };
            var identity = new ClaimsIdentity(claims);
            var httpContext = new DefaultHttpContext { User = new ClaimsPrincipal(identity) };

            // Act
            var result = _organizationService.GetUserIdFromToken(httpContext);

            // Assert
            Assert.That(result, Is.EqualTo(userId));
        }

        [Test]
        public void GetUserIdFromToken_ShouldThrowUnauthorizedAccessException_WhenUserIdNotFound()
        {
            // Arrange
            var httpContext = new DefaultHttpContext { User = new ClaimsPrincipal() };

            // Act & Assert
            var exception = Assert.Throws<UnauthorizedAccessException>(() => _organizationService.GetUserIdFromToken(httpContext));
            Assert.That(exception.Message, Is.EqualTo("User ID not found in token."));
        }
    }
}

