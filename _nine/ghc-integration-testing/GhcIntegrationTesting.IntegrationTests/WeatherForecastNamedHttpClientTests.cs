using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using GhcIntegrationTesting.Api.Services;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace GhcIntegrationTesting.IntegrationTests;

/// <summary>
/// Demonstrates integration testing using Named HttpClient pattern.
/// 
/// Named HttpClient pattern offers several advantages over traditional HttpClient usage:
/// 
/// 1. Lifecycle Management:
///    - Prevents socket exhaustion by reusing HttpClient instances
///    - Automatically handles DNS changes through connection pooling
///    - Manages the lifetime of HttpClient instances properly
/// 
/// 2. Dependency Injection Integration:
///    - Allows clean dependency injection of HTTP clients
///    - Makes it easier to swap implementations for testing
///    - Enables typed clients for different services
/// 
/// 3. Configuration Management:
///    - Centralizes HTTP client configuration
///    - Allows different configurations for different endpoints
///    - Makes it easy to add middleware, handlers, or policies
/// 
/// 4. Testing Benefits:
///    - Enables easy mocking through custom handlers
///    - Allows verification of HTTP requests
///    - Supports different test configurations without changing code
/// 
/// 5. Resilience and Security:
///    - Can integrate with Polly for retry policies
///    - Centralizes security configuration (certificates, headers)
///    - Makes it easier to implement circuit breakers
/// 
/// For testing specifically, named HttpClient pattern enables:
/// - Replacing real HTTP calls with mocked responses
/// - Verifying exact requests made by the application
/// - Testing error handling and retry logic
/// - Simulating different network conditions
/// - Testing timeout and cancellation scenarios
/// 
/// This test class demonstrates these concepts by:
/// - Using a custom TestMessageHandler to mock responses
/// - Verifying request details (URL, headers, etc.)
/// - Testing both success and error scenarios
/// - Showing how to configure clients through DI
/// </summary>
public class WeatherForecastNamedHttpClientTests : IDisposable
{
    private readonly WebApplicationFactory<Program> _factory;
    private readonly HttpClient _client;
    private readonly TestMessageHandler _testMessageHandler;

    public WeatherForecastNamedHttpClientTests()
    {
        _testMessageHandler = new TestMessageHandler();

        _factory = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    // Remove the existing HttpClient registration
                    var descriptor = services.SingleOrDefault(d =>
                        d.ServiceType == typeof(IHttpClientFactory));
                    if (descriptor != null)
                    {
                        services.Remove(descriptor);
                    }

                    // Register HttpClient with test handler
                    services.AddHttpClient<IWeatherService, ExternalWeatherService>()
                        .ConfigurePrimaryHttpMessageHandler(() => _testMessageHandler);
                });
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

        _testMessageHandler.QueueResponse(HttpStatusCode.OK, mockResponse);

        // Act
        var response = await _client.GetAsync("/WeatherForecast");

        // Assert
        response.EnsureSuccessStatusCode();
        var forecasts = await response.Content.ReadFromJsonAsync<IEnumerable<WeatherForecast>>();
        forecasts.Should().NotBeNull();
        forecasts.Should().HaveCount(1);
        forecasts.First().Summary.Should().Be("Mild");
        forecasts.First().TemperatureC.Should().Be(20);

        // Verify the request
        _testMessageHandler.Requests.Should().HaveCount(1);
        _testMessageHandler.Requests[0].RequestUri?.PathAndQuery.Should().Be("/WeatherForecast");
    }

    [Fact]
    public async Task Get_ShouldReturn500_WhenExternalServiceFails()
    {
        // Arrange
        _testMessageHandler.QueueResponse(HttpStatusCode.InternalServerError, "External service error");

        // Act
        var response = await _client.GetAsync("/WeatherForecast");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
        var errorMessage = await response.Content.ReadAsStringAsync();
        errorMessage.Should().Contain("Failed to get weather forecast from external service");

        // Verify the request
        _testMessageHandler.Requests.Should().HaveCount(1);
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

        _testMessageHandler.QueueResponse(HttpStatusCode.OK, mockResponse);

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

        // Verify the request
        _testMessageHandler.Requests.Should().HaveCount(1);
    }

    public void Dispose()
    {
        _client.Dispose();
        _factory.Dispose();
    }
}