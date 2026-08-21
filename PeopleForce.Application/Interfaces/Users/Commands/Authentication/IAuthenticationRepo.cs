namespace PeopleForce.Application.Interfaces.Users.Commands.Authentication;

public interface IAuthenticationRepo
{
    Task<KeycloakAuthResponse> Authenticate(AuthenticationRequest request);
}