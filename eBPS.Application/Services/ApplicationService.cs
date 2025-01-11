using eBPS.Application.DTOs;
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
        Task<IEnumerable<BuildingApplicationDTO>> GetBuildingApplicationList();
        Task CreateBuildingApplication(BuildingApplicationDTO buildingApplicationDTO);
        Task CreateHouseOwner(List<HouseOwnerDTO> houseOwnerDTO, int applicationId);
    }

    public class ApplicationService : IApplicationService
    {
        private readonly IBuildingPurposeRepository _buildingPurposeRepository;
        private readonly IStructureTypeRepository _structureTypeRepository;
        private readonly INBCClassRepository _nbcClassRepository;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IBuildingApplicationRepository _buildingApplicationRepository;
        private readonly IWardRepository _wardRepository;
        private readonly ILandUseSubZoneRepository _landUseSubZoneRepository;
        private readonly ILandUseZoneRepository _landUseZoneRepository;
        private readonly IHouseOwnerRepository _houseOwnerRepository;

        public ApplicationService(IBuildingPurposeRepository buildingPurposeRepository, ILandUseZoneRepository landUseZoneRepository, 
            IStructureTypeRepository structureTypeRepository, INBCClassRepository nbcClassRepository,IOrganizationRepository organizationRepository, 
            IBuildingApplicationRepository buildingApplicationRepository,IWardRepository wardRepository,ILandUseSubZoneRepository landUseSubZoneRepository,
            IHouseOwnerRepository houseOwnerRepository)
        {
            _buildingPurposeRepository = buildingPurposeRepository;
            _structureTypeRepository = structureTypeRepository;
            _nbcClassRepository = nbcClassRepository;
            _wardRepository= wardRepository;
            _organizationRepository = organizationRepository;
            _buildingApplicationRepository = buildingApplicationRepository;
            _landUseSubZoneRepository = landUseSubZoneRepository;
            _landUseZoneRepository = landUseZoneRepository;
            _houseOwnerRepository = houseOwnerRepository;
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
                    ApplicantNumber = buildingApplicationDTO.ApplicantNumber,
                    FatherName = buildingApplicationDTO.FatherName,
                    GrandFatherName = buildingApplicationDTO.GrandFatherName,
                    Tole = buildingApplicationDTO.Tole,
                    CitizenshipNumber = buildingApplicationDTO.CitizenshipNumber,
                    CitizenshipIssueDate = DateTime.Now,
                    CitizenshipIssueDistrict = DateTime.Now,
                    PhoneNumber = buildingApplicationDTO.PhoneNumber,
                    Email = buildingApplicationDTO.Email,
                    WardNumber = buildingApplicationDTO.WardNumber,
                    Address = buildingApplicationDTO.Address,
                    HouseNumber = buildingApplicationDTO.HouseNumber,
                    ApplicantPhotoPath = buildingApplicationDTO.ApplicantPhotoPath,
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
                foreach (var owner in houseOwnerDTO)
                {

                    var houseOwner = new HouseOwner
                    {
                        ApplicationId=applicationId,
                        Salutation = owner.Salutation,
                        HouseOwnerName = owner.HouseOwnerName,
                        FatherName = owner.FatherName,
                        GrandFatherName = owner.GrandFatherName,
                        CitizenshipNumber = owner.CitizenshipNumber,
                        CitizenshipIssueDistrict = owner.CitizenshipIssueDistrict,
                        CitizenshipIssueDate = owner.CitizenshipIssueDate,
                        Tole = owner.Tole,
                        WardNumber = owner.WardNumber,
                        PhoneNumber = owner.PhoneNumber,
                        Email = owner.Email,
                    };
                    await _houseOwnerRepository.AddHouseOwnerAsync(houseOwner, connectionString);

                }

            }
            catch (Exception ex)
            {
            }
        }


    }
}

