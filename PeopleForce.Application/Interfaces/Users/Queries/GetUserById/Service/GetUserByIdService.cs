using PeopleForce.Application.Users.Queries.GetUserById.Repository;
using PeopleForce.Domain;

namespace PeopleForce.Application.Users.Queries.GetUserById.Service;

public class GetUserByIdService : IGetUserByIdService
{
    private readonly IGetUserByIdRepository  _repository;

    public GetUserByIdService(IGetUserByIdRepository repository)
    {
        _repository = repository;
    }
    public User GetUserById(int id)
    {
        return _repository.GetUserById(id);
    }
}