
# Caching Techniques

## Distributed Caching with Expiration

- use a distributed cache instead of an in‑memory one
- The first thing we need to do is update our constructor to inject an IDistributedCache instance
	- using the interface instead of using a direct implementation of ours, we'll have flexibility in choosing whatever store we want for our distributed cache
- typical steps:
	- check cache for results
	- if present, return them
	- if not
		- get them normally
		- cache them
		- return them
- GetAsync method returns a byte array
- . Since we're using some external store for the cache data, and that external store could be any number of different things, a byte array was chosen to accommodate the possible variety of destinations. This means that we'll need to be able to serialize and deserialize our cached content to byte arrays when working with a distributed cache. For now, let's work the case where we didn't find anything in the cache so our results are null, and we need to get them from the database. I'll paste in the database logic from the memory caching block above, and I'll change the captured variable to a local variable of products that we'll need to serialize. And if we have determined that we really do want to cache these particular results, we know that we're already concerned with performance, so we're going to want to make our serialization logic as fast as we can, too. Remember what we saw in the last module? Yep, source generators, with System.Text.Json. This serialization is on our ProductEntity class rather than the ProductModel that we worked with earlier, so I added a new SourceGenerationContext class here. It inherits from JsonSerializerContext and uses an attribute to indicate that it can handle lists of products. Since I'll use this technique for both serialization and deserialization, I don't need to indicate any special case handling here. But with that class in place, we can use a JsonSerializer to serialize our product results. We pass in those results and the CacheSourceGenerationContext class, its default instance, and the list of products that we set up. That's a serialized JSON string, but we need a byte array. So when we set this content into the cache, we can use the Encoding.UTF8.GetBytes method on this string to be what we actually cache. And when we put something into the cache, we need to specify how long we want it to stick around, and possibly some other options. For simplicity's sake, I'm just going to use the absolute expiration from now option and keep our cached data for 10 minutes. And now we want to return some results to the caller of the method. To avoid deserializing the results we just got and serialized, we can return the productsToSerialize variable that we set with the results of our database query. And now we need to handle the situation where we actually found the results in our cache. Remember, this is a byte array, so we need to deserialize it using the reverse technique from what we just did above. We can do this in a single line by using the JsonSerializer to deserialize not the disk results byte array, but the Encoding.UTF8.GetString of that byte array. Again, we use the CacheSourceGenerationContext with the list of products to take advantage of our source generator. I'll return these results coalesced with an empty list, and the IDE is complaining that I've got two variables for results. We don't need both in‑memory and distributed caching here, so I'll comment out our in‑memory black. This logic should work just fine regardless of what we choose to use for a distributed cache. We just need to provide an implementation during our app startup. Let's do that and validate our code in the next clip.


## Redis as a Distributed Cache

### set up Redis using Docker Desktop
it implies two prerequisites if you're on Windows; WSL, which is Windows Subsystem for Linux, and then Docker Desktop. 

You can also install Redis locally if you have WSL installed without using Docker Desktop. 

If you have access to a cloud service and don't want to install Redis locally at all

Your Redis connection string is simply going to be a little different

other implementations of IDistributedCache. You could use SQL Server, NCache, or even SQLite 

////////// clean up
stop all container
docker stop $(docker ps -aq)

remove all container
docker rm $(docker ps -aq)
//////////

- docker pull redis
- docker run -d --name redisDev -p 6379:6379 redis
- Microsoft.Extensions.Caching.StackExchan  (6.0.13)  EDahl used 6.0.9
- connection string: "localhost"
- docker stop redisDev
- docker rm redisDev
- dokcer rmi redis

have a distributed cache set up in Program.cs
``` c#
builder.Services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = builder.Configuration.GetConnectionString("Redis");
            options.InstanceName = "test";
        });
```
, you should be fine. Here's the page on hub.docker.com that shows the Redis Docker container. It's an official image and has more than a billion downloads. To pull this image locally, we can use the docker pull command shown here at the top of the page. In a terminal, I'll do exactly that. Docker pull redis, and the image pulls down just fine. This means that I have a Redis container on my machine, and now to use it, we need to run it. The run command is docker run. We'll use ‑d to run it in detached mode, and I'll give the running image a name of redisDev, and we need to make sure to map the local port of 6379 to the container port of 6379 so that we can access the cache from our ASP.NET Core app, which is running on our local machine. And the image we want to run is the Redis image that we just pulled. That's it. And we should have a Redis instance running on our machine now. Pretty awesome stuff. Now let's get it plugged into our Program.cs file. There's where we added the memory cache, so let's put the distributed cache in about the same place. To use Redis as a distributed cache, we can use the NuGet package called Microsoft.Extensions.Caching.StackExchangeRedis. With that NuGet package installed, we can use the AddStackExchangeRedisCache extension method. We need to provide some options, and we'll provide the configuration, which is a connection string, and I'll call for a connection string from our app configuration called Redis. We'll add that in just a sec. And then we can specify a name for our cache. I'll just call it CarvedRock. Now in our appsettings file we can add the connection string for the cache. We set up Redis on our local machine, and we provided a port mapping of 6379‑6379 in our container. So the connection string is simply localhost. Couldn't get any easier than that. If you're using a different type of distributed cache, it's just a matter of making sure you've got a few lines in Program.cs that will give an instance of an IDistributedCache to the dependency injection engine. That should do the trick, so let's set a breakpoint if we hit our Thread.Sleep line. We'll only hit this if we don't get a cache hit, and then we'll get data from the database and store it in the cache before returning it. If we get a cache hit, we'll deserialize it using the logic there on line 76 and return that. Once again, note that the application itself should behave functionally exactly the same as we've seen before. We're just using a distributed cache now, and the code has gotten still more complicated. But I'll hit the Footwear link now that it's running, and then I need to log in this time, since I don't have an open browser. And then we hit our breakpoint. This is good and expected, since we don't have any cached data yet. I'll continue, and our page loads just like we'd expect it to. I'll hit the Clothing link to get away from the Footwear page, and that throws the exception that we've seen a couple of times now. And if I now hit the Footwear link, the page loads nice and quickly, and we didn't hit our breakpoint. This is great and means both are distributed cache and the serialization logic we're using are both working just fine. Now I want to look a little closer at the problems with cache invalidation and how we can address them since we're using a distributed cache.

#### ## Installing and running Node.js Redis CLI
[ref](https://redis.com/blog/get-redis-cli-without-installing-redis-server/)

Once you’ve installed Node.js and [npm](https://www.npmjs.com/), it’s a simple one-liner to get and install the Node.js version of redis-cli:
	npm install -g redis-cli

Then you can run it with the command:
	rdcli -h your.redis.host -a yourredispassword -p 11111


I actually run by 
```
	rdcli
```
and it gives this prompt:
```
127.0.0.1:6379>
```
and I am able to see the keys by
```
keys *
```