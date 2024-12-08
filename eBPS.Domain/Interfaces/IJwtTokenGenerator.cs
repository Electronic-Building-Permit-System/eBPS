using eBPS.Domain.Entities;

namespace eBPS.Domain.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateJwtToken(Users user);
    }
}
