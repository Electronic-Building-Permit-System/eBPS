using System.ComponentModel.DataAnnotations;

namespace eBPS.Application.DTOs.BuildingApplication
{
    public class ApplicationDetailsDTO
    {
        [Required]
        public int TransactionType { get; set; } 

        [Required]
        public int BuildingPurpose { get; set; } 

        [Required]
        public int NbcClass { get; set; } 

        [Required]
        public int LandUseZone { get; set; } 

        [Required]
        public int LandUseSubZone { get; set; }

        [Required]
        public int StructureType { get; set; } 
    }

}
