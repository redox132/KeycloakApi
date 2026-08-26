namespace PeopleForce.Infrastructure.Keycloak;

public class KeycloakConfig
{
    public required string BaseUrl  { get; set; }
    public required string Client { get; set; }
    public required string GrantTYpe { get; set; } = "authorization_code";
    public required string Realm  { get; set; }
    public required string ClientSecret  { get; set; }
    public required string RedirectUri { get; set; }
}