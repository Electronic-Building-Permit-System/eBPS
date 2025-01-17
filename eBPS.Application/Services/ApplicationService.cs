﻿using eBPS.Application.DTOs;
using eBPS.Application.Interfaces.Repositories;
using eBPS.Domain.Entities;
namespace eBPS.Application.Services
{
    public interface IApplicationService
    {
        Task<IEnumerable<BuildingPurposeDTO>> GetActiveBuildingPurpose();
        Task<IEnumerable<StructureTypeDTO>> GetActiveStructureType();
        Task<IEnumerable<NBCClassDTO>> GetActiveNBCClass();
        Task<IEnumerable<WardDTO>> GetActiveWard();
        Task<IEnumerable<LandUseSubZoneDTO>> GetActiveLandUseSubZone();
        Task<IEnumerable<LandUseZoneDTO>> GetActiveLandUseZone();
        Task<IEnumerable<LandscapeTypeDTO>> GetActiveLandscapeType();
        Task<IEnumerable<TransactionTypeDTO>> GetActiveTransactionType();
        Task<IEnumerable<IssueDistrictDTO>> GetActiveIssueDistrict();
        Task<IEnumerable<BuildingApplicationDTO>> GetBuildingApplicationList();
        Task CreateBuildingApplication(BuildingApplicationDTO buildingApplicationDTO);
        Task EditBuildingApplication(int id, BuildingApplicationDTO buildingApplicationDTO);
        Task CreateHouseOwner(List<HouseOwnerDTO> houseOwnerDTO, int applicationId);
        
        Task CreateLandOwner(List<LandOwnerDTO> landOwnerDTO, int applicationId);
    }

    public class ApplicationService : IApplicationService
    {
        private readonly IBuildingPurposeRepository _buildingPurposeRepository;
        private readonly IStructureTypeRepository _structureTypeRepository;
        private readonly INBCClassRepository _nbcClassRepository;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IBuildingApplicationRepository _buildingApplicationRepository;
        private readonly IWardRepository _wardRepository;
        private readonly ILandUseZoneRepository _landUseZoneRepository;
        private readonly ILandUseSubZoneRepository _landUseSubZoneRepository;
        private readonly IHouseOwnerRepository _houseOwnerRepository;
        private readonly ILandscapeTypeRepository _landscapeTypeRepository;
        private readonly IIssueDistrictRepository _issueDistrictRepository;
        private readonly ITransactionTypeRepository _transactionTypeRepository;
        
        private readonly ILandOwnerRepository _landOwnerRepository;

        public ApplicationService( IBuildingPurposeRepository buildingPurposeRepository, IStructureTypeRepository structureTypeRepository, INBCClassRepository nbcClassRepository, ILandscapeTypeRepository landscapeTypeRepository, IWardRepository wardRepository,
           IOrganizationRepository organizationRepository, IBuildingApplicationRepository buildingApplicationRepository, IIssueDistrictRepository issueDistrictRepository,  
            ITransactionTypeRepository transactionTypeRepository, ILandUseSubZoneRepository landUseSubZoneRepository, ILandUseZoneRepository landUseZoneRepository, IHouseOwnerRepository houseOwnerRepository, 
            ILandOwnerRepository landOwnerRepository)
        {
            _buildingPurposeRepository = buildingPurposeRepository;
            _structureTypeRepository = structureTypeRepository;
            _nbcClassRepository = nbcClassRepository;
            _landscapeTypeRepository = landscapeTypeRepository;
            _wardRepository = wardRepository;
            _organizationRepository = organizationRepository;
            _buildingApplicationRepository = buildingApplicationRepository;
            _issueDistrictRepository= issueDistrictRepository;
            _transactionTypeRepository = transactionTypeRepository;
            _landUseSubZoneRepository = landUseSubZoneRepository;
            _landUseZoneRepository = landUseZoneRepository;
            _houseOwnerRepository = houseOwnerRepository;
            
            _landOwnerRepository = landOwnerRepository;
        }
        
        public async Task<IEnumerable<BuildingPurposeDTO>> GetActiveBuildingPurpose()
        {
            return await _buildingPurposeRepository.GetActiveBuildingPurpose();
        }
        public async Task<IEnumerable<StructureTypeDTO>> GetActiveStructureType()
        {
            return await _structureTypeRepository.GetActiveStructureType();
        }

