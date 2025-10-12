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

    private static readonly string[] Summaries = new[]
    {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public async Task<IEnumerable<WeatherForecast>> GetWeatherForecastAsync()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<WeatherForecast>>("WeatherForecast")
        //    ?? throw new InvalidOperationException("Failed to get weather forecast from external service");
        ?? Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}