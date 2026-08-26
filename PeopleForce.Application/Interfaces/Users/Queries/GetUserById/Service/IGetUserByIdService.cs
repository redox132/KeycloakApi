using PeopleForce.Application.Interfaces.Users.Queries.GetUserById.Dtos;

namespace PeopleForce.Application.Interfaces.Users.Queries.GetUserById.Service;

public interface IGetUserByIdService
{
    Task<GetUserByIdResponse> GetUserByIdAsync(Guid id);
}