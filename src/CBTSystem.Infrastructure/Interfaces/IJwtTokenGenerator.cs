using CBTSystem.Entities;

namespace CBTSystem.Infrastructure.Interfaces;

public interface IJwtTokenGenerator
{
    string GeneratJwtToken(User user);
}