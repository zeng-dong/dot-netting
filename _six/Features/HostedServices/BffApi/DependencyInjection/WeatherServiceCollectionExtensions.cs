using BffApi.Core;
using BffApi.External;
using BffApi.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace BffApi.DependencyInjection;

public static class WeatherServiceCollectionExtensions
{
    public static IServiceCollection AddWeatherForecasting(this IServiceCollection services, IConfiguration config)
    {
        if (config.IsWeatherForecastEnabled())
        {
            services.AddHttpClient<IWeatherApiClient, WeatherApiClient>();
            services.TryAddSingleton<IWeatherForecaster, WeatherForecaster>();
            services.Decorate<IWeatherForecaster, CachedWeatherForecaster>();
        }
        else
        {
            services.TryAddSingleton<IWeatherForecaster, DisabledWeatherForecaster>();
        }

        return services;
    }
}