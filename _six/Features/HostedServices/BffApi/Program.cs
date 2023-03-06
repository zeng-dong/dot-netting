using BffApi.Configuration;
using BffApi.DependencyInjection;

namespace BffApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var config = builder.Configuration;

        builder.Services.Configure<WeatherForecastingConfiguration>(config.GetSection("Features:WeatherForecasting"));
        builder.Services.Configure<ExternalServicesConfig>(ExternalServicesConfig.WeatherApi, config.GetSection("ExternalServices:WeatherApi"));

        builder.Services.AddWeatherForecasting(config)
            .AddCaching();

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}