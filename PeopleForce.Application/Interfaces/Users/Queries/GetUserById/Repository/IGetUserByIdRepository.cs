using PeopleForce.Domain;

namespace PeopleForce.Application.Users.Queries.GetUserById.Repository;

public interface IGetUserByIdRepository
{
    User GetUserById(int id);
}