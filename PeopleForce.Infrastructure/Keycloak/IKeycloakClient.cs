namespace PeopleForce.Infrastructure.Keycloak;

public interface IKeycloakClient
{
    Task<string> GetAdminAccessTokenAsync(
        CancellationToken cancellationToken = default);

    Task<T?> GetAsync<T>(
        string endpoint,
        CancellationToken cancellationToken = default);
}