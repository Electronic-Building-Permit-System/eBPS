using Dapper;
using eBPS.Domain.Entities;
using eBPS.Infrastructure.Interfaces;
using System.Data;

namespace eBPS.Infrastructure.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnection _dbConnection;

        public UserRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<Users> GetByUsernameAsync(string username)
        {
            var query = "SELECT * FROM Users WHERE Username = @Username";
            return await _dbConnection.QuerySingleOrDefaultAsync<Users>(query, new { Username = username });
        }

        public async Task AddUserAsync(Users user)
        {
            var query = @"
            INSERT INTO Users (Username, Email, PasswordHash, IsActive, CreatedAt)
            VALUES (@Username, @Email, @PasswordHash, @IsActive, @CreatedAt)";
            await _dbConnection.ExecuteAsync(query, user);
        }
    }
}
