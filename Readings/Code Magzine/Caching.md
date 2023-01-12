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



# In-Memory caching in ASP.NET Core