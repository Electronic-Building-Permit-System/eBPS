using eBPS.Application.DTOs.BuildingApplication;
using eBPS.Application.DTOs.BuildingApplication.Dashboard;

namespace eBPS.Application.Interfaces
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
        Task<IEnumerable<DistrictDTO>> GetActiveIssueDistrict();
        Task<IEnumerable<ApplicationDTO>> GetBuildingApplicationList();
        Task CreateBuildingApplication(BuildingApplicationDTO buildingApplicationDTO);
        Task EditBuildingApplication(int id, BuildingApplicationDTO buildingApplicationDTO);
        Task CreateHouseOwner(List<HouseOwnerDTO> houseOwnerDTO, int applicationId);
        Task CreateLandInformation(List<LandInformationDTO> landInformationDTO, int applicationId);
        Task CreateCharkilla(List<CharkillaDTO> charkillaDTO, int applicationId);
        Task CreateLandOwner(List<LandOwnerDTO> landOwnerDTO, int applicationId);
    }
}
