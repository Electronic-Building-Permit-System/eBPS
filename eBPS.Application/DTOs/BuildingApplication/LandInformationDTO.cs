using System.ComponentModel.DataAnnotations;

namespace eBPS.Application.DTOs.BuildingApplication
{
    public class LandInformationDTO
    {
        public int? ApplicationId { get; set; }
        public string MapSheetNumber { get; set; }

        public string LandParcelNumber { get; set; }

        public double Ropani { get; set; }

        public double Aana { get; set; }

        public double Paisa { get; set; } 

        public double Daam { get; set; } 

        public double SquareFeet { get; set; } 

        public double SquareMeter { get; set; } 
    }

}
