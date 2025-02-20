﻿using Moq;
using eBPS.Application.Interfaces.Repositories;
using eBPS.Application.Services;
using eBPS.Application.DTOs.BuildingApplication;
using eBPS.Application.Interfaces;

namespace eBPS.Tests.Application.Services
{
    [TestFixture]
    public class ApplicationServiceTests
    {
        private Mock<IBuildingPurposeRepository> _buildingPurposeRepositoryMock;
        private Mock<IStructureTypeRepository> _structureTypeRepositoryMock;
        private Mock<INBCClassRepository> _nbcClassRepositoryMock;
        private Mock<ILandscapeTypeRepository> _landscapeTypeRepositoryMock;
        private Mock<IWardRepository> _wardRepositoryMock;
        private Mock<IOrganizationRepository> _organizationRepositoryMock;
        private Mock<IBuildingApplicationRepository> _buildingApplicationRepositoryMock;
        private Mock<IDistrictRepository> _issueDistrictRepositoryMock;
        private Mock<ITransactionTypeRepository> _transactionTypeRepositoryMock;
        private Mock<ILandUseZoneRepository> _landUseZoneRepositoryMock;
        private Mock<ILandUseSubZoneRepository> _landUseSubZoneRepositoryMock;
        private Mock<IHouseOwnerRepository> _houseOwnerRepositoryMock;
        private Mock<ILandInformationRepository> _landInformationRepositoryMock;
        private Mock<ICharkillaRepository> _charkillaRepositoryMock;
        private Mock<ILandOwnerRepository> _landOwnerRepositoryMock;
        private Mock<IUserContextService> _userContext;

        private IApplicationService _applicationService;

        [SetUp]
        public void Setup()
        {
            _buildingPurposeRepositoryMock = new Mock<IBuildingPurposeRepository>();
            _structureTypeRepositoryMock = new Mock<IStructureTypeRepository>();
            _nbcClassRepositoryMock = new Mock<INBCClassRepository>();
            _landscapeTypeRepositoryMock= new Mock<ILandscapeTypeRepository>();
            _wardRepositoryMock = new Mock<IWardRepository>();
            _organizationRepositoryMock = new Mock<IOrganizationRepository>();
            _buildingApplicationRepositoryMock = new Mock<IBuildingApplicationRepository>();
            _issueDistrictRepositoryMock= new Mock<IDistrictRepository>();
            _transactionTypeRepositoryMock = new Mock<ITransactionTypeRepository>();
            _landUseZoneRepositoryMock = new Mock<ILandUseZoneRepository>();
            _landUseSubZoneRepositoryMock = new Mock<ILandUseSubZoneRepository>();
            _houseOwnerRepositoryMock = new Mock<IHouseOwnerRepository>();
            _landInformationRepositoryMock = new Mock<ILandInformationRepository>();
            _charkillaRepositoryMock = new Mock<ICharkillaRepository>();
            _landOwnerRepositoryMock = new Mock<ILandOwnerRepository>();
            _userContext = new Mock<IUserContextService>();

            _applicationService = new ApplicationService(
                _buildingPurposeRepositoryMock.Object,
                _structureTypeRepositoryMock.Object,
                _nbcClassRepositoryMock.Object,
                _landscapeTypeRepositoryMock.Object,
                _wardRepositoryMock.Object,
                _organizationRepositoryMock.Object,
                _buildingApplicationRepositoryMock.Object,
                _issueDistrictRepositoryMock.Object,
                _transactionTypeRepositoryMock.Object,
                _landUseSubZoneRepositoryMock.Object,
                _landUseZoneRepositoryMock.Object,
                _houseOwnerRepositoryMock.Object,
                _landInformationRepositoryMock.Object,
                _charkillaRepositoryMock.Object,
                _landOwnerRepositoryMock.Object,
                _userContext.Object
            );
        }

