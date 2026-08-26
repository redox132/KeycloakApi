using System.Collections.Generic;
using System.Threading.Tasks;
using PeopleForce.Domain;

namespace PeopleForce.Application.Interfaces.Users.Queries.GetUsers.Repository;

public interface IGetUsersRepo
{
    Task<List<User>> GetUsersAsync(int pageNumber, int pageSize);
}