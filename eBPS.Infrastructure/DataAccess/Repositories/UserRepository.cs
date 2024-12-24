﻿using Dapper;
using eBPS.Domain.Entities;
using eBPS.Application.Interfaces.Repositories;
using System.Data;
using eBPS.Application.Interfaces;

namespace eBPS.Infrastructure.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Users> GetByUsernameAsync(string username)
        {
            var query = "SELECT * FROM Users WHERE Username = @Username";
            return await _unitOfWork.Connection.QuerySingleOrDefaultAsync<Users>(query, new { Username = username }, _unitOfWork.Transaction);
        }

        public async Task AddUserAsync(Users user)
        {
            var query = @"
            INSERT INTO Users (Username, Email, PasswordHash, IsActive, CreatedDate, FirstName, LastName, PhoneNumber)
            VALUES (@Username, @Email, @PasswordHash, @IsActive, @CreatedDate, @FirstName, @LastName, @PhoneNumber);
            SELECT CAST(SCOPE_IDENTITY() AS INT)";
            user.Id = await _unitOfWork.Connection.ExecuteScalarAsync<int>(query, user, _unitOfWork.Transaction);
        }

        public async Task AddUserOrganizationsAsync(IEnumerable<UserOrganizations> userOrganizations)
        {
            var query = @"INSERT INTO UserOrganizations (UserId, RoleId, OrganizationId)
                        VALUES (@UserId, @RoleId, @OrganizationId)";

            await _unitOfWork.Connection.ExecuteAsync(query, userOrganizations, _unitOfWork.Transaction);
        }
    }
}
