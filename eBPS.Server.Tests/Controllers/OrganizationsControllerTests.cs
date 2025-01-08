using Moq;
using eBPS.Server.Controllers;
using eBPS.Application.Services;
using eBPS.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace eBPS.Tests
{
    [TestFixture]
    public class OrganizationsControllerTests
    {
        private Mock<IOrganizationService> _mockOrganizationService;
        private OrganizationsController _organizationsController;

        [SetUp]
        public void Setup()
        {
            // Create mock of IOrganizationService
            _mockOrganizationService = new Mock<IOrganizationService>();

            // Initialize controller with the mocked service
            _organizationsController = new OrganizationsController(_mockOrganizationService.Object);
        }

        [Test]
        public async Task GetOrganizations_ReturnsOkResult_WhenSuccessful()
        {
            // Arrange
            var mockOrganizations = new List<OrganizationDTO> // Example DTOs, adjust as per actual definition
            {
                new OrganizationDTO { Id = 1, Name = "Org 1" },
                new OrganizationDTO { Id = 2, Name = "Org 2" }
            };

            // Setup mock to return the organizations list
            _mockOrganizationService.Setup(service => service.GetActiveOrganizations())
                .ReturnsAsync(mockOrganizations);

            // Act
            var result = await _organizationsController.GetOrganizations();

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            var okResult = result as OkObjectResult;
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
            Assert.That(okResult.Value, Is.EqualTo(mockOrganizations));
        }

        [Test]
        public async Task GetOrganizations_ReturnsStatusCode500_WhenExceptionIsThrown()
        {
            // Arrange
            _mockOrganizationService.Setup(service => service.GetActiveOrganizations())
                .ThrowsAsync(new Exception("Test exception"));

            // Act
            var result = await _organizationsController.GetOrganizations();

            // Assert
            Assert.That(result, Is.InstanceOf<ObjectResult>());
            var objectResult = result as ObjectResult;
            Assert.That(objectResult.StatusCode, Is.EqualTo(500));
            Assert.That(objectResult.Value, Is.EqualTo("An error occurred while processing your request."));
        }

        [Test]
        public async Task GetUserOrganizations_ReturnsOkResult_WhenSuccessful()
        {
            // Arrange
            var mockOrganizations = new List<OrganizationDTO>
            {
                new OrganizationDTO { Id = 1, Name = "User Org 1" },
                new OrganizationDTO { Id = 2, Name = "User Org 2" }
            };
            var mockUserId = 123;

            _mockOrganizationService.Setup(service => service.GetUserIdFromToken(It.IsAny<HttpContext>()))
                .Returns(mockUserId);
            _mockOrganizationService.Setup(service => service.GetUserOrganizations(mockUserId))
                .ReturnsAsync(mockOrganizations);

            // Act
            var result = await _organizationsController.GetUserOrganizations();

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            var okResult = result as OkObjectResult;
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
            Assert.That(okResult.Value, Is.EqualTo(mockOrganizations));
        }

        [Test]
        public async Task GetUserOrganizations_ReturnsStatusCode500_WhenExceptionIsThrown()
        {
            // Arrange
            _mockOrganizationService.Setup(service => service.GetUserIdFromToken(It.IsAny<HttpContext>()))
                .Throws(new Exception("Test exception"));

            // Act
            var result = await _organizationsController.GetUserOrganizations();

            // Assert
            Assert.That(result, Is.InstanceOf<ObjectResult>());
            var objectResult = result as ObjectResult;
            Assert.That(objectResult.StatusCode, Is.EqualTo(500));
            Assert.That(objectResult.Value, Is.EqualTo("An error occurred while processing your request."));
        }
    }
}
