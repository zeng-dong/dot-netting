namespace GhcIntegrationTesting.Api.Services;

public interface IWeatherService
{
    Task<IEnumerable<WeatherForecast>> GetWeatherForecastAsync();
}

public class WeatherForecast
{
    public DateOnly Date { get; set; }
    public int TemperatureC { get; set; }
    public string? Summary { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}