using FluentValidation;
using PeopleForce.Api.Controllers.Users.Commands.Authentication;

namespace PeopleForce.Api.ValidatorServices;

public static class ValidatorServices
{
    public static IServiceCollection AddValidatorServices(this IServiceCollection services)
    {
        services.AddScoped<IValidator<AuthenticationHtppRequest>, AuthenticationHtppRequestValidator>();

        return services;
    }
    
}