        public async Task<IEnumerable<NBCClassDTO>> GetActiveNBCClass()
        {
            return await _nbcClassRepository.GetActiveNBCClass();
        }
        public async Task<IEnumerable<WardDTO>> GetActiveWard()
        {
            return await _wardRepository.GetActiveWard();
        } 
        public async Task<IEnumerable<LandUseSubZoneDTO>> GetActiveLandUseSubZone()
        {
            return await _landUseSubZoneRepository.GetActiveLandUseSubZone();
        }   
        public async Task<IEnumerable<BuildingApplicationDTO>> GetActiveBuildingApplication()
        {
            return await _buildingApplicationRepository.GetBuildingApplicationList();
        }
        public async Task<IEnumerable<LandUseZoneDTO>> GetActiveLandUseZone()
        {
            return await _landUseZoneRepository.GetActiveLandUseZone();
        } 
        public async Task<IEnumerable<LandscapeTypeDTO>> GetActiveLandscapeType()
        {
            return await _landscapeTypeRepository.GetActiveLandscapeType();
        }
        public async Task<IEnumerable<TransactionTypeDTO>> GetActiveTransactionType()
        {
            return await _transactionTypeRepository.GetActiveTransactionType();
        }
        public async Task<IEnumerable<IssueDistrictDTO>> GetActiveIssueDistrict()
        {
            return await _issueDistrictRepository.GetActiveIssueDistrict();
            
        }
        
