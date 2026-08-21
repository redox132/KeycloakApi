using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PeopleForce.Application.Interfaces.Users.Queries.GetUserById.Service;

namespace PeopleForce.Api.Controllers.Users.Queries;

[ApiController]
[Route("api/users")]
public class GetUserByIdController : ControllerBase
{
    private readonly IGetUserById _getUserById;

    public GetUserByIdController(IGetUserById getUserById)
    {
        _getUserById = getUserById;
    }

    [Authorize]
    [HttpGet("{id}")]
    public IActionResult GetUserById(Guid id)
    {
        var response = _getUserById.GetUserByIdAsync(id);
        return Ok(response);
    }
}