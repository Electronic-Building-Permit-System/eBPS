using eBPS.Application.DTOs;
using eBPS.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
namespace eBPS.Application.Services
{
    public interface IApplicationService
    {
        Task<IEnumerable<BuildingPurposeDTO>> GetActiveBuildingPurpose();
    }
    public class ApplicationService : IApplicationService
    {
        private readonly IBuildingPurposeRepository _buildingPurposeRepository;

        public ApplicationService(IBuildingPurposeRepository buildingPurposeRepository)
        {
            _buildingPurposeRepository = buildingPurposeRepository;
        }
        public async Task<IEnumerable<BuildingPurposeDTO>> GetActiveBuildingPurpose()
        {
            return await _buildingPurposeRepository.GetActiveBuildingPurpose();
        }

    }
}
