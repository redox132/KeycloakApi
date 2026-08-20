using PeopleForce.Application.Users.Authentication;

namespace PeopleForce.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IAuthenticationRepo _authenticationRepo;

    public AuthenticationService(IAuthenticationRepo authenticationRepo)
    {
        _authenticationRepo = authenticationRepo;
    }
    
    public async Task<AuthenticationResult> Authenticate(AuthenticationRequest request)
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