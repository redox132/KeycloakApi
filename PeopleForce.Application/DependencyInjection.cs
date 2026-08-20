using Microsoft.Extensions.DependencyInjection;
using PeopleForce.Application.Services.Authentication;
using PeopleForce.Application.Users.Authentication;
using PeopleForce.Application.Users.Queries.GetUserById.Service;

namespace PeopleForce.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IGetUserByIdService, GetUserByIdService>();
        services.AddScoped<IAuthenticationService, AuthenticationService>(); 
        return services;
    }
}