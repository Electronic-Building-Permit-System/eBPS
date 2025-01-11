using eBPS.Application.DTOs;
using eBPS.Application.Services;
using eBPS.Server.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace eBPS.Server.Tests.Controllers
{
    [TestFixture]
    public class ApplicationControllerTests
    {
        private Mock<IApplicationService> _mockApplicationService;
        private ApplicationController _controller;

        [SetUp]
        public void SetUp()
        {
            _mockApplicationService = new Mock<IApplicationService>();
            _controller = new ApplicationController(_mockApplicationService.Object);
        }

        [Test]
        public async Task GetActiveBuildingPurpose_ShouldReturnOkResult_WithBuildingPurpose()
        {
            // Arrange
            var mockBuildingPurpose = new List<BuildingPurposeDTO> { 
                new BuildingPurposeDTO { Id = 1, Description = "Commercial" }, 
                new BuildingPurposeDTO { Id = 2, Description = "Residential" } 
            };
            _mockApplicationService.Setup(service => service.GetActiveBuildingPurpose())
                .ReturnsAsync((IEnumerable<BuildingPurposeDTO>)mockBuildingPurpose);

            // Act
            var result = await _controller.GetActiveBuildingPurpose();

            // Assert
            var okResult = result as OkObjectResult;
            Assert.That(okResult, Is.Not.Null);
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
            Assert.That(okResult.Value, Is.EqualTo(mockBuildingPurpose));
        }

        [Test]
        public async Task GetActiveBuildingPurpose_ShouldReturnInternalServerError_WhenExceptionIsThrown()
        {
            // Arrange
            _mockApplicationService.Setup(service => service.GetActiveBuildingPurpose())
                .ThrowsAsync(new Exception("Error occurred"));

            // Act
            var result = await _controller.GetActiveBuildingPurpose();

            // Assert
            var statusCodeResult = result as ObjectResult;
            Assert.That(statusCodeResult, Is.Not.Null);
            Assert.That(statusCodeResult.StatusCode, Is.EqualTo(500));
            Assert.That(statusCodeResult.Value, Is.EqualTo("An error occurred while processing your request."));
        }

        [Test]
        public async Task GetActiveNBCClass_ShouldReturnOkResult_WithNBCClass()
        {
            // Arrange
            var mockNBCClass = new List<NBCClassDTO> {
                new NBCClassDTO { Id = 1, Description = "ClassA" },
                new NBCClassDTO { Id = 2, Description = "ClassB" }
            };
            _mockApplicationService.Setup(service => service.GetActiveNBCClass())
                .ReturnsAsync((IEnumerable<NBCClassDTO>)mockNBCClass);

            // Act
            var result = await _controller.GetActiveNBCClass();

            // Assert
            var okResult = result as OkObjectResult;
            Assert.That(okResult, Is.Not.Null);
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
            Assert.That(okResult.Value, Is.EqualTo(mockNBCClass));
        }

        [Test]
        public async Task GetActiveNBCClass_ShouldReturnInternalServerError_WhenExceptionIsThrown()
        {
            // Arrange
            _mockApplicationService.Setup(service => service.GetActiveNBCClass())
                .ThrowsAsync(new Exception("Error occurred"));

            // Act
            var result = await _controller.GetActiveNBCClass();

            // Assert
            var statusCodeResult = result as ObjectResult;
            Assert.That(statusCodeResult, Is.Not.Null);
            Assert.That(statusCodeResult.StatusCode, Is.EqualTo(500));
            Assert.That(statusCodeResult.Value, Is.EqualTo("An error occurred while processing your request."));
        }

        [Test]
        public async Task GetActiveStructureType_ShouldReturnOkResult_WithStructureType()
        {
            // Arrange
            var mockStructureType = new List<StructureTypeDTO> {
                new StructureTypeDTO { Id = 1, Description = "RCC" },
                new StructureTypeDTO { Id = 2, Description = "Load Bearing" }
            };
            _mockApplicationService.Setup(service => service.GetActiveStructureType())
                .ReturnsAsync((IEnumerable<StructureTypeDTO>)mockStructureType);

            // Act
            var result = await _controller.GetActiveStructureType();

            // Assert
            var okResult = result as OkObjectResult;
            Assert.That(okResult, Is.Not.Null);
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
            Assert.That(okResult.Value, Is.EqualTo(mockStructureType));
        }

        [Test]
        public async Task GetActiveStructureType_ShouldReturnInternalServerError_WhenExceptionIsThrown()
        {
            // Arrange
            _mockApplicationService.Setup(service => service.GetActiveStructureType())
                .ThrowsAsync(new Exception("Error occurred"));

            // Act
            var result = await _controller.GetActiveStructureType();

            // Assert
            var statusCodeResult = result as ObjectResult;
            Assert.That(statusCodeResult, Is.Not.Null);
            Assert.That(statusCodeResult.StatusCode, Is.EqualTo(500));
            Assert.That(statusCodeResult.Value, Is.EqualTo("An error occurred while processing your request."));
        }

        [Test]
        public async Task GetActiveLandUseZone_ShouldReturnOkResult_WithLandUseZone()
        {
            // Arrange
            var mockLandUseZone = new List<LandUseZoneDTO> {
                new LandUseZoneDTO { Id = 1, Description = "Residential Zone" },
                new LandUseZoneDTO { Id = 2, Description = "Industrial Zone" }
            };
            _mockApplicationService.Setup(service => service.GetActiveLandUseZone())
                .ReturnsAsync((IEnumerable<LandUseZoneDTO>)mockLandUseZone);

            // Act
            var result = await _controller.GetActiveLandUseZone();

            // Assert
            var okResult = result as OkObjectResult;
            Assert.That(okResult, Is.Not.Null);
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
            Assert.That(okResult.Value, Is.EqualTo(mockLandUseZone));
        }

        [Test]
        public async Task GetActiveLandUseZone_ShouldReturnInternalServerError_WhenExceptionIsThrown()
        {
            // Arrange
            _mockApplicationService.Setup(service => service.GetActiveLandUseZone())
                .ThrowsAsync(new Exception("Error occurred"));

            // Act
            var result = await _controller.GetActiveLandUseZone();

            // Assert
            var statusCodeResult = result as ObjectResult;
            Assert.That(statusCodeResult, Is.Not.Null);
            Assert.That(statusCodeResult.StatusCode, Is.EqualTo(500));
            Assert.That(statusCodeResult.Value, Is.EqualTo("An error occurred while processing your request."));
        }

        [Test]
        public async Task GetActiveLandUseSubZone_ShouldReturnOkResult_WithLandUseZone()
        {
            // Arrange
            var mockLandUseZone = new List<LandUseSubZoneDTO> {
                new LandUseSubZoneDTO { Id = 1, Description = "Residential Sub Zone" },
                new LandUseSubZoneDTO { Id = 2, Description = "Industrial Sub Zone" }
            };
            _mockApplicationService.Setup(service => service.GetActiveLandUseSubZone())
                .ReturnsAsync((IEnumerable<LandUseSubZoneDTO>)mockLandUseZone);

            // Act
            var result = await _controller.GetActiveLandUseSubZone();

            // Assert
            var okResult = result as OkObjectResult;
            Assert.That(okResult, Is.Not.Null);
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
            Assert.That(okResult.Value, Is.EqualTo(mockLandUseZone));
        }

        [Test]
        public async Task GetActiveLandUseSubZone_ShouldReturnInternalServerError_WhenExceptionIsThrown()
        {
            // Arrange
            _mockApplicationService.Setup(service => service.GetActiveLandUseSubZone())
                .ThrowsAsync(new Exception("Error occurred"));

            // Act
            var result = await _controller.GetActiveLandUseSubZone();

            // Assert
            var statusCodeResult = result as ObjectResult;
            Assert.That(statusCodeResult, Is.Not.Null);
            Assert.That(statusCodeResult.StatusCode, Is.EqualTo(500));
            Assert.That(statusCodeResult.Value, Is.EqualTo("An error occurred while processing your request."));
        }

        [Test]
        public async Task GetActiveWard_ShouldReturnOkResult_WithWardList()
        {
            // Arrange
            var mockWardList = new List<WardDTO> {
                new WardDTO { Id = 1, WardNumber = "1" },
                new WardDTO { Id = 2, WardNumber = "2" }
            };
            _mockApplicationService.Setup(service => service.GetActiveWard())
                .ReturnsAsync((IEnumerable<WardDTO>)mockWardList);

            // Act
            var result = await _controller.GetActiveWard();

            // Assert
            var okResult = result as OkObjectResult;
            Assert.That(okResult, Is.Not.Null);
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
            Assert.That(okResult.Value, Is.EqualTo(mockWardList));
        }

        [Test]
        public async Task GetActiveWard_ShouldReturnInternalServerError_WhenExceptionIsThrown()
        {
            // Arrange
            _mockApplicationService.Setup(service => service.GetActiveWard())
                .ThrowsAsync(new Exception("Error occurred"));

            // Act
            var result = await _controller.GetActiveWard();

            // Assert
            var statusCodeResult = result as ObjectResult;
            Assert.That(statusCodeResult, Is.Not.Null);
            Assert.That(statusCodeResult.StatusCode, Is.EqualTo(500));
            Assert.That(statusCodeResult.Value, Is.EqualTo("An error occurred while processing your request."));
        }
    }
}
