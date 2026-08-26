using PeopleForce.Domain;

namespace PeopleForce.Application.Interfaces.Users.Queries.GetUserById.Repository;

public interface IGetUserByIdRepo
{
    Task<User> GetUserByIdAsync(Guid id);
}