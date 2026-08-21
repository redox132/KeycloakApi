namespace PeopleForce.Application.Interfaces.Users.Dtos;

public class UserDto
{
    public Guid Id { get; init; }
    public required string  Name { get; set; }
    public required string Email { get; set; }
}