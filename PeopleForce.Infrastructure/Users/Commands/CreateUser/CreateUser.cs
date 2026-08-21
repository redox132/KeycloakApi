using PeopleForce.Application.Interfaces.Users.Commands.CreateUser;
using PeopleForce.Application.Interfaces.Users.Commands.CreateUser.CreateUserRepo;
using PeopleForce.Application.Interfaces.Users.Dtos;
using PeopleForce.Domain;
using PeopleForce.Infrastructure.PeopleForceAppDbContext;

namespace PeopleForce.Infrastructure.Users.Commands.CreateUser;

public class CreateUser : ICreateUser
{
    private readonly AppDbContext _dbContext;

    public CreateUser(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<UserDto> CreateUserAsync(User request)
    {
        await _dbContext.Users.AddAsync(request);
        await _dbContext.SaveChangesAsync();
        
        UserDto userDto = new UserDto
        {
            Id = request.Id,
            Name = request.Name,
            Email = request.Email,
        };

        return userDto;
    }
}