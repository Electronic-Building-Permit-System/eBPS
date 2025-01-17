using System.ComponentModel.DataAnnotations;

namespace eBPS.Application.DTOs.BuildingApplication
{
    public class LandInformationDTO
    {
        public int? ApplicationId { get; set; }
        [Required]
        public string MapSheet { get; set; }

        [Required]
        public string LandParcel { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Ropani must be a non-negative number.")]
        public double Ropani { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Aana must be a non-negative number.")]
        public double Aana { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Paisa must be a non-negative number.")]
        public double Paisa { get; set; } 

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Daam must be a non-negative number.")]
        public double Daam { get; set; } 

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "SquareFeet must be a non-negative number.")]
        public double SquareFeet { get; set; } 

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "SquareMeter must be a non-negative number.")]
        public double SquareMeter { get; set; } 
    }

}
