namespace PeopleForce.Application.Interfaces.Users.Queries.GetUsers.Service;

public interface IGetUsersService
{
    Task<List<GetUsersResult>> GetUsersAsync(int pageNumber, int pageSize);
}