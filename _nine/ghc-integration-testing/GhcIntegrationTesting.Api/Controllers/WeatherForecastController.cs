using GhcIntegrationTesting.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace GhcIntegrationTesting.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IWeatherService _weatherService;

    public WeatherForecastController(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var forecast = await _weatherService.GetWeatherForecastAsync();
            return Ok(forecast);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Failed to get weather forecast from external service: " + ex.Message);
        }
    }
}