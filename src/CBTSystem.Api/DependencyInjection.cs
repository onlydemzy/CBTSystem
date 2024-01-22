using CBTSystem.Api.Common.Errors;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace CBTSystem.Api;
public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory, CBTSystemProblemDetailFactory>();
        
        return services;
    }
}