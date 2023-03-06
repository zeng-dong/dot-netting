using BffApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BffApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IWeatherForecaster _weatherForecaster;

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(IWeatherForecaster weatherForecaster, ILogger<WeatherForecastController> logger)
    {
        _weatherForecaster = weatherForecaster;
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IActionResult> Get(string city)
    {
        var currentWeather = await _weatherForecaster.GetCurrentWeatherAsync();

        return Ok(currentWeather);
    }
}