using eBPS.Domain.Entities;

namespace eBPS.Application.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateJwtToken(Users user);
    }
}
