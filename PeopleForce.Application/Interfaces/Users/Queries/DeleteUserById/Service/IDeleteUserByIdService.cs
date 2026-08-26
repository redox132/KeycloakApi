namespace PeopleForce.Application.Interfaces.Users.Queries.DeleteUserById.Service;

public interface IDeleteUserByIdService
{
    Task<DeleteUserByIdResult> DeleteUserByIdAsync(Guid id);
}