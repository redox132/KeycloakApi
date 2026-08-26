using FluentValidation;

namespace PeopleForce.Api.Controllers.Users.Queries.GetUserById;

public class GetUserByIdRequestValidator : AbstractValidator<GetUserByIdRequest> 
{
    public GetUserByIdRequestValidator()
    {
        RuleFor(x => x.Id).NotNull().NotEmpty();
    }
}