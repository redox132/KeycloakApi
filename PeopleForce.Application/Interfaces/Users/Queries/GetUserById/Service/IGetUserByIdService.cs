using PeopleForce.Domain;

namespace PeopleForce.Application.Users.Queries.GetUserById.Service;

public interface IGetUserByIdService
{
    User GetUserById(int id);
}