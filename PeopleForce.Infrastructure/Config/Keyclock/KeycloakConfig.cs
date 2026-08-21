namespace PeopleForce.Infrastructure.Config.Keyclock;

public class KeycloakConfig
{
    public required string BaseUrl  { get; set; }
    public required string Client { get; set; }
    public required string Realm  { get; set; }
    public required string GrantTYpe { get; init; } = "authorization_code";
    public required string RedirectUri { get; set; }
}