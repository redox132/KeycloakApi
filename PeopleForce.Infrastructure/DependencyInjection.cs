using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using PeopleForce.Application.Interfaces.Users.Commands.Authentication;
using PeopleForce.Application.Interfaces.Users.Commands.CreateUser.CreateUserRepo;
using PeopleForce.Application.Interfaces.Users.Queries.DeleteUserById.Respository;
using PeopleForce.Application.Interfaces.Users.Queries.GetUserById.Repository;
using PeopleForce.Application.Interfaces.Users.Queries.GetUsers.Repository;
using PeopleForce.Infrastructure.Keycloak;
using PeopleForce.Infrastructure.PeopleForceAppDbContext;
using PeopleForce.Infrastructure.Users.Commands.Authentication;
using PeopleForce.Infrastructure.Users.Commands.CreateUser;
using PeopleForce.Infrastructure.Users.Queries;

namespace PeopleForce.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        AddKeycloakConfiguration(services, configuration);
        AddJwtOptions(services, configuration);
        AddPostgresServices(services, configuration);
        
        services.AddScoped<IGetUserByIdRepo, GetUserByIdRepo>();
        services.AddScoped<IAuthenticationRepo, AuthenticationRepo>();
        services.AddScoped<ICreateUserHandlerRepo, CreateUserHandlerRepo>();
        services.AddScoped<IDeleteUserByIdRepo, DeleteUserByIdRepo>();
        services.AddScoped<IGetUserByIdRepo, GetUserByIdRepo>();
        services.AddScoped<IGetUsersRepo,  GetUsersRepo>();
        services.AddScoped<IKeycloakClient, KeycloakClient>();
        
        return services;
    }

    private static IServiceCollection AddKeycloakConfiguration(this IServiceCollection services, IConfiguration  configuration)
    {
        services.Configure<KeycloakConfig>(
            configuration.GetSection("Config:Keycloak"));
        
        return services;
    }

    private static IServiceCollection AddPostgresServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<PeopleAppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("Postgres")));
                
        return services;
    }

    private static IServiceCollection AddJwtOptions( this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority =  configuration["Config:Keycloak:Authority"];
                
                options.RequireHttpsMetadata = false;
                
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = configuration["Config:Keycloak:Authority"],
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
    
