using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.Extensions.Options;
using PeopleForce.Application.Users.Authentication;
using PeopleForce.Infrastructure.Config.Keyclock;

namespace PeopleForce.Infrastructure.Users.Commands.Authentication;

public class AuthenticationRepo : IAuthenticationRepo
{
    private readonly HttpClient _httpClient;
    private readonly KeyclockConfig _keyclockConfig;

    public AuthenticationRepo(
        HttpClient httpClient,
        IOptions<KeyclockConfig> keyclockConfig)
    {
        _httpClient = httpClient;
        _keyclockConfig = keyclockConfig.Value;
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
            ["redirect_uri"] = _keyclockConfig.RedirectUri ?? "http://localhost:8000"
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