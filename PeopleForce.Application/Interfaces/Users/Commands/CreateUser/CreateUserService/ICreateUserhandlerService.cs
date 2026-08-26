using PeopleForce.Application.Interfaces.Users.Commands.CreateUser.Dtos;

namespace PeopleForce.Application.Interfaces.Users.Commands.CreateUser.CreateUserService;

public interface ICreateUserhandlerService
{
    Task<CreateUserResponse> CreateUserAsync(CreateUserCommand user);
}