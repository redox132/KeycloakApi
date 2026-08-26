namespace PeopleForce.Application.Interfaces.Users.Commands.CreateUser.Dtos;

public sealed record CreateUserCommand(
    string Name,
    string Email
);