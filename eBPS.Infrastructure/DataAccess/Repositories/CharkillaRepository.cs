using Dapper;
using eBPS.Application.DTOs;
using eBPS.Application.Interfaces.Repositories;
using eBPS.Domain.Entities;
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
                    @LandscapeTypeId,
                    @CharkillaName,
                    @RoadId,
                    @IsGLD,
                    @RoadLength,
                    @ProposedROW,
                    @ExistingROW,
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
