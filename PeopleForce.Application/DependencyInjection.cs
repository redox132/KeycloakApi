using Microsoft.Extensions.DependencyInjection;
using PeopleForce.Application.Interfaces.Users.Commands.Authentication;
using PeopleForce.Application.Interfaces.Users.Queries.GetUserById.Service;
using PeopleForce.Application.Services.Users.Commands.Authentication;
using PeopleForce.Application.Services.Users.Queries.GetUserById;

namespace PeopleForce.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IGetUserById, GetUserById>();
        services.AddScoped<IAuthenticationService, AuthenticationService>(); 
        return services;
    }
}