using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBPS.Application.DTOs
{     
    public class LandOwnerDTO
    {
        public int LandOwnerType { get; set; }
        public int Salutation { get; set; } 
        public int LandOwnerName { get; set; }
        public string FatherName { get; set; } 
        public string GrandFatherName { get; set; } 
        public string Tole { get; set; } 
        public string CitizenshipNumber { get; set; } 
        public DateTime CitizenshipIssueDate { get; set; } 
        public DateTime CitizenshipIssueDistrict { get; set; } 
        public string PhoneNumber { get; set; } 
        public string Email { get; set; } 
        public int WardNumber { get; set; }
        public string Address { get; set; } 
    }
}
