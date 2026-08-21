namespace PeopleForce.Application.Interfaces.Users.Commands.Authentication;

public class AuthenticationRequest
{
    public required string Code { get; init; }
}