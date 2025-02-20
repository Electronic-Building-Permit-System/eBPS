﻿

using eBPS.Application.DTOs.BuildingApplication;

namespace eBPS.Application.Interfaces.Repositories
{
    public interface ILandOwnerRepository
    {
        Task AddLandOwnerAsync(List<LandOwnerDTO> landOwner, int applicationId, string connectionString);
    }
}
