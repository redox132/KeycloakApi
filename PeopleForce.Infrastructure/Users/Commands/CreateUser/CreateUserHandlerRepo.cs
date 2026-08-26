using PeopleForce.Application.Interfaces.Users.Commands.CreateUser;
using PeopleForce.Application.Interfaces.Users.Commands.CreateUser.CreateUserRepo;
using PeopleForce.Application.Interfaces.Users.Commands.CreateUser.Dtos;
using PeopleForce.Domain;
using PeopleForce.Infrastructure.PeopleForceAppDbContext;

namespace PeopleForce.Infrastructure.Users.Commands.CreateUser;

public class CreateUserHandlerRepo : ICreateUserHandlerRepo
{
    private readonly PeopleAppDbContext _dbContext;

    public CreateUserHandlerRepo(PeopleAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CreateUserResponse> CreateUserAsync(User request)
    {
        await _dbContext.Users.AddAsync(request);
        await _dbContext.SaveChangesAsync();
        
        CreateUserResponse  response = new CreateUserResponse
        (
            Id: request.Id,
            Name: request.Name,
            Email: request.Email
        );

        return response;
    }
}