using GhcIntegrationTesting.Api.Controllers;
using GhcIntegrationTesting.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace GhcIntegrationTesting.Api.Services;

public class ExternalWeatherService : IWeatherService
{
    private readonly HttpClient _httpClient;

    public ExternalWeatherService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<WeatherForecast>> GetWeatherForecastAsync()
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<WeatherForecast>>("weatherforecast");
        }
        catch
        {
            throw new InvalidOperationException("Failed to get weather forecast from external service");
        }
    }
}