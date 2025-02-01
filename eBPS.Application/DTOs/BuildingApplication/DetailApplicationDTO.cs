using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBPS.Application.DTOs.BuildingApplication
{
    public class DetailApplicationDTO
    {
        public ApplicantDetailsDTO ApplicantDetails { get; set; }
        public ApplicationDetailsDTO ApplicationDetails { get; set; }
        public List<HouseOwnerDTO> HouseOwnerList { get; set; }
        public List<LandOwnerDTO> LandOwnerList { get; set; }
        public List<LandInformationDTO> LandInformationList { get; set; }
        public List<CharkillaDTO> CharkillaList { get; set; }
    }
}
