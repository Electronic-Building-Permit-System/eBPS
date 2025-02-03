using eBPS.Domain.Entities.Shared;

namespace eBPS.Application.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateJwtToken(Users user);
    }
}
