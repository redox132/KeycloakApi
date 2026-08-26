namespace PeopleForce.Api.Controllers.Users.Commands.CreateUser;

public sealed record CreateUserResponse(Guid Id, string Name, string Email);