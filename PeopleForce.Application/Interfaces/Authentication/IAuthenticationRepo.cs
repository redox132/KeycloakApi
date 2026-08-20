namespace PeopleForce.Application.Users.Authentication;

public interface IAuthenticationRepo
{
    Task<KeycloakAuthResponse> Authenticate(AuthenticationRequest request);
}