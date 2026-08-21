namespace PeopleForce.Application.Interfaces.Users.Commands.Authentication;

public interface IAuthenticationService
{
   Task<AuthenticationResult> AuthenticateAsync(AuthenticationRequest request, CancellationToken  cancellationToken);
}