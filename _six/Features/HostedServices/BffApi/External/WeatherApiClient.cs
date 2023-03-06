using BffApi.Configuration;
using BffApi.External.Models;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace BffApi.External;

public class WeatherApiClient : IWeatherApiClient
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<WeatherApiClient> _logger;

    public WeatherApiClient(HttpClient httpClient, IOptionsMonitor<ExternalServicesConfig> options, ILogger<WeatherApiClient> logger)
    {
        var externalServiceConfig = options.Get(ExternalServicesConfig.WeatherApi);

        httpClient.BaseAddress = new Uri(externalServiceConfig.Url);

        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<WeatherApiResult> GetWeatherForecastAsync(CancellationToken cancellationToken = default)
    {
        const string path = "api/currentWeather/Brighton";

        try
        {
            var response = await _httpClient.GetAsync(path, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            WeatherApiResult content = await response.Content.ReadFromJsonAsync<WeatherApiResult>(cancellationToken: cancellationToken);

            ///var responseContent = await response.Content.ReadAsStringAsync();
            ///WeatherApiResult content = JsonSerializer.Deserialize<WeatherApiResult>(responseContent);

            ///var content = await response.Content.ReadAsAsync<WeatherApiResult>(cancellationToken);

            return content;
        }
        catch (HttpRequestException e)
        {
            _logger.LogError(e, "Failed to get weather data from API");
        }

        return null;
    }
}