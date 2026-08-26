using System.Text.Json;
using Microsoft.Extensions.Options;
using PeopleForce.Application.Interfaces.Users.Commands.Authentication;
using PeopleForce.Infrastructure.Keycloak;

namespace PeopleForce.Infrastructure.Users.Commands.Authentication;

public class AuthenticationRepo : IAuthenticationRepo
{
    private readonly HttpClient _httpClient;
    private readonly KeycloakConfig _keyclockConfig;

    public AuthenticationRepo(
        HttpClient httpClient,
        IOptions<KeycloakConfig> keycloakConfig)
    {
        _httpClient = httpClient;
        _keyclockConfig = keycloakConfig.Value;
    }

    public async Task<KeycloakAuthResponse> Authenticate(AuthenticationRequest request)
    {
        var tokenUrl =
            $"{_keyclockConfig.BaseUrl}/realms/{_keyclockConfig.Realm}/protocol/openid-connect/token";

        var form = new FormUrlEncodedContent(new Dictionary<string, string>
        {
            ["client_id"] = _keyclockConfig.Client,
            ["grant_type"] = _keyclockConfig.GrantTYpe ?? "authorization_code",
            ["code"] = request.Code,
            ["redirect_uri"] = _keyclockConfig.RedirectUri ?? "http://localhost:8082",
            ["client_secret"] = _keyclockConfig.ClientSecret,
        });

        var response = await _httpClient.PostAsync(tokenUrl, form);

        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(
                $"Keycloak returned {(int)response.StatusCode}: {content}");
        }

        var result =
            JsonSerializer.Deserialize<KeycloakAuthResponse>(content);

        return result!;
    }
}