        public async Task<IEnumerable<BuildingApplicationDTO>> GetBuildingApplicationList()
        {
            return await _buildingApplicationRepository.GetBuildingApplicationList();
        }
        public async Task CreateBuildingApplication(BuildingApplicationDTO buildingApplicationDTO)
        {        
            try
            {
                var orgId = 1;
                var connectionString = await _organizationRepository.GetOrganizationsConfig(orgId);
                var buildingApplication = new BuildingApplication
                {
                    Salutation = buildingApplicationDTO.Salutation,
                    ApplicantName = buildingApplicationDTO.ApplicantName,
                    ApplicationNumber = buildingApplicationDTO.ApplicationNumber,
                    FatherName = buildingApplicationDTO.FatherName,
                    GrandFatherName = buildingApplicationDTO.GrandFatherName,
                    Tole = buildingApplicationDTO.Tole,
                    CitizenshipNumber = buildingApplicationDTO.CitizenshipNumber,
                    CitizenshipIssueDate = DateTime.Now,
                    CitizenshipIssueDistrict = buildingApplicationDTO.CitizenshipIssueDistrict,
                    PhoneNumber = buildingApplicationDTO.PhoneNumber,
                    Email = buildingApplicationDTO.Email,
                    WardNumber = buildingApplicationDTO.WardNumber,
                    Address = buildingApplicationDTO.Address,
                    HouseNumber = buildingApplicationDTO.HouseNumber,
                    ApplicantPhotoPath = "test",
                    TransactionType = buildingApplicationDTO.TransactionType,
                    BuildingPurpose = buildingApplicationDTO.BuildingPurpose,
                    NBCClass = buildingApplicationDTO.NBCClass,
                    StructureType = buildingApplicationDTO.StructureType,
                    LandUseZone = buildingApplicationDTO.LandUseZone,
                    LandUseSubZone = buildingApplicationDTO.LandUseSubZone,
                    CreatedDate = DateTime.Now,
                    CreatedBy = buildingApplicationDTO.CreatedBy,
                    OrganizationId = buildingApplicationDTO.OrganizationId,
                    TotalLandInRopani = buildingApplicationDTO.TotalLandInRopani,
                    TotalLandInAana = buildingApplicationDTO.TotalLandInAana,
                    TotalLandInPaisa = buildingApplicationDTO.TotalLandInPaisa,
                    TotalLandInDaam = buildingApplicationDTO.TotalLandInDaam,
                    TotalLandInSquareMeter = buildingApplicationDTO.TotalLandInSquareMeter,
                    TotalLandInSquareFeet = buildingApplicationDTO.TotalLandInSquareFeet,
                    LandLongitude = buildingApplicationDTO.LandLongitude,
                    LandLatitude = buildingApplicationDTO.LandLatitude,
                    LandSawikWard = buildingApplicationDTO.LandSawikWard,
                    LandSawikGabisa = buildingApplicationDTO.LandSawikGabisa,
                    LandToleName = buildingApplicationDTO.LandToleName,
                    LandWard = buildingApplicationDTO.LandWard,
                    IsDeleted = buildingApplicationDTO.IsDeleted
                };

                await _buildingApplicationRepository.AddBuildingApplicationAsync(buildingApplication, connectionString);
                CreateHouseOwner(buildingApplicationDTO.HouseOwnerList,buildingApplication.Id);
                CreateLandOwner(buildingApplicationDTO.LandOwnerList,buildingApplication.Id);
            }
            catch (Exception ex)
            {
            }
        }
        public async Task EditBuildingApplication(int id , BuildingApplicationDTO buildingApplicationDTO)
        {        
            try
            {
                var orgId = 1;
                var connectionString = await _organizationRepository.GetOrganizationsConfig(orgId);
                var application = await _buildingApplicationRepository.GetBuildingApplicationById(id, connectionString);
                if (application == null)
                    throw new Exception("Application not found.");

                application.Salutation = buildingApplicationDTO.Salutation;
                application.ApplicantName = buildingApplicationDTO.ApplicantName;
                application.FatherName = buildingApplicationDTO.FatherName;
                application.GrandFatherName = buildingApplicationDTO.GrandFatherName;
                application.Tole = buildingApplicationDTO.Tole;
                application.CitizenshipNumber = buildingApplicationDTO.CitizenshipNumber;
                application.CitizenshipIssueDate = DateTime.Now;
                application.CitizenshipIssueDistrict = buildingApplicationDTO.CitizenshipIssueDistrict;
                application.PhoneNumber = buildingApplicationDTO.PhoneNumber;
                application.Email = buildingApplicationDTO.Email;
                application.WardNumber = buildingApplicationDTO.WardNumber;
                application.Address = buildingApplicationDTO.Address;
                application.HouseNumber = buildingApplicationDTO.HouseNumber;
                application.ApplicantPhotoPath = "test";
                application.TransactionType = buildingApplicationDTO.TransactionType;
                application.BuildingPurpose = buildingApplicationDTO.BuildingPurpose;
                application.NBCClass = buildingApplicationDTO.NBCClass;
                application.StructureType = buildingApplicationDTO.StructureType;
                application.LandUseZone = buildingApplicationDTO.LandUseZone;
                application.LandUseSubZone = buildingApplicationDTO.LandUseSubZone;
                application.TotalLandInRopani = buildingApplicationDTO.TotalLandInRopani;
                application.TotalLandInAana = buildingApplicationDTO.TotalLandInAana;
                application.TotalLandInPaisa = buildingApplicationDTO.TotalLandInPaisa;
                application.TotalLandInDaam = buildingApplicationDTO.TotalLandInDaam;
                application.TotalLandInSquareMeter = buildingApplicationDTO.TotalLandInSquareMeter;
                application.TotalLandInSquareFeet = buildingApplicationDTO.TotalLandInSquareFeet;
                application.LandLongitude = buildingApplicationDTO.LandLongitude;
                application.LandLatitude = buildingApplicationDTO.LandLatitude;
                application.LandSawikWard = buildingApplicationDTO.LandSawikWard;
                application.LandSawikGabisa = buildingApplicationDTO.LandSawikGabisa;
                application.LandToleName = buildingApplicationDTO.LandToleName;
                application.LandWard = buildingApplicationDTO.LandWard;
                

                await _buildingApplicationRepository.UpdateBuildingApplicationAsync(buildingApplication, connectionString);
            //    CreateHouseOwner(buildingApplicationDTO.HouseOwnerList,buildingApplication.Id);
            //    CreateLandOwner(buildingApplicationDTO.LandOwnerList,buildingApplication.Id);
            }
            catch (Exception ex)
            {
            }
        }

        public async Task CreateHouseOwner(List<HouseOwnerDTO> houseOwnerDTO, int applicationId)
        {        
            try
            {
                var orgId = 1;
                var connectionString = await _organizationRepository.GetOrganizationsConfig(orgId);
               
                    await _houseOwnerRepository.AddHouseOwnerAsync(houseOwnerDTO,applicationId, connectionString);


            }
            catch (Exception ex)
            {
            }
        }
        public async Task CreateLandOwner(List<LandOwnerDTO> landOwnerDTO, int applicationId)
        {        
            try
            {
                var orgId = 1;
                var connectionString = await _organizationRepository.GetOrganizationsConfig(orgId);
               
                    await _landOwnerRepository.AddLandOwnerAsync(landOwnerDTO,applicationId, connectionString);


            }
            catch (Exception ex)
            {
            }
        }


    }
}

