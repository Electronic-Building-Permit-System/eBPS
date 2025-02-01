using Dapper;
using eBPS.Application.DTOs.BuildingApplication;
using eBPS.Application.DTOs.BuildingApplication.Dashboard;
using eBPS.Application.Interfaces;
using eBPS.Application.Interfaces.Repositories;
using eBPS.Domain.Entities;
using Microsoft.Data.SqlClient;
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

        public async Task<IEnumerable<ApplicationDTO>> GetBuildingApplicationList()
        {
            var connectionString = "Server=.;Database=LalitpurEbps;Integrated Security=true;TrustServerCertificate=True;";
            using var connection = new SqlConnection(connectionString);
            const string query = "SELECT ApplicantName, ApplicationNumber, WardNumber, TransactionType FROM BuildingApplication";
            return await connection.QueryAsync<ApplicationDTO>(query);
        }
        public async Task<BuildingApplication> GetBuildingApplicationById(int id, string connectionString)
        {
            using var connection = new SqlConnection(connectionString);
            const string query = "SELECT * FROM BuildingApplication where Id=@Id";
            return await connection.QueryFirstOrDefaultAsync<BuildingApplication>(query, new { Id = id });
        }

        public async Task AddBuildingApplicationAsync(BuildingApplication buildingApplication, string connectionString)
        {
            using var connection = new SqlConnection(connectionString);
            var query = @"INSERT INTO BuildingApplication (
                        Salutation,
                        ApplicantName,
                        ApplicationNumber,
                        FatherName,
                        GrandFatherName,
                        Tole,
                        CitizenshipNumber,
                        CitizenshipIssueDate,
                        CitizenshipIssueDistrict,
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
                        LandUseSubZone,
                        CreatedDate,
                        CreatedBy,
                        OrganizationId,
                        TotalLandInRopani,
                        TotalLandInAana,
                        TotalLandInPaisa,
                        TotalLandInDaam,
                        TotalLandInSquareMeter,
                        TotalLandInSquareFeet,
                        LandLongitude,
                        LandLatitude,
                        LandSawikWard,
                        LandSawikGabisa,
                        LandToleName,
                        LandWard,
                        IsDeleted
                    ) 
                    OUTPUT INSERTED.Id
                    VALUES (
                        @Salutation,
                        @ApplicantName,
                        @ApplicationNumber,
                        @FatherName,
                        @GrandFatherName,
                        @Tole,
                        @CitizenshipNumber,
                        @CitizenshipIssueDate,
                        @CitizenshipIssueDistrict,
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
                        @LandUseSubZone,
                        @CreatedDate,
                        @CreatedBy,
                        @OrganizationId,
                        @TotalLandInRopani,
                        @TotalLandInAana,
                        @TotalLandInPaisa,
                        @TotalLandInDaam,
                        @TotalLandInSquareMeter,
                        @TotalLandInSquareFeet,
                        @LandLongitude,
                        @LandLatitude,
                        @LandSawikWard,
                        @LandSawikGabisa,
                        @LandToleName,
                        @LandWard,
                        @IsDeleted)";

            buildingApplication.Id = await connection.ExecuteScalarAsync<int>(query, buildingApplication);
        }

    }
}
