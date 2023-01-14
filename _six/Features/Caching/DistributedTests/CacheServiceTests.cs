using Distributed;
using FluentAssertions;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Xunit.Abstractions;

namespace DistributedTests;

public class CacheServiceTests
{
    [Fact]
    public void Can_set_byte_array()
    {
        Given_byte_array();

        When_set_to_cache_as_byte_array();

        Then_the_byte_array_is_set_in_cache();
    }

    [Fact]
    public void Can_set_string()
    {
        Given_string();

        When_set_to_cache_as_string();

        Then_the_string_is_set_in_cache();
    }

    private void Given_byte_array()
    {
        _bytes = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
    }

    private void Given_string()
    {
        _string = "Hello World";
    }

    private void When_set_to_cache_as_byte_array()
    {
        _cache.SetBytesAsync(_cacheKey, _bytes!, new DistributedCacheEntryOptions()).Wait();
    }

    private void When_set_to_cache_as_string()
    {
        _cache.SetStringAsync(_cacheKey, _string!, new DistributedCacheEntryOptions()).Wait();
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
        entry.Should().Contain(_string);
    }

    public CacheServiceTests(ITestOutputHelper output)
    {
        _output = output;

        _innerImplementation = new MemoryDistributedCache(
                Options.Create(new MemoryDistributedCacheOptions()));

        _cache = new CachingService(_innerImplementation);
    }

    private byte[]? _bytes;
    private string? _string;
    private readonly IDistributedCache _innerImplementation;
    private readonly CachingService _cache;
    private readonly ITestOutputHelper _output;
    private const string _cacheKey = "policy-123";
}