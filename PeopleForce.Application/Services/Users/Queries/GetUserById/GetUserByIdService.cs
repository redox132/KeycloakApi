
using PeopleForce.Application.Interfaces.Users.Queries.GetUserById.Dtos;
using PeopleForce.Application.Interfaces.Users.Queries.GetUserById.Repository;
using PeopleForce.Application.Interfaces.Users.Queries.GetUserById.Service;

namespace PeopleForce.Application.Services.Users.Queries.GetUserById;

public class GetUserByIdService : IGetUserByIdService
{
    private readonly IGetUserByIdRepo _getUserByIdRepo;

    public GetUserByIdService(IGetUserByIdRepo getUserByIdRepo)
    {
        _getUserByIdRepo = getUserByIdRepo;
    }
    
    public async Task<GetUserByIdResponse> GetUserByIdAsync(Guid id)
    {
        var user =  await _getUserByIdRepo.GetUserByIdAsync(id);
        
        GetUserByIdResponse res = new GetUserByIdResponse
        (
            Id: user.Id,
            Name: user.Name,
            Email: user.Email
        );

        return res;
    }
}