using BffApi.External.Models;

namespace BffApi.External;

public interface IWeatherApiClient
{
    Task<WeatherApiResult> GetWeatherForecastAsync(CancellationToken cancellationToken = default);
}