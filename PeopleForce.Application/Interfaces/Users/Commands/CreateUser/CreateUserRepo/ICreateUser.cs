using PeopleForce.Application.Interfaces.Users.Dtos;
using PeopleForce.Domain;

namespace PeopleForce.Application.Interfaces.Users.Commands.CreateUser.CreateUserRepo;

public interface ICreateUser
{
    Task<UserDto> CreateUserAsync(User user);
}