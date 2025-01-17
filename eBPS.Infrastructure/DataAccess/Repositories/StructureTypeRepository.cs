using Dapper;
using eBPS.Application.DTOs.BuildingApplication;
using eBPS.Application.Interfaces.Repositories;
using System.Data;

namespace eBPS.Infrastructure.DataAccess.Repositories
{
    public class StructureTypeRepository : IStructureTypeRepository
    {
        private readonly IDbConnection _dbConnection;
        public StructureTypeRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task<IEnumerable<StructureTypeDTO>> GetActiveStructureType()
        {
            const string query = "SELECT Id, Description FROM StructureType WHERE IsActive = 1";
            return await _dbConnection.QueryAsync<StructureTypeDTO>(query);
        }
    }
}
