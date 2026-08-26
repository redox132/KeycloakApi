using FluentValidation;

namespace PeopleForce.Api.Controllers.Users.Queries.GetUsers;

public class GetUsersRequestValidator : AbstractValidator<GetUsersResquest>
{
    public GetUsersRequestValidator()
    {
        RuleFor(request => request.PageNumber)
            .GreaterThan(0)
            .NotEmpty()
            .NotNull()
            .LessThan(3);
        
        RuleFor(request => request.PageSize)
            .GreaterThan(0)
            .NotEmpty()
            .NotNull();
    }    
}