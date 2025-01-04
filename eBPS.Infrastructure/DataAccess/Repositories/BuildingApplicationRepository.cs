using Dapper;
using eBPS.Application.DTOs;
using eBPS.Application.Interfaces.Repositories;
using System.Data;

namespace eBPS.Infrastructure.DataAccess.Repositories
{
    public class BuildingApplicationRepository : IBuildingApplicationRepository
    {
        private readonly IDbConnection _dbConnection;

        public BuildingApplicationRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task AddBuildingApplicationAsync(BuildingApplicationDTO buildingApplication, int orgId)
        {       
            var query = @"
           INSERT INTO BuildingApplication (
                    Salutation,
                    ApplicantName,
                    PhoneNumber,
                    Email,
                    WardNumber,
                    Address,
                    HouseNumber,
                    ApplicantPhotoPath,
                    TransactionType,
                    BuildingPurpose,
                    NBCClass,
                    StructureType,
                    LandUseZone,
                    LandUseSubZone
                )
                VALUES (
                    @Salutation,
                    @ApplicantName,
                    @PhoneNumber,
                    @Email,
                    @WardNumber,
                    @Address,
                    @HouseNumber,
                    @ApplicantPhotoPath,
                    @TransactionType,
                    @BuildingPurpose,
                    @NBCClass,
                    @StructureType,
                    @LandUseZone,
                    @LandUseSubZone
                );";
            return await _dbConnection.QuerySingleOrDefaultAsync<BuildingApplicationDTO>(query, new { OrgId = orgId });
        }
    }
}
