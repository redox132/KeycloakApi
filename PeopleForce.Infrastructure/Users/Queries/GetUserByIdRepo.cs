using Microsoft.EntityFrameworkCore;
using PeopleForce.Application.Interfaces.Users.Queries.GetUserById.Repository;
using PeopleForce.Domain;
using PeopleForce.Infrastructure.PeopleForceAppDbContext;

namespace PeopleForce.Infrastructure.Users.Queries;

public class GetUserByIdRepo : IGetUserByIdRepo
{
    private readonly PeopleAppDbContext _dbContext;

    public GetUserByIdRepo(PeopleAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<User> GetUserByIdAsync(Guid id)
    {
        User? user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id );

        return user;
    } 
}