using System.ComponentModel.DataAnnotations;

namespace eBPS.Application.DTOs.BuildingApplication
{
    public class ApplicationDetailsDTO
    {
        public int TransactionType { get; set; } 
        public int BuildingPurpose { get; set; } 
        public int NBCClass { get; set; } 
        public int LandUseZone { get; set; } 
        public int LandUseSubZone { get; set; }
        public int StructureType { get; set; }
        public double LandLongitude { get; set; }
        public double LandLatitude { get; set; }
        public int LandSawikWard { get; set; }
        public string LandSawikGabisa { get; set; }
        public string LandToleName { get; set; }
        public int LandWard { get; set; }
    }
}
