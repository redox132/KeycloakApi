using Microsoft.VisualBasic;
using PeopleForce.Application.Users.Queries.GetUserById.Repository;
using PeopleForce.Domain;

namespace PeopleForce.Infrastructure.Users.Queries;

public class GetUserByIdRepository : IGetUserByIdRepository
{
    public User GetUserById(int id)
    {
        var users = new List<User>
        {
            new User { Id = 1, Name = "John", Email = "testemail"},
            new User { Id = 2, Name = "Jane", Email = "testemail2"},
            new User { Id = 3, Name = "Bob", Email = "testemail3"}
        };

        return users.FirstOrDefault(u => u.Id == id);
    } 
}