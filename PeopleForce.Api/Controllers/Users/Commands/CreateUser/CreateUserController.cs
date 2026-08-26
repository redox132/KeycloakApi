using Microsoft.AspNetCore.Mvc;
using PeopleForce.Application.Interfaces.Users.Commands.CreateUser.CreateUserService;
using PeopleForce.Application.Interfaces.Users.Commands.CreateUser.Dtos;
using PeopleForce.Domain;

namespace PeopleForce.Api.Controllers.Users.Commands.CreateUser;

[ApiController]
[Route("api/users")]
public class CreateUserController : ControllerBase
{
    private readonly ICreateUserhandlerService _createUserhandlerService;

    public CreateUserController(ICreateUserhandlerService createUserhandlerService)
    {
        _createUserhandlerService = createUserhandlerService;
    }

    [HttpPost]
    public async Task<ActionResult<CreateUserResponse>> Create(CreateUserRequest request)
    {
        CreateUserCommand createUserCommand = new CreateUserCommand
        (
            Name: request.Name,
            Email: request.Email
        );
            
        var user = await _createUserhandlerService.CreateUserAsync(createUserCommand);

        var response = new CreateUserResponse(
            user.Id,
            user.Name,
            user.Email);
        
        return Ok(response);
    }
    
}