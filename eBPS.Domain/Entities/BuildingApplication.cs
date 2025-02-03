
namespace eBPS.Domain.Entities
{
    public class BuildingApplication
    {
        public int Id { get; set; }
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
        public string ApplicantPhotoPath { get; set; }
        public int TransactionType { get; set; }
        public int BuildingPurpose { get; set; }
        public int NBCClass { get; set; }
        public int StructureType { get; set; }
        public int LandUseZone { get; set; }
        public int LandUseSubZone { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public int OrganizationId { get; set; }
        public double TotalLandInRopani { get; set; }
        public double TotalLandInAana { get; set; }
        public double TotalLandInPaisa { get; set; }
        public double TotalLandInDaam { get; set; }
        public double TotalLandInSquareMeter { get; set; }
        public double TotalLandInSquareFeet { get; set; }
        public double LandLongitude { get; set; }
        public double LandLatitude { get; set; }
        public int LandSawikWard { get; set; }
        public string LandSawikGabisa { get; set; }
        public string LandToleName { get; set; }
        public int LandWard { get; set; }
        public bool IsDeleted { get; set; }
    }
}
