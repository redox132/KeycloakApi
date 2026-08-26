using PeopleForce.Application.Interfaces.Users.Queries.GetUsers.Repository;
using PeopleForce.Domain;
using PeopleForce.Infrastructure.Keycloak;

namespace PeopleForce.Infrastructure.Users.Queries;

public sealed class GetUsersRepo : IGetUsersRepo
{
    private readonly IKeycloakClient _keycloakClient;

    public GetUsersRepo(IKeycloakClient keycloakClient)
    {
        _keycloakClient = keycloakClient;
    }

    public async Task<List<User>> GetUsersAsync(
        int pageNumber,
        int pageSize)
    {
        if (pageNumber < 1)
            throw new ArgumentOutOfRangeException(nameof(pageNumber));

        if (pageSize < 1)
            throw new ArgumentOutOfRangeException(nameof(pageSize));

        var first = (pageNumber - 1) * pageSize;

        var users =
            await _keycloakClient.GetAsync<List<KeycloakUserResponse>>(
                $"/admin/realms/peopleforce/users" +
                $"?first={first}&max={pageSize}");

        if (users is null)
            return [];

        return users.Select(user => new User
        {
            Id = Guid.TryParse(user.Id, out var id) ? id : Guid.Empty,
            Name = $"{user.FirstName} {user.LastName}".Trim() is { Length: > 0 } name
                ? name
                : user.Username,
            Email = user.Email ?? string.Empty,
        }).ToList();
    }
}