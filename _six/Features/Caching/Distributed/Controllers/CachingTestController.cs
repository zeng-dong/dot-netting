using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Distributed.Controllers;

[ApiController]
[Route("[controller]")]
public class CachingTestController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;

    public CachingTestController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }
}