using Microsoft.Extensions.Caching.Distributed;

namespace Distributed;

public interface ICachingService
{
    Task<byte[]?> GetBytesAsync(string key);

    Task SetBytesAsync(string key, byte[] value, DistributedCacheEntryOptions options);
}

public class CachingService : ICachingService
{
    private readonly IDistributedCache _cache;

    public CachingService(IDistributedCache cache)
    {
        _cache = cache;
    }

    public async Task<byte[]?> GetBytesAsync(string key)
    {
        return await _cache.GetAsync(key);
    }

    public async Task SetBytesAsync(string key, byte[] value, DistributedCacheEntryOptions options)
    {
        await _cache.SetAsync(key, value, options);
    }
}