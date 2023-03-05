using BffApi.Domain;

namespace BffApi.Services;

public interface IWeatherForecaster
{
    Task<CurrentWeatherResult> GetCurrentWeatherAsync();

    bool ForecastEnabled { get; }
}