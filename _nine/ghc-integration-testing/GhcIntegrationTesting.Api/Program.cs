using GhcIntegrationTesting.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register HttpClient and WeatherService
builder.Services.AddHttpClient<IWeatherService, ExternalWeatherService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ExternalWeatherService:BaseUrl"] ?? "http://example.com");
});

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

// Make Program accessible to integration tests
public partial class Program { }
