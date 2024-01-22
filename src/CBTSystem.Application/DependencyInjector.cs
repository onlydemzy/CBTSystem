using System.Reflection;
using CBTSystem.Application.Commands.CreateTest;
using CBTSystem.Application.Common.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
namespace CBTSystem.Application;
public static class DependencyInjector
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(c=>c.RegisterServicesFromAssemblyContaining<CreateTestCommand>());
        services.AddScoped(typeof(IPipelineBehavior<,>),typeof(ValidationBehaviour<,>));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly()); //this requires a pacakge fluentvalidation.aspnetcore
        return services;
    }
}