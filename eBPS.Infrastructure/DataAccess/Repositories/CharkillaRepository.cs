using Dapper;
using eBPS.Application.DTOs.BuildingApplication;
using eBPS.Application.Interfaces.Repositories;
using Microsoft.Data.SqlClient;
using System.Data;

namespace eBPS.Infrastructure.DataAccess.Repositories
{
    public class CharkillaRepository : ICharkillaRepository
    {
        private readonly IDbConnection _dbConnection;

        public CharkillaRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task AddCharkillaAsync(List<CharkillaDTO> charkilla, int applicationId, string connectionString)
        {
            using var connection = new SqlConnection(connectionString);
            var query = @"INSERT INTO Charkilla (
                    ApplicationId,
                    Direction,
                    Side,
                    LandscapeTypeId,
                    CharkillaName,
                    RoadId,
                    IsGLD,
                    RoadLength,
                    ProposedROW,
                    ExistingROW,
                    ActualSetback,
                    StandardSetback,
                    Kitta
                ) VALUES (
                    @ApplicationId,
                    @Direction,
                    @Side,
                    @LandscapeType,
                    @CharkillaName,
                    @RoadId,
                    @IsGLD,
                    @RoadLength,
                    @ProposedRow,
                    @ExistingRow,
                    @ActualSetback,
                    @StandardSetback,
                    @Kitta
                );";
            // Add the applicationId to each house owner DTO
            foreach (var owner in charkilla)
            {
                owner.ApplicationId = applicationId;
            }

            await connection.ExecuteAsync(query, charkilla);
        }

    }
}
