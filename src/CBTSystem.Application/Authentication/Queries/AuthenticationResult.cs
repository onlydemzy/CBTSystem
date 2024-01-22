using CBTSystem.Entities;

namespace CBTSystem.Application.Authentication.Queries;
public record AuthenticationResult(
    User User,
    string Token
);