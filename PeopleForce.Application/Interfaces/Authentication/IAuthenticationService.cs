namespace PeopleForce.Application.Users.Authentication;

public interface IAuthenticationService
{
   Task<AuthenticationResult> Authenticate(AuthenticationRequest request);
}