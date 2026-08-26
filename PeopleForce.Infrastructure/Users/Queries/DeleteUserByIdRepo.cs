using System;
using Microsoft.EntityFrameworkCore;
using PeopleForce.Application.Interfaces.Users.Queries.DeleteUserById.Respository;
using PeopleForce.Domain;
using PeopleForce.Infrastructure.PeopleForceAppDbContext;

namespace PeopleForce.Infrastructure.Users.Queries;

public class DeleteUserByIdRepo : IDeleteUserByIdRepo
{
    private readonly PeopleAppDbContext _peopleAppDbContext;

    public DeleteUserByIdRepo(PeopleAppDbContext peopleAppContext)
    {
        _peopleAppDbContext = peopleAppContext;
    }

    public async Task<User> DeleteUserByIdAsync(Guid id)
    {
        User? user = await _peopleAppDbContext.Users.FirstOrDefaultAsync(u => u.Id == id );
        
        if (user is null)
            throw new Exception($"User with id {id} not found");
        
        _peopleAppDbContext.Users.Remove(user);

        await _peopleAppDbContext.SaveChangesAsync();

        return user;
    }
}