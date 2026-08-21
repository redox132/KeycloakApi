using System.Net.Http.Json;
using System.Text.Json;
using PeopleForce.Application.Interfaces.Users.Commands.Authentication;

namespace PeopleForce.Infrastructure.Users.Commands.Authentication;

public class AuthenticationRepo : IAuthenticationRepo
{
    private readonly IAuthenticationRepo  _authenticationRepo;

    public AuthenticationRepo(IAuthenticationRepo authenticationRepo)
    {
        _authenticationRepo = authenticationRepo;
    }
    public async Task<KeycloakAuthResponse> Authenticate(AuthenticationRequest request)
    {
        return await _authenticationRepo.Authenticate(request);
    }
}