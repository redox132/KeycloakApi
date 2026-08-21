using PeopleForce.Application.Interfaces.Users.Dtos;
using PeopleForce.Domain;

namespace PeopleForce.Application.Users.Queries.GetUserById.Repository;

public interface IGetUserById
{
    Task<User> GetUserByIdAsync(Guid id);
}