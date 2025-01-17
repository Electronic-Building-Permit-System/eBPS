using System.ComponentModel.DataAnnotations;

namespace eBPS.Application.DTOs.BuildingApplication
{
    public class CharkillaDTO
    {
        public int? ApplicationId { get; set; }
        [Required]
        public string Direction { get; set; }

        [Required]
        public string Side { get; set; }

        [Required]
        public string RoadName { get; set; }

        [Required]
        public object LandscapeType { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double RoadLength { get; set; }

        [Required]
        public string ExistingRow { get; set; }

        [Required]
        public string ActualSetback { get; set; }
    }

}
