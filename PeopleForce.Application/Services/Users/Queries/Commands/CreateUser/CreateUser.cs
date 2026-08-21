using PeopleForce.Application.Interfaces.Users.Commands.CreateUser;
using PeopleForce.Application.Interfaces.Users.Commands.CreateUser.CreateUserRepo;
using PeopleForce.Application.Interfaces.Users.Dtos;
using PeopleForce.Domain;
using ICreateUser = PeopleForce.Application.Interfaces.Users.Commands.CreateUser.CreateUserService.ICreateUser;


namespace PeopleForce.Infrastructure.Users.Commands.CreateUser;

public class CreateUser : ICreateUser
{
    private readonly ICreateUser _createUser;

    public CreateUser(ICreateUser createUser)
    {
        _createUser = createUser;
    }

    public Task<UserDto> CreateUserAsync(User user)
    {
        return _createUser.CreateUserAsync(user);
    }
}