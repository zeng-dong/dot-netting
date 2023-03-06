namespace BffApi.Core.Caching;

public interface IDistributedCacheFactory
{
    IDistributedCache<T> GetCache<T>();
}