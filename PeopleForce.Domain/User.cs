namespace PeopleForce.Domain;

public class User
{
    public Guid Id { get; init; }
    public required string Name { get; init; }
    public required string Email { get; init; }
}