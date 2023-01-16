using Distributed;
using FluentAssertions;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.Options;
using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Xunit.Abstractions;

namespace DistributedTests;

public class CacheServiceTests
{
    [Fact]
    public void It_adds_byte_array_to_cache()
    {
        Given_byte_array();

        When_set_to_cache_as_byte_array();

        Then_the_byte_array_is_set_in_cache();
    }

    [Fact]
    public void It_adds_string_to_cache()
    {
        Given_string();

        When_set_to_cache_as_string();

        Then_the_string_is_set_in_cache();
    }

    [Fact]
    public void It_retrieves_string_from_cache()
    {
        Given_string_exists_in_cache();

        When_retrieve_from_cache_as_string();

        Then_the_string_is_retrieved_from_cache();
    }

    [Fact]
    public void It_adds_type_instance_to_cache()
    {
        Given_an_instance_of_a_type();

        When_set_to_cache_as_type();

        Then_the_instance_is_set_in_cache();
    }

    [Fact]
    public void It_retrieves_type_instance_when_exists()
    {
        Given_an_instance_exsits_in_cache();

        When_retrieve_from_cache_as_type();

        Then_the_instance_is_retrieved_from_cache();
    }

    [Fact]
    public void It_retrieves_null_as_type_instalce_when_not_exist()
    {
        Given_an_instance_not_exsits_in_cache();

        When_retrieve_from_cache_as_type();

        Then_null_is_retrieved_from_cache();
    }

    [Fact]
    public void It_removes_cached_entry()
    {
        Given_a_cache_entry_with_known_cache_key();

        When_remove_from_cache_with_this_cache_key();

        Then_cache_entry_with_the_cache_key_is_removed_from_cache();
    }

    private void Given_byte_array()
    {
        _bytes = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
    }

    private void Given_string()
    {
        _stringToBeCached = "Hello World";
    }

    private void Given_an_instance_of_a_type()
    {
        InitInstance();
    }

    private void Given_an_instance_exsits_in_cache()
    {
        InitInstance();

        _innerImplementation
            .SetAsync(_cacheKey,
            Encoding.UTF8.GetBytes(JsonSerializer.Serialize(_instanceToBeCached, _jsonSerializerOptions)),
            _distributedCacheEntryOptions).Wait();
    }

    private void Given_string_exists_in_cache()
    {
        _stringToBeCached = "magic string";
        _innerImplementation.SetStringAsync(_cacheKey, _stringToBeCached, _distributedCacheEntryOptions).Wait();
    }

    private void Given_a_cache_entry_with_known_cache_key()
    {
        _innerImplementation.SetString(_cacheKey, "Hello World", _distributedCacheEntryOptions);
    }

    private void Given_an_instance_not_exsits_in_cache()
    {
        _innerImplementation.Remove(_cacheKey);
    }

    private void When_set_to_cache_as_byte_array()
    {
        _cache.SetBytesAsync(_cacheKey, _bytes!, _distributedCacheEntryOptions).Wait();
    }

    private void When_set_to_cache_as_string()
    {
        _cache.SetStringAsync(_cacheKey, _stringToBeCached!, _distributedCacheEntryOptions).Wait();
    }

    private void When_set_to_cache_as_type()
    {
        _cache.SetAsync(_cacheKey, _instanceToBeCached, _distributedCacheEntryOptions).Wait();
    }

    private void When_retrieve_from_cache_as_type()
    {
        _instanceRetrievedFromCache = _cache.GetAsync<Policy>(_cacheKey).Result;
    }

    private void When_retrieve_from_cache_as_string()
    {
        _stringRetrievedFromCache = _cache.GetStringAsync(_cacheKey).Result;
    }

    private void When_remove_from_cache_with_this_cache_key()
    {
        _cache.RemoveAsync(_cacheKey).Wait();
    }

    private void Then_the_byte_array_is_set_in_cache()
    {
        var entry = _innerImplementation.Get(_cacheKey);
        entry.Should().BeEquivalentTo(_bytes);
    }

    private void Then_the_string_is_set_in_cache()
    {
        var entry = _innerImplementation.GetString(_cacheKey);
        _output.WriteLine(entry);
        entry.Should().Contain(_stringToBeCached);
    }

    private void Then_the_instance_is_set_in_cache()
    {
        var entry = _innerImplementation.GetString(_cacheKey);
        entry.Should().NotBeNull();

        var instance = JsonSerializer.Deserialize<Policy>(entry, _jsonSerializerOptions);

        _output.WriteLine($"{instance!.Name}: {instance.Premium}, {instance.Liability!.Limit}");
        instance.Should().BeEquivalentTo(_instanceToBeCached);
    }

    private void Then_the_instance_is_retrieved_from_cache()
    {
        _instanceRetrievedFromCache.Should().BeEquivalentTo(_instanceToBeCached);
    }

    private void Then_the_string_is_retrieved_from_cache()
    {
        _stringRetrievedFromCache.Should().BeEquivalentTo(_stringToBeCached);
        _output.WriteLine(_stringRetrievedFromCache);
    }

    private void Then_null_is_retrieved_from_cache()
    {
        _instanceRetrievedFromCache.Should().BeNull();
    }

    private void Then_cache_entry_with_the_cache_key_is_removed_from_cache()
    {
        var entry = _innerImplementation.Get(_cacheKey);
        entry.Should().BeNull();
    }

    private void InitInstance()
    {
        _instanceToBeCached = new()
        {
            Id = 123,
            Name = "MD-5044",
            Premium = 999,
            Liability = new()
            {
                Id = 601,
                Limit = 3500,
                Deductible = 500
            }
        };
    }

    public CacheServiceTests(ITestOutputHelper output)
    {
        _output = output;

        //// _innerImplementation = MemoryCache;

        _innerImplementation = RedisCache;

        _cache = new CachingService(_innerImplementation);
        _distributedCacheEntryOptions = new()
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(3)
        };
        _cacheKey = Guid.NewGuid().ToString();

        _output.WriteLine($"current key = {_cacheKey}");
    }

    private IDistributedCache MemoryCache => new MemoryDistributedCache(
                Options.Create(new MemoryDistributedCacheOptions()));

    private IDistributedCache RedisCache => new RedisCache(Options.Create(new RedisCacheOptions()
    {
        Configuration = "localhost",
        InstanceName = "UnitTest-",
    }));

    private byte[]? _bytes;
    private string? _stringToBeCached, _stringRetrievedFromCache;
    private Policy? _instanceToBeCached, _instanceRetrievedFromCache;
    private readonly IDistributedCache _innerImplementation;
    private readonly ICachingService _cache;
    private readonly ITestOutputHelper _output;
    private readonly string _cacheKey;
    private readonly DistributedCacheEntryOptions _distributedCacheEntryOptions;

    private static readonly JsonSerializerOptions _jsonSerializerOptions = new()
    {
        PropertyNamingPolicy = null,
        WriteIndented = true,
        AllowTrailingCommas = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    };
}