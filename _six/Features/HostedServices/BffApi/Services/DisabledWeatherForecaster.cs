﻿using BffApi.Domain;

namespace BffApi.Services;

public class DisabledWeatherForecaster : IWeatherForecaster
{
    public bool ForecastEnabled => false;

    public Task<CurrentWeatherResult> GetCurrentWeatherAsync()
    {
        var result = new CurrentWeatherResult
        {
            Description = "The weather forecast feature is not currently available"
        };

        return Task.FromResult(result);
    }
}