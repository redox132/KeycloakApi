using PeopleForce.Application.Interfaces.Users.Dtos;
using PeopleForce.Application.Interfaces.Users.Queries.GetUserById.Service;

namespace PeopleForce.Application.Services.Users.Queries.GetUserById;

public class GetUserById : IGetUserById
{
    public async Task<UserDto> GetUserByIdAsync(Guid id)
    {
        UserDto userDto = new UserDto
        {
            Id = Guid.NewGuid(),
            Name = "rida",
            Email = "email"
        };
        
        return userDto;
    }
}