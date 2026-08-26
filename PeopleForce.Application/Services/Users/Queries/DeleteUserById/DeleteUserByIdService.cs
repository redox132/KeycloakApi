using System;
using PeopleForce.Application.Interfaces.Users.Queries.DeleteUserById.Respository;
using PeopleForce.Application.Interfaces.Users.Queries.DeleteUserById.Service;
using PeopleForce.Domain;

namespace PeopleForce.Application.Services.Users.Queries.DeleteUserById;

public class DeleteUserByIdService : IDeleteUserByIdService
{
    private readonly IDeleteUserByIdRepo _deleteUserByIdRepo;

    public DeleteUserByIdService(IDeleteUserByIdRepo deleteUserByIdRepo)
    {
        _deleteUserByIdRepo = deleteUserByIdRepo;
    }

    public async Task<DeleteUserByIdResult> DeleteUserByIdAsync(Guid id)
    {
        User user = await _deleteUserByIdRepo.DeleteUserByIdAsync(id);
        
        DeleteUserByIdResult result = new DeleteUserByIdResult
        (
            id: user.Id
        );

        return result;
    }
}