using Microsoft.EntityFrameworkCore;
using PeopleForce.Application.Interfaces.Users.Dtos;
using PeopleForce.Application.Users.Queries.GetUserById.Repository;
using PeopleForce.Domain;
using PeopleForce.Infrastructure.PeopleForceAppDbContext;

namespace PeopleForce.Infrastructure.Users.Queries;

public class GetUserById : IGetUserById
{
    private readonly AppDbContext _dbContext;

    public GetUserById(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<User> GetUserByIdAsync(Guid id)
    {
        User? user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id );

        return user;
    } 
}