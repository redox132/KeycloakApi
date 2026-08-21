using PeopleForce.Application.Interfaces.Users.Commands.Authentication;

namespace PeopleForce.Application.Services.Users.Commands.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IAuthenticationRepo _authenticationRepo;

    public AuthenticationService(IAuthenticationRepo authenticationRepo)
    {
        _authenticationRepo = authenticationRepo;
    }
    
    public async Task<AuthenticationResult> AuthenticateAsync(
        AuthenticationRequest request,
        CancellationToken cancellationToken)
    {
        var res = await _authenticationRepo.Authenticate(request);

        AuthenticationResult result = new AuthenticationResult
        {
            AccessToken = res.AccessToken,
            RefreshToken = res.RefreshToken,
            ExpiresIn = res.ExpiresIn,
            TokenType = res.TokenType,
            Scope = res.Scope
        };
        
        return result;
    }
}