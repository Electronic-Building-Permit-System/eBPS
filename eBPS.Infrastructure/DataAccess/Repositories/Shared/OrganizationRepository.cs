using Dapper;
using eBPS.Application.DTOs.Shared;
using eBPS.Application.Interfaces;
using eBPS.Application.Interfaces.Repositories;

namespace eBPS.Infrastructure.DataAccess.Repositories.Shared
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrganizationRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<OrganizationDTO> GetByOrgIdAsync(int orgId)
        {
            var query = "SELECT * FROM Roles WHERE Id = @Id";
            return await _unitOfWork.Connection.QuerySingleOrDefaultAsync<OrganizationDTO>(query, new { Id = orgId }, _unitOfWork.Transaction);
        }
        public async Task<IEnumerable<OrganizationDTO>> GetActiveOrganizations()
        {
            const string query = "SELECT Id, Name FROM Organizations WHERE IsActive = 1";
            return await _unitOfWork.Connection.QueryAsync<OrganizationDTO>(query, _unitOfWork.Transaction);
        }
        public async Task<IEnumerable<OrganizationDTO>> GetUserOrganizations(int userId)
        {
            const string query = "SELECT DISTINCT Org.Id, Org.Name FROM UserOrganizations UserOrg INNER JOIN Organizations Org ON UserOrg.OrganizationId = Org.Id where UserOrg.UserId = @UserId";
            return await _unitOfWork.Connection.QueryAsync<OrganizationDTO>(query, new { UserId = userId }, _unitOfWork.Transaction);
        }

        public async Task<string> GetOrganizationsConfig(int orgId)
        {
            const string query = "SELECT ConnectionString FROM OrganizationsConfig where OrganizationId = @OrgId";
            return await _unitOfWork.Connection.QuerySingleOrDefaultAsync<string>(query, new { OrgId = orgId }, _unitOfWork.Transaction);
        }
    }
}
