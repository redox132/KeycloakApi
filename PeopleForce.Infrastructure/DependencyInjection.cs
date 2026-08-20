using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PeopleForce.Application.Users.Authentication;
using PeopleForce.Application.Users.Queries.GetUserById.Repository;
using PeopleForce.Infrastructure.Config.Keyclock;
using PeopleForce.Infrastructure.Users.Commands.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using PeopleForce.Infrastructure.Users.Queries;

namespace PeopleForce.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        AddKeycloakConfiguration(services, configuration);
        AddJwtOptions(services, configuration);
        
        services.AddScoped<IGetUserByIdRepository, GetUserByIdRepository>();
        services.AddScoped<IAuthenticationRepo, AuthenticationRepo>();
        return services;
    }

    private static IServiceCollection AddKeycloakConfiguration(this IServiceCollection services, IConfiguration  configuration)
    {
        services.Configure<KeyclockConfig>(
            configuration.GetSection("Config:Keycloak"));
        
        return services;
    }

    private static IServiceCollection AddJwtOptions( this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority =
                    configuration["Config:Keycloak:Authority"];

                options.RequireHttpsMetadata = false;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,

                    ValidIssuer =
                        configuration["Config:Keycloak:Authority"],

                    ValidateLifetime = true,

                    ValidateIssuerSigningKey = true,

                    ValidateAudience = false
                };

                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        Console.WriteLine(
                            $"JWT AUTH FAILED: {context.Exception.Message}");

                        return Task.CompletedTask;
                    },

                    OnTokenValidated = context =>
                    {
                        Console.WriteLine("JWT TOKEN VALIDATED");

                        return Task.CompletedTask;
                    }
                };
            });

        return services;
    } 
}
    
