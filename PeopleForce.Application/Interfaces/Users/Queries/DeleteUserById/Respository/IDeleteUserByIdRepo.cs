using PeopleForce.Domain;

namespace PeopleForce.Application.Interfaces.Users.Queries.DeleteUserById.Respository;

public interface IDeleteUserByIdRepo
{
    Task<User> DeleteUserByIdAsync(Guid userId);
}