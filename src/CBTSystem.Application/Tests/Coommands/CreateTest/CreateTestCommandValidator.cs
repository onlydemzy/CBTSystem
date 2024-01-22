using FluentValidation;

namespace CBTSystem.Application.Commands.CreateTest;
public class CreateTestCommandValidator:AbstractValidator<CreateTestCommand>
{
    public CreateTestCommandValidator()
    {
        RuleFor(a=>a.Institution)
            .NotEmpty()
            .MaximumLength(200);
        RuleFor(a=>a.Title).NotEmpty();
    }
}












