namespace PeopleForce.Application.Interfaces.Users.Commands.CreateUser.Dtos;

public record CreateUserResponse(Guid Id, string Name, string Email);