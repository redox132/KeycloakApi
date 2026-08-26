using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.Extensions.Options;
using PeopleForce.Application.Interfaces.Users.Commands.Authentication;

namespace PeopleForce.Infrastructure.Keycloak;

public class KeycloakClient : IKeycloakClient
{
    private readonly HttpClient _httpClient;
    private readonly KeycloakConfig _config;

    public KeycloakClient(
        HttpClient httpClient,
        IOptions<KeycloakConfig> config)
    {
        _httpClient = httpClient;
        _config = config.Value;
    }

    public async Task<string> GetAdminAccessTokenAsync(
        CancellationToken cancellationToken = default)
    {
        var tokenUrl =
            $"{_config.BaseUrl.TrimEnd('/')}/realms/{_config.Realm}/protocol/openid-connect/token";

        var form = new FormUrlEncodedContent(
            new Dictionary<string, string>
            {
                ["client_id"] = _config.Client,
                ["client_secret"] = _config.ClientSecret!,
                ["grant_type"] = "client_credentials"
            });

        var response = await _httpClient.PostAsync(
            tokenUrl,
            form,
            cancellationToken);

        var content = await response.Content.ReadAsStringAsync(
            cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(
                $"Keycloak token request failed. " +
                $"Status: {(int)response.StatusCode} {response.StatusCode}. " +
                $"Response: {content}");
        }

        var result =
            JsonSerializer.Deserialize<KeycloakAuthResponse>(
                content,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

        return result?.AccessToken
               ?? throw new Exception(
                   "Keycloak did not return an access token.");
    }
    
    public async Task<T?> GetAsync<T>(
        string endpoint,
        CancellationToken cancellationToken = default)
    {
        var token = await GetAdminAccessTokenAsync(cancellationToken);

        using var request = new HttpRequestMessage(
            HttpMethod.Get,
            $"{_config.BaseUrl}{endpoint}");

        request.Headers.Authorization =
            new AuthenticationHeaderValue("Bearer", token);

        var response = await _httpClient.SendAsync(
            request,
            cancellationToken);

        var content = await response.Content.ReadAsStringAsync(
            cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(
                $"Keycloak returned {(int)response.StatusCode}: {content}");
        }

        return JsonSerializer.Deserialize<T>(
            content,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
    }
}