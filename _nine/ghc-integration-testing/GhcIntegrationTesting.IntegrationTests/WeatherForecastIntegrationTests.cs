using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using GhcIntegrationTesting.Api.Services;
using Microsoft.AspNetCore.Mvc.Testing;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace GhcIntegrationTesting.IntegrationTests;

public class WeatherForecastIntegrationTests : IDisposable
{
    private readonly WebApplicationFactory<Program> _factory;
    private readonly WireMockServer _mockServer;
    private readonly HttpClient _client;

    public WeatherForecastIntegrationTests()
    {
        _mockServer = WireMockServer.Start();

        _factory = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                builder.UseSetting("ExternalWeatherService:BaseUrl", _mockServer.Url);
            });

        _client = _factory.CreateClient();
    }

    [Fact]
    public async Task Get_ShouldReturnWeatherForecast_WhenExternalServiceResponds()
    {
        // Arrange
        var mockResponse = new[]
        {
            new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now),
                TemperatureC = 20,
                Summary = "Mild"
            }
        };

        _mockServer
            .Given(Request.Create().WithPath("/WeatherForecast").UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(HttpStatusCode.OK)
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(mockResponse));

        // Act
        var response = await _client.GetAsync("/WeatherForecast");

        // Assert
        response.EnsureSuccessStatusCode();
        var forecasts = await response.Content.ReadFromJsonAsync<IEnumerable<WeatherForecast>>();
        forecasts.Should().NotBeNull();
        forecasts.Should().HaveCount(1);
        forecasts.First().Summary.Should().Be("Mild");
        forecasts.First().TemperatureC.Should().Be(20);
    }

    [Fact]
    public async Task Get_ShouldReturn500_WhenExternalServiceFails()
    {
        // Arrange
        _mockServer
            .Given(Request.Create().WithPath("/WeatherForecast").UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(HttpStatusCode.InternalServerError)
                .WithBody("External service error"));

        // Act
        var response = await _client.GetAsync("/WeatherForecast");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
        var errorMessage = await response.Content.ReadAsStringAsync();
        errorMessage.Should().Contain("Failed to get weather forecast from external service");
    }

    [Fact]
    public async Task Get_ShouldReturnMultipleForecasts_WhenExternalServiceProvidesArray()
    {
        // Arrange
        var mockResponse = new[]
        {
            new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now),
                TemperatureC = 20,
                Summary = "Mild"
            },
            new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
                TemperatureC = 25,
                Summary = "Warm"
            },
            new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(2)),
                TemperatureC = 15,
                Summary = "Cool"
            }
        };

        _mockServer
            .Given(Request.Create().WithPath("/WeatherForecast").UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(HttpStatusCode.OK)
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(mockResponse));

        // Act
        var response = await _client.GetAsync("/WeatherForecast");

        // Assert
        response.EnsureSuccessStatusCode();
        var forecasts = await response.Content.ReadFromJsonAsync<IEnumerable<WeatherForecast>>();
        forecasts.Should().NotBeNull();
        forecasts.Should().HaveCount(3);

        // Verify first forecast
        forecasts.ElementAt(0).Summary.Should().Be("Mild");
        forecasts.ElementAt(0).TemperatureC.Should().Be(20);

        // Verify second forecast
        forecasts.ElementAt(1).Summary.Should().Be("Warm");
        forecasts.ElementAt(1).TemperatureC.Should().Be(25);

        // Verify third forecast
        forecasts.ElementAt(2).Summary.Should().Be("Cool");
        forecasts.ElementAt(2).TemperatureC.Should().Be(15);

        // Verify dates are sequential
        forecasts.ElementAt(1).Date.Should().BeAfter(forecasts.ElementAt(0).Date);
        forecasts.ElementAt(2).Date.Should().BeAfter(forecasts.ElementAt(1).Date);
    }

    public void Dispose()
    {
        _mockServer.Dispose();
        _client.Dispose();
        _factory.Dispose();
    }
}