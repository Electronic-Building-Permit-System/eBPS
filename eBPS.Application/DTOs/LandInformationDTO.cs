using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBPS.Application.DTOs
{
   
    public class LandInformationDTO
    {
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public string MapSheetNumber { get; set; } 
        public string LandParcelNumber { get; set; } 
        public decimal Ropani { get; set; }
        public decimal Aana { get; set; }
        public decimal Paisa { get; set; }
        public decimal Daam { get; set; }
        public decimal SquareMeter { get; set; }
        public decimal SquareFeet { get; set; }
    }

}
