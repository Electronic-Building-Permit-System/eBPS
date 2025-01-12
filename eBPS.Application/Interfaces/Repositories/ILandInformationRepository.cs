using eBPS.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBPS.Application.Interfaces.Repositories
{
     public interface  ILandInformationRepository
    {
        Task AddLandInformationAsync(List<LandInformationDTO> houseOwner, int applicationId, string connectionString);
    }
}
