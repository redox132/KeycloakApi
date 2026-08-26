using Microsoft.AspNetCore.Mvc;
using PeopleForce.Application.Interfaces.Users.Queries.DeleteUserById.Service;

namespace PeopleForce.Api.Controllers.Users.Queries.DeleteUserById;

[ApiController]
[Route("api/user")]
public class DeleteUserByIdController : ControllerBase
{
    private readonly IDeleteUserByIdService _deleteUserByIdService;

    public DeleteUserByIdController(IDeleteUserByIdService deleteUserByIdService)
    {
        _deleteUserByIdService = deleteUserByIdService;
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetUserById(Guid id)
    {
        var user = await _deleteUserByIdService.DeleteUserByIdAsync(id);
        
        return Ok(user);
    }
}