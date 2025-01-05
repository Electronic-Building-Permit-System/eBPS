﻿using Dapper;
using eBPS.Application.DTOs;
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
        public async Task AddBuildingApplicationAsync(BuildingApplication buildingApplication, string connectionString)
        {
            using var connection = new SqlConnection(connectionString);
            var query = @"INSERT INTO BuildingApplication (
                    Salutation,
                    ApplicantName,
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
                    LandUseSubZone
                )
                VALUES (
                    @Salutation,
                    @ApplicantName,
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
                    @LandUseSubZone
                );";
            await connection.QuerySingleOrDefaultAsync<BuildingApplicationDTO>(query, buildingApplication);
        }
    }
}
