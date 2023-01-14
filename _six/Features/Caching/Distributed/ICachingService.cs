﻿using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Distributed;

public interface ICachingService
{
    Task<byte[]?> GetBytesAsync(string key);

    Task SetBytesAsync(string key, byte[] value, DistributedCacheEntryOptions options);

    Task SetStringAsync(string key, string value, DistributedCacheEntryOptions options);
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

    public async Task SetStringAsync(string key, string value, DistributedCacheEntryOptions options)
    {
        await SetAsync<string>(key, value, options);
    }

    public async Task<T?> GetAsync<T>(string key)
    {
        var val = await _cache.GetAsync(key);

        if (val == null) return default(T);

        return JsonSerializer.Deserialize<T>(val, JsonSerializerOptions);
    }

    public async Task SetAsync<T>(string key, T value, DistributedCacheEntryOptions options)
    {
        var bytes = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(value, JsonSerializerOptions));
        await _cache.SetAsync(key, bytes, options);
    }

    private static readonly JsonSerializerOptions JsonSerializerOptions =
        new()
        {
            PropertyNamingPolicy = null,
            WriteIndented = true,
            AllowTrailingCommas = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        };
}