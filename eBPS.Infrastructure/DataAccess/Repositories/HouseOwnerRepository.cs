using Dapper;
using eBPS.Application.DTOs.BuildingApplication;
using eBPS.Application.Interfaces.Repositories;
using eBPS.Domain.Entities;
using Microsoft.Data.SqlClient;
using System.Data;

namespace eBPS.Infrastructure.DataAccess.Repositories
{
    public class HouseOwnerRepository : IHouseOwnerRepository
    {
        private readonly IDbConnection _dbConnection;

        public HouseOwnerRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task AddHouseOwnerAsync(List<HouseOwnerDTO> houseOwner,int applicationId, string connectionString)
        {
            using var connection = new SqlConnection(connectionString);
            var query = @"INSERT INTO HouseOwner (
                    ApplicationId,
                    Salutation,
                    HouseOwnerType,
                    HouseOwnerName,
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
                    HouseOwnerPhotoPath
                )
                VALUES
                (
                    @ApplicationId,
                    @Salutation,
                    @HouseOwnerType,
                    @HouseOwnerName,
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
                    'test'
            )";
            // Add the applicationId to each house owner DTO
            foreach (var owner in houseOwner)
            {
                owner.ApplicationId = applicationId;
            }

            await connection.ExecuteAsync(query, houseOwner);
        }

    }
}
