using Microsoft.Extensions.DependencyInjection;
using PeopleForce.Application.Interfaces.Users.Commands.Authentication;
using PeopleForce.Application.Interfaces.Users.Commands.CreateUser.CreateUserService;
using PeopleForce.Application.Interfaces.Users.Queries.DeleteUserById.Service;
using PeopleForce.Application.Interfaces.Users.Queries.GetUserById.Service;
using PeopleForce.Application.Interfaces.Users.Queries.GetUsers.Service;
using PeopleForce.Application.Services.Users.Commands.Authentication;
using PeopleForce.Application.Services.Users.Commands.CreateUser;
using PeopleForce.Application.Services.Users.Queries.DeleteUserById;
using PeopleForce.Application.Services.Users.Queries.GetUserById;
using PeopleForce.Application.Services.Users.Queries.GetUsers;

namespace PeopleForce.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IGetUserByIdService, GetUserByIdService>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<ICreateUserhandlerService, CreateUserhandlerService>();
        services.AddScoped<IDeleteUserByIdService, DeleteUserByIdService>();
        services.AddScoped<IGetUserByIdService, GetUserByIdService>();
        services.AddScoped<IGetUsersService, GetUsersService>();
        
        return services;
    }
}