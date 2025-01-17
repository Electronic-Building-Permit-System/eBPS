using Dapper;
using eBPS.Application.DTOs;
using eBPS.Application.Interfaces.Repositories;
using eBPS.Domain.Entities;
using Microsoft.Data.SqlClient;
using System.Data;

namespace eBPS.Infrastructure.DataAccess.Repositories
{
    public class LandInformationRepository : ILandInformationRepository
    {
        private readonly IDbConnection _dbConnection;

        public LandInformationRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task AddLandInformationAsync(List<LandInformationDTO> landInformation, int applicationId, string connectionString)
        {
            using var connection = new SqlConnection(connectionString);
            var query = @"INSERT INTO LandInformation (
                    ApplicationId,
                    MapSheetNumber,
                    LandParcelNumber,
                    Ropani,
                    Aana,
                    Paisa,
                    Daam,
                    SquareMeter,
                    SquareFeet
                )
                VALUES
                (
                    @ApplicationId,
                    @MapSheetNumber,
                    @LandParcelNumber,
                    @Ropani,
                    @Aana,
                    @Paisa,
                    @Daam,
                    @SquareMeter,
                    @SquareFeet
                )";
            // Add the applicationId to each house owner DTO
            foreach (var owner in landInformation)
            {
                owner.ApplicationId = applicationId;
            }

            await connection.ExecuteAsync(query, landInformation);
        }

    }
}
