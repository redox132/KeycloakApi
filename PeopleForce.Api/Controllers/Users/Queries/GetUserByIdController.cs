using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PeopleForce.Application.Users.Queries.GetUserById.Service;

namespace PeopleForce.Api.Controllers.Users.Queries;

[ApiController]
[Route("api/users")]
public class GetUserByIdController : ControllerBase
{
    private readonly IGetUserByIdService _getUserByIdService;

    public GetUserByIdController(IGetUserByIdService getUserByIdService)
    {
        _getUserByIdService = getUserByIdService;
    }

    [Authorize]
    [HttpGet("{id}")]
    public IActionResult GetUserById(int id)
    {
        var response = _getUserByIdService.GetUserById(id);
        return Ok(response);
    }
}