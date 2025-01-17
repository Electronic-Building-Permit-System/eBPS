
using Microsoft.AspNetCore.Http;

namespace eBPS.Application.DTOs
{
    public class BuildingApplicationDTO
    {
        public int Salutation { get; set; }
        public string ApplicantName { get; set; }
        public string ApplicationNumber { get; set; }
        public string FatherName { get; set; }
        public string GrandFatherName { get; set; }
        public string Tole { get; set; }
        public string CitizenshipNumber { get; set; }
        public DateTime CitizenshipIssueDate { get; set; }
        public int CitizenshipIssueDistrict { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int WardNumber { get; set; }
        public string Address { get; set; }
        public string HouseNumber { get; set; }
        public IFormFile ApplicantPhotoPath { get; set; }
        public int TransactionType { get; set; }
        public int BuildingPurpose { get; set; }
        public int NBCClass { get; set; }
        public int StructureType { get; set; }
        public int LandUseZone { get; set; }
        public int LandUseSubZone { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public int OrganizationId { get; set; }
        public decimal TotalLandInRopani { get; set; }
        public decimal TotalLandInAana { get; set; }
        public decimal TotalLandInPaisa { get; set; }
        public decimal TotalLandInDaam { get; set; }
        public decimal TotalLandInSquareMeter { get; set; }
        public decimal TotalLandInSquareFeet { get; set; }
        public decimal LandLongitude { get; set; }
        public decimal LandLatitude { get; set; }
        public int LandSawikWard { get; set; }
        public string LandSawikGabisa { get; set; }
        public string LandToleName { get; set; }
        public int LandWard { get; set; }
        public bool IsDeleted { get; set; }
        public List<HouseOwnerDTO> HouseOwnerList { get; set; }
        public List<LandInformationDTO> LandInformationList {  get; set; }
        public List<CharkillaDTO> CharkillaList {  get; set; }
        public List<LandOwnerDTO> LandOwnerList { get; set; }

    }
}
