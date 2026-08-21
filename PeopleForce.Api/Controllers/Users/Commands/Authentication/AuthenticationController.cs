using Microsoft.AspNetCore.Mvc;
using PeopleForce.Application.Interfaces.Users.Commands.Authentication;


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
    private async Task<IActionResult> AuthenticateAsync(AuthenticationHtppRequest request, CancellationToken  cancellationToken)
    {
        AuthenticationRequest authenticationRequest = new AuthenticationRequest { Code = request.Code };
        
        return Ok(await _authenticationService.AuthenticateAsync(authenticationRequest, cancellationToken));
    }
}