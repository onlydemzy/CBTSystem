using FluentValidation;
using FluentValidation.Results;

namespace CBTSystem.Application.Authentication.Queries;
public class LoginUserQueryValidator : IValidator<LoginUserQuery>
{
    public bool CanValidateInstancesOfType(Type type)
    {
        throw new NotImplementedException();
    }

    public IValidatorDescriptor CreateDescriptor()
    {
        throw new NotImplementedException();
    }

    public ValidationResult Validate(LoginUserQuery instance)
    {
        throw new NotImplementedException();
    }

    public ValidationResult Validate(IValidationContext context)
    {
        throw new NotImplementedException();
    }

    public Task<ValidationResult> ValidateAsync(LoginUserQuery instance, CancellationToken cancellation = default)
    {
        throw new NotImplementedException();
    }

    public Task<ValidationResult> ValidateAsync(IValidationContext context, CancellationToken cancellation = default)
    {
        throw new NotImplementedException();
    }
}