        [Test]
        public async Task GetActiveBuildingPurpose_ShouldReturnListOfBuildingPurposeDTOs()
        {
            // Arrange
            var buildingPurposes = new List<BuildingPurposeDTO>
            {
                new BuildingPurposeDTO { Id = 1, Description = "Residential" },
                new BuildingPurposeDTO { Id = 2, Description = "Commercial" }
            };

            _buildingPurposeRepositoryMock
                .Setup(repo => repo.GetActiveBuildingPurpose())
                .ReturnsAsync(buildingPurposes);

            // Act
            var result = await _applicationService.GetActiveBuildingPurpose();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(2));
        }

        //[Test]
        //public async Task CreateBuildingApplication_ShouldCallRepositoryWithCorrectParameters()
        //{
        //    // Arrange
        //    var buildingApplicationDTO = new BuildingApplicationDTO
        //    {
        //        Salutation = 1,
        //        ApplicantName = "John Doe",
        //        PhoneNumber = "1234567890",
        //        Email = "john.doe@example.com",
        //        WardNumber = 5,
        //        Address = "123 Main Street",
        //        HouseNumber = "45A",
        //        TransactionType = 1,
        //        BuildingPurpose = 1,
        //        NBCClass = 1,
        //        StructureType = 1,
        //        LandUseZone = 1,
        //        LandUseSubZone = 1,
        //    };

        //    var orgId = 1;
        //    var connectionString = "TestConnectionString";

        //    _organizationRepositoryMock
        //        .Setup(repo => repo.GetOrganizationsConfig(orgId))
        //        .ReturnsAsync(connectionString);

        //    _buildingApplicationRepositoryMock
        //        .Setup(repo => repo.AddBuildingApplicationAsync(It.IsAny<BuildingApplication>(), connectionString))
        //        .Returns(Task.CompletedTask);

        //    // Act
        //    await _applicationService.CreateBuildingApplication(buildingApplicationDTO);

        //    // Assert
        //    _organizationRepositoryMock.Verify(repo => repo.GetOrganizationsConfig(orgId), Times.Once);

        //    _buildingApplicationRepositoryMock.Verify(repo =>
        //        repo.AddBuildingApplicationAsync(
        //            It.Is<BuildingApplication>(ba =>
        //                ba.Salutation == buildingApplicationDTO.Salutation &&
        //                ba.ApplicantName == buildingApplicationDTO.ApplicantName &&
        //                ba.PhoneNumber == buildingApplicationDTO.PhoneNumber &&
        //                ba.Email == buildingApplicationDTO.Email &&
        //                ba.WardNumber == buildingApplicationDTO.WardNumber &&
        //                ba.Address == buildingApplicationDTO.Address &&
        //                ba.HouseNumber == buildingApplicationDTO.HouseNumber &&
        //                ba.TransactionType == buildingApplicationDTO.TransactionType &&
        //                ba.BuildingPurpose == buildingApplicationDTO.BuildingPurpose &&
        //                ba.NBCClass == buildingApplicationDTO.NBCClass &&
        //                ba.StructureType == buildingApplicationDTO.StructureType &&
        //                ba.LandUseZone == buildingApplicationDTO.LandUseZone &&
        //                ba.LandUseSubZone == buildingApplicationDTO.LandUseSubZone
        //            ),
        //            connectionString
        //        ), Times.Once);
        //}

        //[Test]
        //public void CreateBuildingApplication_ShouldHandleExceptionsGracefully()
        //{
        //    // Arrange
        //    var buildingApplicationDTO = new BuildingApplicationDTO
        //    {
        //        ApplicantName = "John Doe"
        //    };

        //    _organizationRepositoryMock
        //        .Setup(repo => repo.GetOrganizationsConfig(It.IsAny<int>()))
        //        .ThrowsAsync(new Exception("Database error"));

        //    // Act & Assert
        //    Assert.DoesNotThrowAsync(() => _applicationService.CreateBuildingApplication(buildingApplicationDTO));
        //}
    }
}
