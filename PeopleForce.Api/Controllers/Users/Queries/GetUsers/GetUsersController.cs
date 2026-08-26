using Microsoft.AspNetCore.Mvc;
using PeopleForce.Application.Interfaces.Users.Queries.GetUsers.Service;
using PeopleForce.Infrastructure.Keycloak;

namespace PeopleForce.Api.Controllers.Users.Queries.GetUsers;

[ApiController]
[Route("api/users")]
public class GetUsersController : ControllerBase
{
    private readonly ILogger<GetUsersController> _logger;
    private readonly IGetUsersService _usersService;
    private readonly IConfiguration _config;
    
    public GetUsersController(ILogger<GetUsersController> logger,  IGetUsersService usersService,  IConfiguration  config)
    {
        _logger = logger;
        _usersService = usersService;
        _config = config;
    }

    [HttpGet]
    public async Task<ActionResult<GetUsersResponse>> GetUsers(
        [FromQuery] GetUsersResquest request)
    {
        var baseUrl = _config["config:Keycloak:BaseUrl"];
        var realm = _config["config:Keycloak:Realm"];
        var client = _config["config:Keycloak:Client"];

        _logger.LogInformation("Keycloak BaseUrl: {BaseUrl}", baseUrl);
        _logger.LogInformation("Keycloak Realm: {Realm}", realm);
        _logger.LogInformation("Keycloak Client: {Client}", client);

        var users = await _usersService.GetUsersAsync(
            request.PageNumber,
            request.PageSize);

        return Ok(new GetUsersResponse(Users: users));
    }
    
}