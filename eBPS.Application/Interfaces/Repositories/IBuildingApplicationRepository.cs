using eBPS.Application.DTOs;
using eBPS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBPS.Application.Interfaces.Repositories
{
    public interface IBuildingApplicationRepository
    {
        Task AddBuildingApplicationAsync(BuildingApplicationDTO buildingApplication);
    }
}
