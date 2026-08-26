using PeopleForce.Application.Interfaces.Users.Commands.CreateUser.Dtos;
using PeopleForce.Application.Interfaces.Users.Commands.CreateUser.Dtos;
using PeopleForce.Domain;

namespace PeopleForce.Application.Interfaces.Users.Commands.CreateUser.CreateUserRepo;

public interface ICreateUserHandlerRepo
{
    Task<CreateUserResponse> CreateUserAsync(User user);
}