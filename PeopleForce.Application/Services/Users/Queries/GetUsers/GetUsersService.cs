using PeopleForce.Application.Interfaces.Users.Queries.GetUsers.Repository;
using PeopleForce.Application.Interfaces.Users.Queries.GetUsers.Service;

namespace PeopleForce.Application.Services.Users.Queries.GetUsers;

public class GetUsersService : IGetUsersService
{
    private readonly IGetUsersRepo _getUsersRepo;

    public GetUsersService(IGetUsersRepo getUsersRepo)
    {
        _getUsersRepo = getUsersRepo;
    }

    public async Task<List<GetUsersResult>> GetUsersAsync(int pageNumber, int pageSize)
    {
        var users = await _getUsersRepo.GetUsersAsync(pageNumber, pageSize);

        return users.Select(user => new GetUsersResult(
            Id: user.Id,
            Name: user.Name,
            Email: user.Email
        )).ToList();
    }
    
}