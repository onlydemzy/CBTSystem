
namespace CBTSystem.Contracts.Authentication;
public record RegisterRequestContract(
    string UserName,
    string FullName,
    string Password,
    string Email,
    string UserrRole
);