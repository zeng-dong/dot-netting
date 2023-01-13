# Distributed caching in ASP.NET Core
ASP.NET Core supports different types of distributed cache implementations and it is very easy to change the implementation later by just changing the configuration. Regardless of the implementation that we choose, for working with the distributed cache, we always use the **IDistributedCache** interface.

## ## Different Distributed Caching Services in ASP.NET Core

### ### Distributed Memory Cache- 
```c#
builder.Services.AddDistributedMemoryCache();
```

### ### **SQL Server Cache**

The distributed SQL Server Cache implementation of `IDistributedCache` stores data in an SQL server database. We can use the `sql-cache` tool to configure an SQL Server database for distributed caching support. By using the `sql-cache create` command, we can create a table for storing the cache items:

```
dotnet sql-cache create "Data Source=.;Initial Catalog=MyDB;Integrated Security=True;" dbo CacheItems
```

```c#
builder.Services.AddDistributedSqlServerCache(options =>
{
	options.ConnectionString = builder.Configuration.GetConnectionString(
		"DBConnectionString");
	options.SchemaName = "dbo";
	options.TableName = "CacheItems";
});
```

add `Microsoft.Extensions.Caching.SqlServer`

### Redis (remote dictionary server) Cache
#### Configure the Redis service (we use Azure Cache for Redis here)

#### dependencies
add `Microsoft.Extensions.Caching.StackExchangeRedis`

#### configure middleware
``` c#
builder.Services.AddStackExchangeRedisCache(options =>
{
	options.Configuration = builder.Configuration["ConnectionString:Redis"];
	options.InstanceName = "SampleInstance";
});
```

### NCache Cache


# In-Memory caching in ASP.NET Core

the `IMemoryCache` interface

## Implementing an Im-Memory Cache

``` c#
[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private const string employeeListCacheKey = "employeeList";
    private readonly IDataRepository<Employee> _dataRepository;
    private IMemoryCache _cache;
    private ILogger<EmployeeController> _logger;

    public EmployeeController(IDataRepository<Employee> dataRepository,
        IMemoryCache cache,
        ILogger<EmployeeController> logger)
    {
        _dataRepository = dataRepository ?? throw new 
	        ArgumentNullException(nameof(dataRepository));
        _cache = cache ?? throw new ArgumentNullException(nameof(cache));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        _logger.Log(LogLevel.Information, "Trying to fetch the list of employees from cache.");

        if (_cache.TryGetValue(employeeListCacheKey, out IEnumerable<Employee> employees))
        {
            _logger.Log(LogLevel.Information, "Employee list found in cache.");
        }
        else
        {
            _logger.Log(LogLevel.Information, "Employee list not found in cache. Fetching from database.");

            employees = _dataRepository.GetAll();

            var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(60))
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(3600))
                    .SetPriority(CacheItemPriority.Normal)
                    .SetSize(1024);

            _cache.Set(employeeListCacheKey, employees, cacheEntryOptions);
        }

        return Ok(employees);
    }
}
```

## Configuring the Cache Options

## Setting a Size Limit on Memory Cache

## Managing Concurrent Access of  In-Memory Cache
Now let’s assume that multiple users try to access the data from In-Memory Cache at the same time. **Even though the** `IMemoryCache` **is thread-safe, it is prone to race conditions.** For instance, if the cache is empty and two users try to access data at the same time, there is a chance that both users may fetch the data from the database and populate the cache. This is not desirable. To solve these kinds of issues, we need to implement a locking mechanism for the cache.

For implementing locking for cache, we can use the `SemaphoreSlim` class, which is a lightweight version of the `Semaphore` class. This will help us control the number of threads that can access a resource concurrently. Let’s declare a `SemaphoreSlim` object in the controller to implement locking of cache:

```c#
private static readonly SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);
```

to implement locking of cache:
```c#
[HttpGet]
public async Task<IActionResult> GetAsync()
{
    _logger.Log(LogLevel.Information, "Trying to fetch the list of employees from cache.");

    if (_cache.TryGetValue("employeeList", out IEnumerable<Employee> employees))
    {
        _logger.Log(LogLevel.Information, "Employee list found in cache.");        
    }
    else
    {
        try
        {
            await semaphore.WaitAsync();

            if (_cache.TryGetValue("employeeList", out employees))
            {
                _logger.Log(LogLevel.Information, "Employee list found in cache.");
            }
            else
            {
                _logger.Log(LogLevel.Information, "Employee list not found in cache. Fetching from database.");

                employees = _dataRepository.GetAll();

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromSeconds(60))
                        .SetAbsoluteExpiration(TimeSpan.FromSeconds(3600))
                        .SetPriority(CacheItemPriority.Normal)
                        .SetSize(1024);

                _cache.Set(employeeListCacheItem, employees, cacheEntryOptions);
            }
        }
        finally
        {
            semaphore.Release();
        }
    }

    return Ok(employees);
}
```