using eBPS.Application.DTOs.BuildingApplication;
using eBPS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBPS.Application.Interfaces.Repositories
{
    public interface IDetailApplicationRepository
    {
        Task<IEnumerable<DetailApplicationDTO>> GetDetailApplicationList();
        Task<BuildingApplication> GetDetailApplicationById(int id, string connectionString);
    }
}
