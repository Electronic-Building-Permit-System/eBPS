using Dapper;
using eBPS.Application.DTOs.BuildingApplication;
using eBPS.Application.Interfaces.Repositories;
using Microsoft.Data.SqlClient;
using System.Data;

namespace eBPS.Infrastructure.DataAccess.Repositories
{
    public class LandOwnerRepository : ILandOwnerRepository
    {
        private readonly IDbConnection _dbConnection;

        public LandOwnerRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task AddLandOwnerAsync(List<LandOwnerDTO> landOwner, int applicationId, string connectionString)
        {
            using var connection = new SqlConnection(connectionString);
            var query = @"INSERT INTO LandOwner (
                        
                        ApplicationId,
                        Salutation,
                        LandOwnerType,
                        LandOwnerName,
                        FatherName,
                        GrandFatherName,
                        Tole,
                        CitizenshipNumber,
                        CitizenshipIssueDate,
                        CitizenshipIssueDistrict,
                        PhoneNumber,
                        Email,
                        WardNumber,
                        Address
                    )
                    VALUES (
                       
                        @ApplicationId,
                        @Salutation,
                        @LandOwnerType,
                        @LandOwnerName,
                        @FatherName,
                        @GrandFatherName,
                        @Tole,
                        @CitizenshipNumber,
                        @CitizenshipIssueDate,
                        @CitizenshipIssueDistrict,
                        @PhoneNumber,
                        @Email,
                        @WardNumber,
                        @Address
                    );";
            // Add the applicationId to each house owner DTO
            foreach (var owner in landOwner)
            {
                owner.ApplicationId = applicationId;
            }
            await connection.ExecuteAsync(query, landOwner);
        }

    }
}
