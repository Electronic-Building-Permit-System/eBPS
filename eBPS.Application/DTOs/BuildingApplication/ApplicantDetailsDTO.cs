using System.ComponentModel.DataAnnotations;

namespace eBPS.Application.DTOs.BuildingApplication
{
    public class ApplicantDetailsDTO
    {
        public int Salutation { get; set; } 
        public string ApplicantName { get; set; } 
        public string ApplicationNumber { get; set; } 
        public string FatherName { get; set; } 
        public string GrandFatherName { get; set; } 
        public string Tole { get; set; } 
        public string CitizenshipNumber { get; set; } 
        public object CitizenshipIssueDate { get; set; } 
        public int CitizenshipIssueDistrict { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int WardNumber { get; set; } 
        public string Address { get; set; } 
        public string HouseNumber { get; set; } 
        public string? ApplicantPhotoPath { get; set; } 
        
    }

}
