using System.Net.Http.Json;
using System.Text.Json;
using PeopleForce.Application.Interfaces.Users.Commands.Authentication;

namespace PeopleForce.Infrastructure.Users.Commands.Authentication;

public class AuthenticationRepo : IAuthenticationRepo
{
    private readonly IAuthenticationService  _authenticationService;

    public AuthenticationRepo(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }
    public async Task<KeycloakAuthResponse> Authenticate(AuthenticationRequest request)
    {
        
        
        KeycloakAuthResponse response = new KeycloakAuthResponse
        {
            
        };
        
        return _authenticationService.AuthenticateAsync(request);
    }
}