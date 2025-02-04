namespace eBPS.Application.DTOs.BuildingApplication
{
    public class BuildingApplicationDTO
    {
        public ApplicantDetailsDTO ApplicantDetails { get; set; }
        public ApplicationDetailsDTO ApplicationDetails { get; set; }
        public List<HouseOwnerDTO> HouseOwnerList { get; set; }
        public List<LandOwnerDTO> LandOwnerList { get; set; }
        public List<LandInformationDTO> LandInformationList { get; set; }
        public List<CharkillaDTO> CharkillaList { get; set; }

    }
}
