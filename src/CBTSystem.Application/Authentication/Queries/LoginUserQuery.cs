using ErrorOr;
using MediatR;

namespace CBTSystem.Application.Authentication.Queries;
public record LoginUserQuery(
    string Username,
    string Password
):IRequest<ErrorOr<AuthenticationResult>>;