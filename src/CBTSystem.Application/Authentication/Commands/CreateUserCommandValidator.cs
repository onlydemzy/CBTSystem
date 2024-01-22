using System.Data;
using FluentValidation;

namespace CBTSystem.Application.Authentication.Commands;
public class CreateUserCommandValidator:AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(r=>r.UserName).NotEmpty();
        RuleFor(r=>r.FullName).NotEmpty();
        RuleFor(r=>r.Password).MinimumLength(6).NotEmpty();
        RuleFor(r=>r.UserRole).NotEmpty();
        RuleFor(r=>r.UserId).Empty();
            //.When(r=>r.UserRole!="Student");
             //.Length(0).When(r=>r.UserRole!="Student");

    }
}