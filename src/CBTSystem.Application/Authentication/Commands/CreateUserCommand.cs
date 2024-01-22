using ErrorOr;
using MediatR;

namespace CBTSystem.Application.Authentication.Commands;
public record CreateUserCommand(
    string UserId,
    string UserName,
    string FullName,
    string Password,
    string Email,
    string ProgrammeCode,
    string UserRole
):IRequest<ErrorOr<string>>;