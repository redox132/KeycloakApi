using Microsoft.AspNetCore.Mvc;
using PeopleForce.Application.Interfaces.Users.Queries.GetUserById.Service;

namespace PeopleForce.Api.Controllers.Users.Queries.GetUserById;

[ApiController]
[Route("api/user")]
public class GetUserByIdController : ControllerBase
{
    private readonly IGetUserByIdService _getUserByIdService;

    public GetUserByIdController(IGetUserByIdService getUserByIdService)
    {
        _getUserByIdService = getUserByIdService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetUserByIdResponse>> GetUserById(
        [FromRoute] GetUserByIdRequest request)
    {
        var response = await _getUserByIdService.GetUserByIdAsync(request.Id);

        var res = new GetUserByIdResponse(
            Id: response.Id,
            Name: response.Name,
            Email: response.Email
        );

        return Ok(res);
    }
}