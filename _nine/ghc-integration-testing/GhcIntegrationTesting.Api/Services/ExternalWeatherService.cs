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
        var data = await _httpClient.GetFromJsonAsync<IEnumerable<WeatherForecast>>("WeatherForecast");
        //if (data != null)
        //{
        //    foreach (var item in data)
        //    {
        //        item.Summary = item.Summary + " - brought to you by Awesome Bridge";
        //    }
        //}

        return data ?? [];
        //return await _httpClient.GetFromJsonAsync<IEnumerable<WeatherForecast>>("WeatherForecast") ?? [];
        //try
        //{
        //    return await _httpClient.GetFromJsonAsync<IEnumerable<WeatherForecast>>("WeatherForecast");
        //}
        //catch
        //{
        //    throw new InvalidOperationException("Failed to get weather forecast from external service");
        //}
    }
}