using System.ComponentModel.DataAnnotations;

namespace eBPS.Application.DTOs.BuildingApplication
{
    public class ApplicantDetailsDTO
    {
        [Required]
        public string Salutation { get; set; } 

        [Required]
        public string ApplicantName { get; set; } 

        [Required]
        public int WardNumber { get; set; } 

        [Required]
        public string Address { get; set; } 

        [Required]
        public string HouseNumber { get; set; } 

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }

}
