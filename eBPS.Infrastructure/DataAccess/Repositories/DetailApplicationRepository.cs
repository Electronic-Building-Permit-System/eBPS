using Dapper;
using eBPS.Application.DTOs.BuildingApplication;
using eBPS.Application.Interfaces.Repositories;
using eBPS.Domain.Entities;
using Microsoft.Data.SqlClient;
using System.Data;

namespace eBPS.Infrastructure.DataAccess.Repositories
{
    public class DetailApplicationRepository : IDetailApplicationRepository
    {
        private readonly IDbConnection _dbConnection;

        public DetailApplicationRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task<DetailApplicationDTO> GetDetailApplicationById(int id, string connectionString)
        {
            using var connection = new SqlConnection(connectionString);
            const string query = "SELECT * FROM BuildingApplication where Id=@Id";
            return await connection.QueryFirstOrDefaultAsync<DetailApplicationDTO>(query, new { Id = id });
        }

    }
}
