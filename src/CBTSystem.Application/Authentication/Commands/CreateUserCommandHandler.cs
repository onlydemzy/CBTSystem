using CBTSystem.Application.Common.interfaces.Persistence;
using CBTSystem.Entities;
using ErrorOr;
using MediatR;

namespace CBTSystem.Application.Authentication.Commands;
public class CreateUserCommandHandler(IUserRepository userRepository) : IRequestHandler<CreateUserCommand, ErrorOr<string>>
{
    private readonly IUserRepository _userRepository = userRepository;
    public async Task<ErrorOr<string>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var _user = User.Create(request.UserId,
        request.UserName, request.FullName,
        request.Email, request.FullName,
        request.ProgrammeCode, request.UserRole ?? "Student");
        _userRepository.Add(_user);
        return "User successfully created";
    }
}