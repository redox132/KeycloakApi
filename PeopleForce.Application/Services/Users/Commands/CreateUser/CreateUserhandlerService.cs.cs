using PeopleForce.Application.Interfaces.Users.Commands.CreateUser.CreateUserRepo;
using PeopleForce.Application.Interfaces.Users.Commands.CreateUser.CreateUserService;
using PeopleForce.Application.Interfaces.Users.Commands.CreateUser.Dtos;
using PeopleForce.Domain;

namespace PeopleForce.Application.Services.Users.Commands.CreateUser;

public class CreateUserhandlerService : ICreateUserhandlerService
{
    private readonly ICreateUserHandlerRepo _createUserHandler;
    
    public CreateUserhandlerService(ICreateUserHandlerRepo  createUserHandler)
    {
        _createUserHandler = createUserHandler;
    }

    public Task<CreateUserResponse> CreateUserAsync(CreateUserCommand createUserCommand)
    {
        User user = new User
        {
            Name = createUserCommand.Name,
            Email = createUserCommand.Email
        };
        
        return _createUserHandler.CreateUserAsync(user);
    }
    
}