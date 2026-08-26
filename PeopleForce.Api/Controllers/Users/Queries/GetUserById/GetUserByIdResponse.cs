namespace PeopleForce.Api.Controllers.Users.Queries.GetUserById;

public record GetUserByIdResponse(Guid Id, string Name, string Email);