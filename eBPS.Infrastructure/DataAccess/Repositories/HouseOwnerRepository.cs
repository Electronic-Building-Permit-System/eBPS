using Dapper;
using eBPS.Application.DTOs;
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

        public async Task AddHouseOwnerAsync(HouseOwner houseOwner, string connectionString)
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
                    Address
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
                    @Address;";
            await connection.QuerySingleOrDefaultAsync<HouseOwnerDTO>(query, houseOwner);
        }

    }
}
