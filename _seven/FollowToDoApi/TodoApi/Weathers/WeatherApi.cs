using Microsoft.AspNetCore.Http.HttpResults;
using TodoApi.Todos;

namespace TodoApi.Weathers;

internal static class WeatherApi
{
    public static RouteGroupBuilder MapWeathers(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/weathers");

        var summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };

        group.MapGet("/", () =>
        {
            var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
                .ToArray();
            return forecast;
        })
        .WithName("GetWeatherForecast")
        .WithOpenApi();

        group.MapGet("/{id}", Results<Ok<bool>, NotFound> (int id) =>
        {
            if (id % 5 == 0)
            {
                return TypedResults.NotFound();
            }

            return id % 2 == 0 ? TypedResults.Ok(true) : TypedResults.Ok(false);
        });

        return group;
    }
}