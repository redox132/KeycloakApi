namespace PeopleForce.Application.Interfaces.Users.Queries.GetUserById.Dtos;

public record GetUserByIdResponse(Guid Id, string Name, string Email);