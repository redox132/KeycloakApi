using FluentValidation;

namespace PeopleForce.Api.Controllers.Users.Commands.Authentication;

public class AuthenticationHtppRequestValidator : AbstractValidator<AuthenticationHtppRequest> 
{
    public AuthenticationHtppRequestValidator()
    {
        RuleFor(x => x.Code).NotNull().NotEmpty();
    }
}