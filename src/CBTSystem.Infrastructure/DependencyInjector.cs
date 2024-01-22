using System.Text;
using CBTSystem.Application.Common.interfaces.Persistence;
using CBTSystem.Infrastructure.Authentication;
using CBTSystem.Infrastructure.Interfaces;
using CBTSystem.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CBTSystem.Infrastructure;
public static class DependencyInjector
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        ConfigurationManager configurationManager)
        {
            services.Configure<JwtSettings>(configurationManager.GetSection(JwtSettings.SectionName));
            services.AddAuth(configurationManager);
            services.AddPersistence();
            return services;
        }
    private static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository,UserRepository>();

        return services;
    }

    
    private static IServiceCollection AddAuth(this IServiceCollection services, ConfigurationManager configuration)
    {
        //Get jwtsettings
        var jwtsettings=new JwtSettings();
        //Bind jwtsettings from app json file to object
        configuration.Bind(JwtSettings.SectionName,jwtsettings);
        services.AddSingleton(Options.Create(jwtsettings));
        services.AddTransient<IJwtTokenGenerator,JwtTokenGenerator>();
        services.AddAuthentication(defaultScheme:JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options=>options.TokenValidationParameters=new TokenValidationParameters{
           ValidateLifetime=true,
            ValidateIssuer=true,
            ValidateAudience=true,
            ValidateIssuerSigningKey=true,
            //Get issuers and audiences
            ValidIssuer=jwtsettings.Issuer,
            ValidAudience=jwtsettings.Audience,
            IssuerSigningKey=new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtsettings.Secret)
            )
        });
        return services;
    }
}