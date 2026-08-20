using Microsoft.AspNetCore.Mvc;
using PeopleForce.Application.Users.Authentication;

namespace PeopleForce.Api.Controllers.Users.Commands.Authentication;

[ApiController]
[Route("api/auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService  authenticationService)
    {
        _authenticationService = authenticationService;
    }
    
    [HttpPost("token")]
    public async Task<IActionResult> Authenticate(AuthenticationHtppRequest  request)
    {
        AuthenticationRequest authenticationRequest = new AuthenticationRequest
        {
            Code = request.Code,
        };
        
        return Ok(await _authenticationService.Authenticate(authenticationRequest));
    }
}