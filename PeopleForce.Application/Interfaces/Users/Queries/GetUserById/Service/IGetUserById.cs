using PeopleForce.Application.Interfaces.Users.Dtos;

namespace PeopleForce.Application.Interfaces.Users.Queries.GetUserById.Service;

public interface IGetUserById
{
    Task<UserDto> GetUserByIdAsync(Guid id);
}