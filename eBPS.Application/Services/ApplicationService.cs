﻿using eBPS.Application.DTOs;
using eBPS.Application.Interfaces.Repositories;
using eBPS.Domain.Entities;
using System.Security.Cryptography;
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
    }

    public class ApplicationService : IApplicationService
    {
        private readonly IBuildingPurposeRepository _buildingPurposeRepository;
        private readonly IStructureTypeRepository _structureTypeRepository;
        private readonly INBCClassRepository _nbcClassRepository;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IBuildingApplicationRepository _buildingApplicationRepository;
        private readonly IWardRepository _wardRepository;
        private readonly ILandUseZoneRepository _landusezoneRepository;
        private readonly ILandscapeTypeRepository _landscapeTypeRepository;
        private readonly IIssueDistrictRepository _issueDistrictRepository;
        private readonly ITransactionTypeRepository _transactionTypeRepository;

        public ApplicationService(IIssueDistrictRepository issueDistrictRepository,ITransactionTypeRepository transactionTypeRepository, IBuildingPurposeRepository buildingPurposeRepository, ILandUseZoneRepository landusezoneRepository, IStructureTypeRepository structureTypeRepository, INBCClassRepository nbcClassRepository, IOrganizationRepository organizationRepository, IBuildingApplicationRepository buildingApplicationRepository, IWardRepository wardRepository, ILandscapeTypeRepository landscapeTypeRepository)
        private readonly ILandUseSubZoneRepository _landUseSubZoneRepository;
        private readonly ILandUseZoneRepository _landUseZoneRepository;

        public ApplicationService(IBuildingPurposeRepository buildingPurposeRepository, ILandUseZoneRepository landUseZoneRepository, 
            IStructureTypeRepository structureTypeRepository, INBCClassRepository nbcClassRepository,IOrganizationRepository organizationRepository, 
            IBuildingApplicationRepository buildingApplicationRepository,IWardRepository wardRepository,ILandUseSubZoneRepository landUseSubZoneRepository)
        {
            _buildingPurposeRepository = buildingPurposeRepository;
            _structureTypeRepository = structureTypeRepository;
            _nbcClassRepository = nbcClassRepository;
            _landscapeTypeRepository = landscapeTypeRepository;
            _wardRepository = wardRepository;
            _organizationRepository = organizationRepository;
            _buildingApplicationRepository = buildingApplicationRepository;
          _landusezoneRepository= landusezoneRepository;
            _issueDistrictRepository= issueDistrictRepository;
            _transactionTypeRepository = transactionTypeRepository;


            _landUseSubZoneRepository = landUseSubZoneRepository;
            _landUseZoneRepository = landUseZoneRepository;
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
            return await _landusezoneRepository.GetActiveLandUseZone();
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
            return await _landUseZoneRepository.GetActiveLandUseZone();
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
                };

                await _buildingApplicationRepository.AddBuildingApplicationAsync(buildingApplication, connectionString);

            }
            catch (Exception ex)
            {
            }
        }


    }
}
