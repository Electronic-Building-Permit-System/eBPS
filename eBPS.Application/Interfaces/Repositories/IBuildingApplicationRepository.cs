﻿using eBPS.Application.DTOs;
using eBPS.Domain.Entities;

namespace eBPS.Application.Interfaces.Repositories
{
    public interface IBuildingApplicationRepository
    {
        Task AddBuildingApplicationAsync(BuildingApplication buildingApplication, string connectionString);
    }
}
