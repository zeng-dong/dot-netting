using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Distributed.Controllers;

[ApiController]
[Route("[controller]")]
public class CachingTestController : ControllerBase
{
    private readonly ILogger<CachingTestController> _logger;
    private readonly IDistributedCache _cache;

    public CachingTestController(ILogger<CachingTestController> logger, IDistributedCache cache)
    {
        _logger = logger;
        _cache = cache;
    }

    public async Task<Policy> Get(string name)
    {
        var result = await _cache.GetAsync(name);

        if (result == null)
        {
            Thread.Sleep(5000);
            var newPolicy = new Policy
            {
                Id = 123,
                Name = name,
                Premium = 999,
                Liability = new()
                {
                    Id = 601,
                    Limit = 3500,
                    Deductible = 500
                }
            };

            var serialized = JsonSerializer.Serialize(newPolicy, CacheSourceGenerationContext.Default.Policy);

            await _cache.SetAsync(name, Encoding.UTF8.GetBytes(serialized),
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
                });

            return newPolicy;
        }

        var policy = JsonSerializer.Deserialize(Encoding.UTF8.GetString(result), CacheSourceGenerationContext.Default.Policy);

        return policy!;
    }
}

public class Policy
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public double Premium { get; set; }
    public Liability? Liability { get; set; }
}

[JsonSerializable(typeof(Policy))]
public partial class CacheSourceGenerationContext : JsonSerializerContext
{
}

public class Liability
{
    public int Id { get; set; }
    public decimal Limit { get; set; }
    public decimal Deductible { get; set; }
}