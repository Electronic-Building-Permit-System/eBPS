using eBPS.Application.Interfaces;
using Microsoft.AspNetCore.Http;

namespace eBPS.Infrastructure.Services
{
    public class UserContextService : IUserContextService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserContextService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int GetUserId()
        {
            return int.Parse(_httpContextAccessor.HttpContext.User.FindFirst("userId").Value);
        }

        public int GetRoleId()
        {
            return int.Parse(_httpContextAccessor.HttpContext.User.FindFirst("roleId").Value);
        }

        public int GetOrgId()
        {
            return int.Parse(_httpContextAccessor.HttpContext.User.FindFirst("orgId").Value);
        }
    }
}
