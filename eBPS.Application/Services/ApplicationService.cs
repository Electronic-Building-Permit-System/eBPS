using eBPS.Application.DTOs;
using eBPS.Application.Interfaces.Repositories;
using eBPS.Domain.Entities;
namespace eBPS.Application.Services
{
    public interface IApplicationService
    {
        Task<IEnumerable<BuildingPurposeDTO>> GetActiveBuildingPurpose();
        Task<IEnumerable<NBCClassDTO>> GetActiveNBCClass();
        Task CreateBuildingApplication(BuildingApplicationDTO buildingApplicationDTO);
        Task<object> GetOrganizationsConfig(int orgId);

    }

    public class ApplicationService : IApplicationService
    {
        private readonly IBuildingPurposeRepository _buildingPurposeRepository;
        private readonly INBCClassRepository _nbcClassRepository;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IBuildingApplicationRepository _buildingApplicationRepository;

        public ApplicationService(IBuildingPurposeRepository buildingPurposeRepository, INBCClassRepository nbcClassRepository, IOrganizationRepository organizationRepository, IBuildingApplicationRepository buildingApplicationRepository)
        {
            _buildingPurposeRepository = buildingPurposeRepository;
            _nbcClassRepository = nbcClassRepository;
            _organizationRepository = organizationRepository;
            _buildingApplicationRepository = buildingApplicationRepository;
        }
        public async Task<IEnumerable<BuildingPurposeDTO>> GetActiveBuildingPurpose()
        {
            return await _buildingPurposeRepository.GetActiveBuildingPurpose();
        }
        public async Task<IEnumerable<NBCClassDTO>> GetActiveNBCClass()
        {
            return await _nbcClassRepository.GetActiveNBCClass();
        }
        public async Task<object> GetOrganizationsConfig(int orgId)
        {
           
            var connectionString = await _organizationRepository.GetOrganizationsConfig(orgId);
            return await _organizationRepository.GetData(connectionString);
        }
        public async Task CreateBuildingApplication(BuildingApplicationDTO buildingApplicationDTO)
        {        
            try
            {
                // Create a new user
                var buildingApplication = new BuildingApplicationDTO
                {
                    Salutation = buildingApplicationDTO.Salutation,
                    ApplicantName = buildingApplicationDTO.ApplicantName,
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
                };

                // Save the user to the database
                await _buildingApplicationRepository.AddBuildingApplicationAsync(buildingApplication);

            }
            catch (Exception ex)
            {
            }
        }


    }
}
