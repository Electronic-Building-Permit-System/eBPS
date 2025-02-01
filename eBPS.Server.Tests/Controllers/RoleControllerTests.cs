using eBPS.Application.DTOs.Shared;
using eBPS.Application.Services.Shared;
using eBPS.Server.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace eBPS.Server.Tests.Controllers
{
    [TestFixture]
    public class RolesControllerTests
    {
        private Mock<IRoleService> _mockRoleService;
        private RolesController _rolesController;

        [SetUp]
        public void Setup()
        {
            // Initialize the mocked service and controller
            _mockRoleService = new Mock<IRoleService>();
            _rolesController = new RolesController(_mockRoleService.Object);
        }

        [Test]
        public async Task GetRoles_ReturnsOkResult_WithListOfRoles()
        {
            // Arrange
            var mockRoles = new List<RolesDTO> // List of RolesDTO, not string
            {
                new RolesDTO { Name = "Admin" },
                new RolesDTO { Name = "User" },
                new RolesDTO { Name = "Manager" }
            };

            // Mock the service to return a Task<IEnumerable<RolesDTO>>
            _mockRoleService.Setup(service => service.GetActiveRoles())
                .ReturnsAsync(mockRoles); // Returns a Task<IEnumerable<RolesDTO>>

            // Act
            var result = await _rolesController.GetRoles();

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            var okResult = result as OkObjectResult;
            Assert.That(okResult, Is.Not.Null);
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
            Assert.That(okResult.Value, Is.EqualTo(mockRoles)); // Compare the returned value with mockRoles
        }


        [Test]
        public async Task GetRoles_ReturnsStatusCode500_WhenExceptionIsThrown()
        {
            // Arrange
            _mockRoleService.Setup(service => service.GetActiveRoles())
                .ThrowsAsync(new Exception("Test exception"));

            // Act
            var result = await _rolesController.GetRoles();

            // Assert
            Assert.That(result, Is.InstanceOf<ObjectResult>());
            var objectResult = result as ObjectResult;
            Assert.That(objectResult, Is.Not.Null);
            Assert.That(objectResult.StatusCode, Is.EqualTo(500));
            Assert.That(objectResult.Value, Is.EqualTo("An error occurred while processing your request."));
        }
    }
}
