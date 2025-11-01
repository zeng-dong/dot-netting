
# HTTP Client in C#: Best Practices for Experts
Jan 17, 2025

## naive
In case you have a web server that implements RESTful-API, you can send a `GET` request and parse JSON response in a few lines:

```c#
var builder = WebApplication.CreateBuilder(args);  
  
var app = builder.Build();  
  
app.MapGet("/", async () =>  
{  
    // magic happens here  
    HttpClient client = new HttpClient();  
    GetQuotesResponse response = await client.GetFromJsonAsync<GetQuotesResponse>("https://dummyjson.com/quotes");  
  
    return response;  
});  
  
app.Run();

```


In C#, working with `HttpClient` requires understanding how to create it correctly, implementing middleware, ensuring resilience, handling retries, using circuit-breaker, and optimizing request execution.

## Create HTTP client

You need to know how to create `HttpClient` properly before using it. There are a few options, with its own pros and cons:

- Constructor
- Static Instance
- `IHttpClientFactory`
- Named Clients
- Typed Clients
- Generated Clients *

### Constructor

The simplest way to work with the `HttpClient` is just to create a new instance and dispose it in the end.
```c#
app.MapGet("/", () =>  
{  
    HttpClient client = new HttpClient();  
    client.Dispose();  
});
```


However, `HttpClient` is a bit special, and is not disposed properly 🤪.

With each `HttpClient` instance a new HTTP connection is created. But even when the client is disposed, the TCP socket is not immediately released. If your application constantly creates new connections, it can lead to [**the exhaustion** of available **ports**](https://www.aspnetmonsters.com/2016/08/2016-08-27-httpclientwrong/)**.**

Therefore, `HttpClient` is intended to be instantiated _once per application_, rather than per-use.

### Static Instance

A bit better approach is to create _one_ `HttpClient` and reuse it.
```c#
static readonly HttpClient client = new HttpClient();    
app.MapGet("/", async () =>  
{  
    var response = await client.GetAsync("https://dummyjson.com/quotes");  
});
```

However, there is still an issue with **DNS changes**.

`HttpClient` only resolves [DNS](https://medium.com/@iamprovidence/the-internet-f0db9375ee62#acb4) entries when a connection is created. If DNS entries change regularly, the client won’t respect those updates.

You can set a connection lifetime, so it is recreated from time to time:
```c#
var handler = new SocketsHttpHandler  
{  
    // recreate every 2 minutes  
    PooledConnectionLifetime = TimeSpan.FromMinutes(2)   
};  
var sharedClient = new HttpClient(handler);
```


### IHttpClientFactory

While `static` instance is great, it is often hard to mock in [unit tests](https://medium.com/@iamprovidence/unit-tests-018611590eac) 😒.

It is recommended to use an `IHttpClientFactory` to create the `HttpClient` instance.
```c#
var builder = WebApplication.CreateBuilder(args);  
builder.Services.AddHttpClient(); // 👈 register a factory  
  
var app = builder.Build();  
  
app.MapGet("/quotes", async ([FromServices] IHttpClientFactory factory) =>  
{  
    var client = factory.CreateClient(); // 👈 resolve a client  
    var response = await client.GetFromJsonAsync<GetQuotesResponse>("https://dummyjson.com/quotes");  
  
    return response;  
});  
  
app.Run();
```

It will manage the `HttpClient` lifetime, properly reuse and dispose TCP sockets, handle DNS changes, and so on. This means you don’t need to explicitly call `.Dispose()` or `using`. Just make sure your `HttpClient` is short-lived.

### Named Clients

Factory is great, however, when the client is used in multiple places you can notice code duplication. The same [URL address](https://medium.com/@iamprovidence/the-internet-f0db9375ee62#6586), HTTP headers, [authorization token](https://medium.com/@iamprovidence/token-gang-bearer-token-reference-token-opaque-token-self-contained-token-jwt-access-token-6e0191093cd0), and so on can be reused across clients.

Instead of configuring them for each client, you can use **named clients**:
```c#
var builder = WebApplication.CreateBuilder(args);  
builder  
    .Services  
    .AddHttpClient("DummyJson", configureClient => // 👈 configure a client  
    {  
        configureClient.BaseAddress = new Uri("https://dummyjson.com");  
  
        configureClient.DefaultRequestHeaders.Add(HeaderNames.Accept, MediaTypeNames.Application.Json);  
        // configureClient.DefaultRequestHeaders.Accept.Add(MediaTypeNames.Application.Json);  
          
        configureClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "your-token-here");  
    });  
  
var app = builder.Build();  
  
app.MapGet("/", async ([FromServices] IHttpClientFactory factory) =>  
{  
    var client = factory.CreateClient(name: "DummyJson"); // 👈 resolve the client by name  
    var response = await client.GetFromJsonAsync<GetQuotesResponse>("quotes");  
  
    return response;  
});  
  
app.Run();

```

Notice that this time, the client is resolved by its _registered name_.

### Typed Clients

There are still some improvements we would like to make:

- instead of resolving clients by strings, we would like to inject them as other services through DI
- we want to encapsulate all logic in a single place, instead of scattering it around
- we need to ease code navigation

This can be done with a **typed client**. It is just a simple class, that inject `HttpClient` in its constructor:

```c#
class DummyJsonHttpClient  
{  
    private readonly HttpClient _httpClient;  
  
    public DummyJsonHttpClient(HttpClient httpClient)  
    {  
        _httpClient = httpClient;  
  
        _httpClient.BaseAddress = new Uri("https://dummyjson.com");  
    }  
  
    public Task<GetQuotesResponse> GetQuotes()  
    {  
        return _httpClient.GetFromJsonAsync<GetQuotesResponse>("quotes");  
    }  
}

////Later, this class has to be registered with `.AddHttpClient<T>()`:

var builder = WebApplication.CreateBuilder(args);  
builder  
    .Services  
    .AddHttpClient<DummyJsonHttpClient>(); // 👈 register a client  
  
var app = builder.Build();  
  
app.MapGet("/", async ([FromServices] DummyJsonHttpClient apiClient) => // 👈 resolve the client  
{  
    var response = await apiClient.GetQuotes();  
  
    return response;  
});  
  
app.Run();
```

Notice:
- you can write additional custom logic in the typed clients, like exception handling, request [tracing](https://medium.com/@iamprovidence/step-by-step-guide-to-logs-in-c-best-practices-and-tips-491c8d555d26), and so on
- typed client can inherit an [interface](https://medium.com/@iamprovidence/the-actual-reason-behind-interfaces-9c5aac26eb54), to ease mocking in the [unit tests](https://medium.com/@iamprovidence/unit-tests-018611590eac)

```c#
interface IDummyJsonHttpClient  
{  
    Task<GetQuotesResponse> GetQuotes();  
}  
  
class DummyJsonHttpClient: IDummyJsonHttpClient { . . . } // 👈 inheritance  
  
builder  
    .Services  
    .AddHttpClient<IDummyJsonHttpClient, DummyJsonHttpClient>(); // 👈 register the client


```

- you can set the configuration during client registration in the DI (which is more preferable)

```c#
builder  
    .Services  
    .AddHttpClient<DummyJsonHttpClient>(x =>  
    {  
        x.BaseAddress = new Uri("https://dummyjson.com");  
    })
```

- typed clients are also registered _by name_ and can be resolved in the same way
```c#
// resolves configured HttpClient from the DI  
HttpClient typedClient = clientFactory.CreateClient(nameof(DummyJsonHttpClient));

//This way we can obtain the configured `HttpClient`.

//- typed clients can also be resolved with typed factory

app.MapGet("/", async (  
    [FromServices] IHttpClientFactory clientFactory,  
    [FromServices] ITypedHttpClientFactory<DummyJsonHttpClient> typedHttpClientFactory) =>  
{  
    // get configured HttpClient from the DI  
    HttpClient httpClient = clientFactory.CreateClient(nameof(DummyJsonHttpClient));  
      
    // type-safe client  
    // calls constructor of DummyJsonHttpClient  
    DummyJsonHttpClient typedClient = typedHttpClientFactory.CreateClient(httpClient);  
}
```


This time we resolve `DummyJsonHttpClient` and not just its underlying `HttpClient`.

- typed clients are registered with **transient lifetime**
- if you inject a _transient_ typed client into a **singleton service,** it will become _singleton_ and won’t be properly disposed. Therefore you should use the factory in this case

### Generated Clients *

This is not officially supported, but there is one cool NuGet you should be aware of. It is called [Refit](https://github.com/reactiveui/refit).

It allows you to declare an `interface` and it will generate a typed `HttpClient`.
```c#
interface IDummyJsonHttpClient  
{  
    [Get("/quotes")]  
    Task<GetQuotesResponse> GetQuotes();  
}
```

The interface, of course, needs to be registered before the usage:
```c#
var builder = WebApplication.CreateBuilder(args);  
builder  
    .Services  
    .AddRefitClient<IDummyJsonHttpClient>() // 👈 register a client  
    .ConfigureHttpClient(c =>               // 👈 add additional configurations  
    {  
        c.BaseAddress = new Uri("https://dummyjson.com");  
    });  
  
var app = builder.Build();  
  
app.MapGet("/", async ([FromServices] IDummyJsonHttpClient apiClient) =>  
{  
    var response = await apiClient.GetQuotes();    
    return response;  
});  
  
app.Run();
```

What can I say? It simplifies client creation and looks cool 🙃.

However, there are some problems I see with this NuGet:

- it is an additional dependency, your developers' team should learn
- it is harder to add custom logic to your HTTP client
- usually, you have a pair of abstraction and implementation (`IDummyJsonApiClient`, `DummyJsonHttpClient`). In case the underlying connection layer changes, you only need to update the implementation, keeping all places using abstraction the same. With Refit you have an interface (`IDummyJsonHttpClient`), but this is not an abstraction. You are tightly coupled to the HTTP communication
- from the [architectural](https://medium.com/@iamprovidence/backend-side-architecture-evolution-n-layered-ddd-hexagon-onion-clean-architecture-643d72444ce4) point of view, it is not clear where to place `IDummyJsonHttpClient`. Is it part of the Application layer or the Infrastructure one?

As always, the final choice is yours. Still, I felt, I had to mention it 😬.

## Middleware

Typed clients are excellent because they allow you to encapsulate error handling, [logging](https://medium.com/@iamprovidence/step-by-step-guide-to-logs-in-c-best-practices-and-tips-491c8d555d26), [caching](https://medium.com/@iamprovidence/master-cache-in-c-307b01dc8f84), or any custom logic in a single, reusable component.

However, there is another technique to reuse [cross-cutting concerns](https://medium.com/@iamprovidence/aspect-oriented-programming-91bc43929dc8) across different `HttpClients` and make them neat.

For example, for every [HTTP](https://medium.com/@iamprovidence/the-internet-f0db9375ee62#9b29) call, you would like to get or refresh the [access token](https://medium.com/@iamprovidence/token-gang-bearer-token-reference-token-opaque-token-self-contained-token-jwt-access-token-6e0191093cd0) and log the time it took to execute the request.

It can be done with decorators. This way, you extend all methods with additional functionality that runs either before or after the original method call.

Press enter or click to view image in full size

![](https://miro.medium.com/v2/resize:fit:700/1*_HwDVSurM2RUrMcyn91vUg.png)

Simply add the corresponding `DelegatingHandler`:

public class PerformanceAuditorDelegatingHandler : DelegatingHandler  
{  
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)  
    {  
        Console.WriteLine($"Start {request.RequestUri} at {DateTime.UtcNow}");  
  
        // original call  
        var response = await base.SendAsync(request, cancellationToken);  
  
        Console.WriteLine($"Finish {request.RequestUri} at {DateTime.UtcNow}");  
  
        return response;  
    }  
}

That later will be registered in the DI and added to the `HttpClient` request pipeline:

builder  
    .Services  
    .AddTransient<PerformanceAuditorDelegatingHandler>() // 👈  
    .AddHttpClient<DummyJsonHttpClient>()  
    .AddHttpMessageHandler<PerformanceAuditorDelegatingHandler>(); // 👈

By the way, you do not necessarily have to enrich original calls. You can simply block or override all requests, which is often useful in [integration tests](https://medium.com/@iamprovidence/9c71f5cc5fcd).

public class RequestBlockingDelegatingHandler : DelegatingHandler  
{  
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)  
    {  
        var response = new  
        {  
            Status = "Blocked",  
        };  
  
        return new HttpResponseMessage()  
        {  
            StatusCode = HttpStatusCode.OK,  
            Content = JsonContent.Create(response),  
        };  
    }  
}

### Delegating Handler Lifetime *

Another section with the asterisk. You can skip it since it is only for professionals 😁.

You might notice that the handler is registered as **_transient_**, yet it won’t be recreated for each request, which is unusual. You can clearly see that by adding a state, that will be persisted for some time.

public class StatefulDelegatingHandler : DelegatingHandler  
{  
    public int i = 0; // state will be persited  
        
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)  
    {  
        i++;         
  
        return await base.SendAsync(request, cancellationToken);  
    }  
}

Let’s try to understand what is going on.

Each time the request is made, it goes through a pipeline of multiple `DelegatingHandlers`.

It would be inefficient to recreate the pipeline on every call, therefore handlers are created when `HttpClient` is resolved and temporarily stored in a cache, for **2 minutes**.

Press enter or click to view image in full size

![](https://miro.medium.com/v2/resize:fit:700/1*ksoTwZayXDgyTlRcKoNgCg.png)

You can change handlers lifetime if needed:

builder  
    .Services  
    .AddTransient<StatefulDelegatingHandler>()  
    .AddHttpClient<DummyJsonHttpClient>()  
    .AddHttpMessageHandler<StatefulDelegatingHandler>()  
    .SetHandlerLifetime(TimeSpan.FromSeconds(30)); // 👈

This allows a _transient_ handler to live a bit longer and persist a state. Great!

Now, some developers may have a temptation to change its lifecycle to be a `singleton`:

builder  
    .Services  
    .AddSingleton<StatefulDelegatingHandler>() // 👈  
    .AddHttpClient<DummyJsonHttpClient>()  
    .AddHttpMessageHandler<StatefulDelegatingHandler>();

This will result in `InvalidOperationException`. Lame 😒.

Each handler references the next one in the pipeline through the `InnerHandler` property. If a `DelegatingHandler` is registered as a singleton, the `InnerHandler` property will remain set causing the exception during pipeline creation.

Summing Up:

- `DelegatingHandler` must be registered as a **transient**
- even though it is transient, it will be cached and reused for 2 minutes
- you can have a state in your handler that will be persisted for a short period (but it is better not to, since it will just cause bugs)
- be aware of this behavior when you inject services with state in a handler
- you can change the handlers' lifetime
- set the lifetime to `Timeout.InfiniteTimeSpan` to disable handler expiry
- pooling of handlers is desirable as each handler typically manages its own underlying HTTP connections

## Making HttpClient resilient

Did you think that learning how to create an `HttpClient` is all you need to start using it? Oh silly you are 😌. Network communication is unreliable, therefore you need to make your `HttpClient` resilient.

> **_Resiliency_** _refers to the ability of an application to continue functioning correctly even in the face of failures_

When you have one service calling another, there are multiple issues you can encounter:

- the request may take too long
- the request may fail
- the server may be slow or not available at all
- etc

Press enter or click to view image in full size

![](https://miro.medium.com/v2/resize:fit:700/1*gIp5kW0sWObnb7XCRNyLfA.png)

Therefore, you should learn about:

- request timeout
- retries
- circuit-breaker

There is another popular NuGet, called `[Polly](https://github.com/App-vNext/Polly)`, which allows you to write resilient code in a fluent manner:

var pipeline = new ResiliencePipelineBuilder()  
    .AddTimeout(TimeSpan.FromSeconds(10))  
    .Build();  
  
await pipeline.ExecuteAsync(() =>   
{   
    // your algorithm goes here   
});

Microsoft saw how good it is, and decided to use `Polly` in their own NuGet (`Microsoft.Extensions.Http.Resilient)` that adds resiliency to `HttpClient`.

Let’s see it in practice.

## Request Timeout

When a user clicks a button, he does not care whether you are performing complex computations or calling an external service. The user just expects to see a response right away.

However, when an external service is overloaded and the request takes too long, it will cause slowness in your application.

Press enter or click to view image in full size

![](https://miro.medium.com/v2/resize:fit:700/1*yv9JL9kMX3f4_CozJchwNg.png)

Therefore you should set a timeout of how long you can wait for the response:

builder  
    .Services  
    .AddHttpClient<DummyJsonHttpClient>()  
    .AddResilienceHandler("default", configure =>  
    {  
        configure.AddTimeout(TimeSpan.FromSeconds(2)); // 👈  
    });

If the request takes longer, it will be aborted and considered as a failed one.

## Retries

We can face another issue. The response is returned in an acceptable interval, however, it failed with an error.

Press enter or click to view image in full size

![](https://miro.medium.com/v2/resize:fit:700/1*YjiaCOn4c809cKxJO7EAaw.png)

In that case, it is worth try sending the same request again.

## Get iamprovidence’s stories in your inbox

Join Medium for free to get updates from this writer.

With retries you need to consider the following factors:

- which status codes should be retried
- number of retries
- interval between retries
- idempotency

### Status code to retry

[HTTP’s status code](https://medium.com/@iamprovidence/the-internet-f0db9375ee62#877a) indicates the result of the request, whether it was successful or encountered an error. The codes are grouped into five categories based on their first digit:

![](https://miro.medium.com/v2/resize:fit:510/1*w8Spo5qzPkGPtX9TNgboyA.png)

And only `**4XX**` and `**5XX**` groups indicate an error.

It is important to understand which codes should be retried.

If the request is returned with _client error_ (`**4XX**`), it means that it was poorly formed. Parameters are invalid, the authorization token is missing, the validation failed, and so on. Retrying such a request will likely result in the same error.

Therefore you should not retry the `**4XX**` group. But there are exceptions:

- `**408 Request Timeout**`**.** This status code indicates that the server did not complete the request within the expected time. Retrying after a reasonable delay might help
- `**429 Too Many Requests**`**.** If you encounter this status code, it means you’re making too many requests in a given time frame. Retrying after some period can help avoid hitting rate limits

On the other hand, _server errors_ (`**5XX**`**),** typically means temporary issues that will be resolved on a retry (except `**503 Service Unavailable**` 😅).

In practice, you don’t have to think about which status codes to retry, because Microsoft already implemented that 🙏:

builder  
    .Services  
    .AddHttpClient<DummyJsonHttpClient>()  
    .AddResilienceHandler("default", configure =>  
    {  
        configure.AddTimeout(TimeSpan.FromSeconds(2));  
  
        configure.AddRetry(new HttpRetryStrategyOptions()); // 👈  
    });

### **Number of retries**

It’s often a good practice to set a limit on the number of retry attempts to prevent infinite retry loops in case of persistent failures.

builder  
    .Services  
    .AddHttpClient<DummyJsonHttpClient>()  
    .AddResilienceHandler("default", configure =>  
    {  
        configure.AddTimeout(TimeSpan.FromSeconds(2));  
  
        configure.AddRetry(new HttpRetryStrategyOptions  
        {  
            MaxRetryAttempts = 3, // 👈  
        });  
    });

Of course, in case you are integrating with a third party, you should take into account the number of requests you send, the rate limits it imposes, and the potential impact on performance and _costs_.

### Retries interval

We agreed on a number of retry attempts. It is also important to choose a delay between retries.

Each retry can happen after a **constant** timeout, let’s say `20ms`.

Press enter or click to view image in full size

![](https://miro.medium.com/v2/resize:fit:700/1*tEiKK1pwxLsWwZS_A3z_4g.png)

This can be easily set in our retry policy:

builder  
    .Services  
    .AddHttpClient<DummyJsonHttpClient>()  
    .AddResilienceHandler("default", configure =>  
    {  
        configure.AddTimeout(TimeSpan.FromSeconds(2));  
  
        configure.AddRetry(new HttpRetryStrategyOptions  
        {  
            MaxRetryAttempts = 3,  
            BackoffType = DelayBackoffType.Constant, // 👈  
            Delay = TimeSpan.FromMilliseconds(20),   // 👈  
        });  
    });

It is simple, but not very effective.

If the server returns an error, retrying after a short delay can help quickly obtain a response from the server.

However, if you fail on a second attempt, on the third one, it usually means the server is overloaded, and spamming it with more requests just worsens the situation.

So, if the client “sees” that the server is unavailable, but it desperately needs a response, it is better to wait for a longer period.

It is recommended to increase the delay between each retry **linearly** or **exponentially**. This way you wait `20ms`, then `40ms`, then `80ms`, and so on.

Press enter or click to view image in full size

![](https://miro.medium.com/v2/resize:fit:700/1*rGbzQy5Sr7xIemgPCBFqCQ.png)

Let’s adjust our strategy a bit:

builder  
    .Services  
    .AddHttpClient<DummyJsonHttpClient>()  
    .AddResilienceHandler("default", configure =>  
    {  
        configure.AddTimeout(TimeSpan.FromSeconds(2));  
  
        configure.AddRetry(new HttpRetryStrategyOptions  
        {  
            MaxRetryAttempts = 3,  
            BackoffType = DelayBackoffType.Linear, // 👈  
            Delay = TimeSpan.FromMilliseconds(20),   
        });  
    });

Even though this strategy is a bit better, it still has some drawbacks.

Picture this: your server goes down entirely. Multiple `HttpClients` begin retrying their requests, and these retries align in time, generating peak load moments on the already overwhelmed server. This can potentially lead to a self-[DDoS](https://medium.com/@iamprovidence/avoid-those-vulnerabilities-ddos-sql-injection-open-redirect-xss-csrf-clickjacking-0d5de7c74569#1340) attack.

Press enter or click to view image in full size

![](https://miro.medium.com/v2/resize:fit:700/1*f0lpuieJSJ7lHeNWeNtXww.png)

You need to add a random delay to each retry, also known as **_jitter_**.

builder  
    .Services  
    .AddHttpClient<DummyJsonHttpClient>()  
    .AddResilienceHandler("default", configure =>  
    {  
        configure.AddTimeout(TimeSpan.FromSeconds(2));  
  
        configure.AddRetry(new HttpRetryStrategyOptions  
        {  
            MaxRetryAttempts = 3,  
            BackoffType = DelayBackoffType.Linear,  
            Delay = TimeSpan.FromMilliseconds(20),  
            UseJitter = true, // 👈  
        });  
    });

### Idempotency

When implementing retries you should remember that some [HTTP methods](https://medium.com/@iamprovidence/the-internet-f0db9375ee62#0a57) may have side effects.

According to REST, you can classify any operation as Create, Read, Update, or Delete (CRUD).

Press enter or click to view image in full size

![](https://miro.medium.com/v2/resize:fit:700/1*tj6OK-DwIXolbTLMY-UEwg.png)

Let’s say we receive `**408 Request Timeout**` from a server**.** This does not mean that the request was not handled. It just indicates that we no longer wait for a response.

As expected our client will do the retry. The behavior will be different depending on the operation:

- `**DELETE**` — on the first attempt, the server will delete the resource, and on the second retry, there will be nothing to delete, so the retry should not harm our server
- `**PUT**`— generally, the update operation is not harmful. For example, if you send the same data multiple times, the server should overwrite the resource with identical values
- `**GET**` — it does not matter, how many times you retrieve the data as fetch is a read-only, side-effect-free operation
- `**POST**` — retrying the request responsible for creation could result in duplicate entries 😖

Therefore, the server should ensure idempotency.

> **_Idempotency_** _is a property of an operation, which guarantees that performing the operation multiple times will yield the same result as if it was executed only once_

Or in plain English, if you have an API endpoint to pay for an order and unpetient users click 10 times, only 1 payment will be charged.

Typically, clients should include a `requestId` with each request, enabling the server to maintain a record of processed requests:

static List<string> HandledRequests = new List<string>();  
  
                      .   .   .  
  
[HttpPost]  
public void CreateNewUser(string userName, string requestId)  
{  
    // Check if the request has already been processed  
    var isAlreadyProcessed = HandledRequests.Contains(requestId);  
    if (isAlreadyProcessed)  
    {  
        return;  
    }  
  
    // Mark the requestId as processed  
    HandledRequests.Add(requestId);  
  
    // Your logic for creating a new user  
}

We won’t discuss idempotency in detail here. It is another big topic that deserves its own article 🙃. Just remember, that if your server does not implement idempotency (which is often the case with third-party apps), retries can cause more issues than solve.

## Circuit-Breaker

So, we have timeout and retries. Still, there is another known problem.

Let’s say our server is overwhelmed with requests and it takes time to respond.

Sure, we have a timeout, however, during the waiting period, _the client_ continues sending requests and also runs out of resources, such as [memory](https://medium.com/@iamprovidence/inside-the-pc-1b7e4371c531#a5f8), TCP connections, available [threads](https://medium.com/@iamprovidence/all-you-need-to-know-about-task-in-c-2dce9e52c0f7), and so on.

Over time, _the client_ will deplete its resources and also fail.

Press enter or click to view image in full size

![](https://miro.medium.com/v2/resize:fit:700/1*Kf4_-D2aeKHGLCb20M1THQ.png)

Sometimes it is better to fail fast instead of trying to send requests that will allocate the client’s resources and fail anyway.

It is solved with the **Circuit-Breaker pattern**. The idea is as follows:

- we add a proxy that will gather the statistics about the number of failed requests

Press enter or click to view image in full size

![](https://miro.medium.com/v2/resize:fit:700/1*jinubIBKIWxbC3cN2HBMHw.png)

- if at some point we realize that the server has stopped responding, we should _stop all requests_ for a while. This is known as **_open-state_**

Press enter or click to view image in full size

![](https://miro.medium.com/v2/resize:fit:700/1*GPw6CQpJp9sjwdHZ1aHWgw.png)

- from time to time, our proxy goes to a **_half-open state_**. It allows some requests through just to verify whether the server has recovered or not

Press enter or click to view image in full size

![](https://miro.medium.com/v2/resize:fit:700/1*3R4-wiR4YM2khydOiB6V4w.png)

- in case, the server starts responding at a reasonable rate, we can get back to the **_close state_** when there is no gap in the connection line

Press enter or click to view image in full size

![](https://miro.medium.com/v2/resize:fit:700/1*MXNfE3xDZTUmwHFGDql1gw.png)

The good news here is that we don’t need to implement Circuit-Breaker from scratch or add any proxy service here. As before, everything can be done with one configuration line 😁:

builder  
    .Services  
    .AddHttpClient<DummyJsonHttpClient>()  
    .AddResilienceHandler("default", configure =>  
    {  
        configure.AddTimeout(TimeSpan.FromSeconds(2));  
  
        configure.AddRetry(new HttpRetryStrategyOptions  
        {  
            MaxRetryAttempts = 3,  
            BackoffType = DelayBackoffType.Constant,  
            Delay = TimeSpan.FromMilliseconds(500),  
            UseJitter = true,  
        });  
  
        configure  
          .AddCircuitBreaker(new HttpCircuitBreakerStrategyOptions()); // 👈  
    });

You can tune parameters more granularly, depending on your needs, but I will leave it as is because I am lazy 🙃.

## Finishing The Resiliency Pipeline

As you can see, configuring the resiliency pipeline is complex. Microsoft also knows that it is quite easy to f#ck it up 😅. You can set policies in the wrong order, set invalid parameters, and so on. Therefore, they give us an extension method, that will register [standard policies](https://learn.microsoft.com/en-us/dotnet/core/resilience/http-resilience?tabs=dotnet-cli#standard-resilience-handler-defaults):

builder  
    .Services  
    .AddHttpClient<DummyJsonHttpClient>()  
    .AddStandardResilienceHandler(); // 👈

They look like this:

Press enter or click to view image in full size

![](https://miro.medium.com/v2/resize:fit:700/1*pxDLDe1bvbI9xQGq_RMuHQ.png)

Still, it is possible to tune some settings, if needed:

builder  
    .Services  
    .AddHttpClient<DummyJsonHttpClient>()  
    .AddStandardResilienceHandler()  
    .Configure(options =>  
    {  
        options.TotalRequestTimeout.Timeout = TimeSpan.FromSeconds(5);  
  
        options.Retry.MaxRetryAttempts = 5;  
  
        options.CircuitBreaker.FailureRatio = 0.9;  
        options.CircuitBreaker.BreakDuration = TimeSpan.FromSeconds(5);  
                        .  .  .  
    });

## Issuing HTTP Request

Finally, when all the configurations are done, we can send the HTTP requests 😌.

These days, you simply call the appropriate method (e.g., `.GetAsync()`, `.PostAsync()` ), specify the correct [URL](https://medium.com/@iamprovidence/the-internet-f0db9375ee62#6586), provide a body to be serialized into JSON, and deserialize the response.

var request = new  
{  
    Message = "Hello world",  
};  
    
var response = await client.PostAsJsonAsync("https://echo.free.beeceptor.com", request);  
  
var result = await response.Content.ReadFromJsonAsync<TestServerResult>();

This hasn’t always been the case. If you’re using a different serializer, such as `Newtonsoft.Json`, or working with legacy code, you might encounter something like this.

var request = new  
{  
    Message = "Hello world",  
};  
  
var serializedRequest = JsonSerializer.Serialize(request);  
  
var stringContent = new StringContent(serializedRequest, Encoding.UTF8, MediaTypeNames.Application.Json);  
  
var response = await _client.PostAsync("https://echo.free.beeceptor.com", stringContent);  
  
var stringResponse = await response.Content.ReadAsStringAsync(); // 👈  
  
var result = JsonSerializer.Deserialize<TestServerResult>(stringResponse);

In this example, we:

1. create a request object
2. serialize it to JSON
3. build an HTTP body using `StringContent`, setting the correct encoding and media type
4. send the HTTP request, where `HttpClient` waits for the entire response and writes it to an internal `MemoryStream` buffer
5. then, the response content is read as a `string`
6. finally, we deserialize that `string` to type-safe `object`

Developers often make a common mistake here at **step 5**. They read the entire response body as the `string`, deserialize it to JSON, and then never use that `string` again. This adds unnecessary performance overhead and allocates memory for an object that will eventually need to be cleaned up.

You can read and deserialize directly from the `MemoryStream`:

                            . . .  
  
var streamResponse = await response.Content.ReadAsStreamAsync();  
var result = await JsonSerializer.DeserializeAsync<TestServerResult>(streamResponse);

It is less convenient during debugging since you don’t see the received response, but is more performant.

However, `[MemoryStream](https://medium.com/@iamprovidence/streams-8ea4b0c3cd92#e301)` is not a real [stream](https://medium.com/@iamprovidence/streams-8ea4b0c3cd92) 🙃. It holds the entire response body. It is basically `byte[]`. We can continue making improvements here.

Among those `.GetAsync()`, `.PostAsync()`, there is one generic method `.SendAsync()`.

public class HttpClient : IDisposable  
{  
              .  .  .       
  
    public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, HttpCompletionOption completionOption)  
  
              .  .  .  
}

It is interesting, because of the following reasons:

- you can send request of any type (e.g. `GET`, `POST`, `DELETE`, …)
- its second parameter is `HttpCompletionOption`

`HttpCompletionOption` is just an enum with two options that determine response behavior:

public enum HttpCompletionOption  
{  
    ResponseContentRead = 0,  
    ResponseHeadersRead = 1  
}

- `ResponseContentRead` (default)— reads the entire response payload into the buffer
- `ResponseHeadersRead` — as soon as headers are read, you can read the response’s body in chunks as a stream 😌

var request = new  
{  
    Message = "Hello world",  
};  
  
var jsonContent = JsonContent.Create(request); // 👈 notice, JsonContent instead of StringContent  
  
var requestMessage = new HttpRequestMessage()  
{  
    Method = HttpMethod.Post,  
    Content = jsonContent,  
    RequestUri = new Uri("https://echo.free.beeceptor.com"),  
};  
  
var response = await client.SendAsync(  
  requestMessage,   
  HttpCompletionOption.ResponseHeadersRead // 👈  
);  
  
var streamResponse = await response.Content.ReadAsStreamAsync(); // ChunkedEncodingReadStream instead of MemoryStream 😌   
  
var result = await JsonSerializer.DeserializeAsync<TestServerResult>(streamResponse);

This means that we are going to use less memory and will process data faster since we don’t have to keep the entire content in the buffer.

By the way, before consuming the stream, you still can investigate the response and its headers:

                            .  .  .  
var response = await client.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead);  
    
response.EnsureSuccessStatusCode();  
  
if ((int)response.StatusCode > 400)  
{  
    // custom error handling logic  
}

## Canceling Request

With all those `await` operators, you may have a temptation to stick a `[CancellationToken](https://medium.com/@iamprovidence/advanced-stuff-about-task-they-dont-tell-you-619ccb4784df#f7c9)` there 😁:

var response = await _client.PostAsync("https://echo.free.beeceptor.com", stringContent, cancellationToken);  
  
var streamResponse = await response.Content.ReadAsStreamAsync(cancellationToken);

While it may seem like a performance saver at first, cancellation is only recommended alongside `GET` operation.

As soon as you have `POST`, `PUT`, `DELETE`, etc, if the server begins processing a request but does not implement transactions, canceling the request might leave the server in an inconsistent state.

Moreover, ensuring transactional behavior across multiple HTTP calls is challenging for the client application too.

If your algorithm spams multiple HTTP requests, do not forget to define a compensating action to reverse it if needed (e.g., refunding a payment if an order creation fails).

try  
{  
    await httpClient.PostAsync("https://service1.com/operation", content1);  
    await httpClient.PostAsync("https://service2.com/operation", content2);  
}  
catch (Exception)  
{  
    await httpClient.PostAsync("https://service1.com/rollback", rollbackContent1);  
    throw;  
}

Remember, you can implement transactional-like behavior by employing strategies that ensure consistency, like [Outbox pattern](https://medium.com/@iamprovidence/outbox-pattern-01f773451f0f), [Saga](https://medium.com/@iamprovidence/microservices-376bb3f553b7#ad20), compensation actions, two-phase commit, and so on.

## Last Words

As you can see, working with something as simple as `HttpClient` requires advanced skills and knowledge 😤.

🐞 When you instantiate a new instance, you should remember about [**port**](https://medium.com/@iamprovidence/the-internet-f0db9375ee62#9279) **exhaustion** and [**DNS**](https://medium.com/@iamprovidence/the-internet-f0db9375ee62#acb4) **change** problems**.**

🏭 It is preferable to use typed clients, however, in case, the dependency injection scope is not aligned with transient `HttpClient` you can use a factory or a static client.

🔗 You can leverage the middleware chain to handle cross-cutting concerns like logging, authentication, or retries.

🦾 Resiliency policies are useful, but you should ask yourself:

- what is better for my application: to fail fast or to retry?
- can I retry, or will it hit the API limit?
- what errors and status codes to retry?
- does the server support idempotency?
- would retry cause a DDoS attack?
- do I need a circuit-breaker, or will it make my system more unstable?

⚠️ This is especially **important** when integrating with **_third-party_** services, as you don’t have access to their code, and they are often limited in those regards.

⚡️ Avoid reading the response body as a `string` to improve performance. If performance is critical, consider using streams, but make sure you understand how they work 😉.

✖️ Before canceling HTTP requests, ensure, that servers properly handle client disconnections or cancellations or provide compensating actions (this is important with third-party apps where you cannot easily recover in case of failure).

Consider all those factors, to make the best `HttpClient` in the world 😁:

Press enter or click to view image in full size

![](https://miro.medium.com/v2/resize:fit:700/1*9Tv7al0QElTETkOSiTaBRQ.png)

💬 Let me know if you've ever encountered a port exhaustion issue, or if it's just a horror story that senior developers tell to scare juniors

👏 I hope you find this article enjoyable. If so, clap, clap, clap

☕️ You can buy me a coffee with the link below

✅ And don’t forget to follow if you want to deep your C# knowledge

[

Https

](https://medium.com/tag/https?source=post_page-----840b36d8f8c4---------------------------------------)

[

Csharp

](https://medium.com/tag/csharp?source=post_page-----840b36d8f8c4---------------------------------------)

[

Programming

](https://medium.com/tag/programming?source=post_page-----840b36d8f8c4---------------------------------------)

[

Software Development

](https://medium.com/tag/software-development?source=post_page-----840b36d8f8c4---------------------------------------)

[](https://medium.com/m/signin?actionUrl=https%3A%2F%2Fmedium.com%2F_%2Fbookmark%2Fp%2F840b36d8f8c4&operation=register&redirect=https%3A%2F%2Fmedium.com%2F%40iamprovidence%2Fhttp-client-in-c-best-practices-for-experts-840b36d8f8c4&source=---footer_actions--840b36d8f8c4---------------------bookmark_footer------------------)

[

![iamprovidence](https://miro.medium.com/v2/resize:fill:48:48/1*5_4tdBAsyyi0qA4XgMD1xA.png)



](https://medium.com/@iamprovidence?source=post_page---post_author_info--840b36d8f8c4---------------------------------------)

[

## Written by iamprovidence

](https://medium.com/@iamprovidence?source=post_page---post_author_info--840b36d8f8c4---------------------------------------)

[2.2K followers](https://medium.com/@iamprovidence/followers?source=post_page---post_author_info--840b36d8f8c4---------------------------------------)

·[0 following](https://medium.com/@iamprovidence/following?source=post_page---post_author_info--840b36d8f8c4---------------------------------------)

👨🏼‍💻 Full Stack Dev writing about software architecture, patterns and other programming stuff [https://www.buymeacoffee.com/iamprovidence](https://www.buymeacoffee.com/iamprovidence)

## Responses (11)

[](https://policy.medium.com/medium-rules-30e5502c4eb4?source=post_page---post_responses--840b36d8f8c4---------------------------------------)

![](https://miro.medium.com/v2/resize:fill:32:32/1*dmbNkD5D-u45r44go_cf0g.png)

Write a response

[

What are your thoughts?



](https://medium.com/m/signin?operation=register&redirect=https%3A%2F%2Fmedium.com%2F%40iamprovidence%2Fhttp-client-in-c-best-practices-for-experts-840b36d8f8c4&source=---post_responses--840b36d8f8c4---------------------respond_sidebar------------------)

[

![Alex Lo](https://miro.medium.com/v2/resize:fill:32:32/1*dmbNkD5D-u45r44go_cf0g.png)





](https://medium.com/@alexl_alexl?source=post_page---post_responses--840b36d8f8c4----0-----------------------------------)

[

Alex Lo



](https://medium.com/@alexl_alexl?source=post_page---post_responses--840b36d8f8c4----0-----------------------------------)

[

Jan 19

](https://medium.com/@alexl_alexl/what-about-the-cancellation-tokens-i-believe-this-topic-deserves-at-least-one-paragraph-8daa116c8965?source=post_page---post_responses--840b36d8f8c4----0-----------------------------------)

What about the cancellation tokens? I believe this topic deserves at least one paragraph.

11

[

![Peter Felgate](https://miro.medium.com/v2/resize:fill:32:32/1*dmbNkD5D-u45r44go_cf0g.png)



](https://medium.com/@peter.felgate?source=post_page---post_responses--840b36d8f8c4----1-----------------------------------)

[

Peter Felgate



](https://medium.com/@peter.felgate?source=post_page---post_responses--840b36d8f8c4----1-----------------------------------)

[

Jan 25

](https://medium.com/@peter.felgate/the-best-article-ive-read-on-this-subject-nice-one-10fb65f89c3b?source=post_page---post_responses--840b36d8f8c4----1-----------------------------------)

The best article I've read on this subject! Nice one 🙂

7

[

![Michal Panfil](https://miro.medium.com/v2/resize:fill:32:32/0*bVf7XBRbzU-fEJCD)





](https://medium.com/@it.panfil?source=post_page---post_responses--840b36d8f8c4----2-----------------------------------)

[

Michal Panfil



](https://medium.com/@it.panfil?source=post_page---post_responses--840b36d8f8c4----2-----------------------------------)

[

Mar 27

](https://medium.com/@it.panfil/good-job-man-nice-article-cb0a02309331?source=post_page---post_responses--840b36d8f8c4----2-----------------------------------)

good job man , nice article

5

## More from iamprovidence

![Step-by-Step Guide to Logs in C#: Best Practices and Tips](https://miro.medium.com/v2/resize:fit:679/format:webp/1*g-V8GBX8dwNuNxBO80DROA.jpeg)

[

![iamprovidence](https://miro.medium.com/v2/resize:fill:20:20/1*5_4tdBAsyyi0qA4XgMD1xA.png)



](https://medium.com/@iamprovidence?source=post_page---author_recirc--840b36d8f8c4----0---------------------f12095ca_1e89_4095_a674_8ab8c9a15b12--------------)

[

iamprovidence

](https://medium.com/@iamprovidence?source=post_page---author_recirc--840b36d8f8c4----0---------------------f12095ca_1e89_4095_a674_8ab8c9a15b12--------------)

[

## Step-by-Step Guide to Logs in C#: Best Practices and Tips

### As you may guess from the title, we will talk about logs today.



](https://medium.com/@iamprovidence/step-by-step-guide-to-logs-in-c-best-practices-and-tips-491c8d555d26?source=post_page---author_recirc--840b36d8f8c4----0---------------------f12095ca_1e89_4095_a674_8ab8c9a15b12--------------)

Nov 17, 2024

[

](https://medium.com/@iamprovidence/step-by-step-guide-to-logs-in-c-best-practices-and-tips-491c8d555d26?source=post_page---author_recirc--840b36d8f8c4----0---------------------f12095ca_1e89_4095_a674_8ab8c9a15b12--------------)

[

120

](https://medium.com/@iamprovidence/step-by-step-guide-to-logs-in-c-best-practices-and-tips-491c8d555d26?source=post_page---author_recirc--840b36d8f8c4----0---------------------f12095ca_1e89_4095_a674_8ab8c9a15b12--------------)

[

4







](https://medium.com/@iamprovidence/step-by-step-guide-to-logs-in-c-best-practices-and-tips-491c8d555d26?source=post_page---author_recirc--840b36d8f8c4----0---------------------f12095ca_1e89_4095_a674_8ab8c9a15b12--------------)

[](https://medium.com/m/signin?actionUrl=https%3A%2F%2Fmedium.com%2F_%2Fbookmark%2Fp%2F491c8d555d26&operation=register&redirect=https%3A%2F%2Fmedium.com%2F%40iamprovidence%2Fstep-by-step-guide-to-logs-in-c-best-practices-and-tips-491c8d555d26&source=---author_recirc--840b36d8f8c4----0-----------------bookmark_preview----f12095ca_1e89_4095_a674_8ab8c9a15b12--------------)

![Architecture Tests](https://miro.medium.com/v2/resize:fit:679/format:webp/1*RTkjvNB2v5znfLA80mqezQ.png)

[

![iamprovidence](https://miro.medium.com/v2/resize:fill:20:20/1*5_4tdBAsyyi0qA4XgMD1xA.png)



](https://medium.com/@iamprovidence?source=post_page---author_recirc--840b36d8f8c4----1---------------------f12095ca_1e89_4095_a674_8ab8c9a15b12--------------)

[

iamprovidence

](https://medium.com/@iamprovidence?source=post_page---author_recirc--840b36d8f8c4----1---------------------f12095ca_1e89_4095_a674_8ab8c9a15b12--------------)

[

## Architecture Tests

### Architecture tests are an essential part of maintaining a healthy architecture. First time hearing? No worries, we will explore what those…



](https://medium.com/@iamprovidence/architecture-tests-878d76e4fd56?source=post_page---author_recirc--840b36d8f8c4----1---------------------f12095ca_1e89_4095_a674_8ab8c9a15b12--------------)

Sep 27

[

](https://medium.com/@iamprovidence/architecture-tests-878d76e4fd56?source=post_page---author_recirc--840b36d8f8c4----1---------------------f12095ca_1e89_4095_a674_8ab8c9a15b12--------------)

[

26







](https://medium.com/@iamprovidence/architecture-tests-878d76e4fd56?source=post_page---author_recirc--840b36d8f8c4----1---------------------f12095ca_1e89_4095_a674_8ab8c9a15b12--------------)

[](https://medium.com/m/signin?actionUrl=https%3A%2F%2Fmedium.com%2F_%2Fbookmark%2Fp%2F878d76e4fd56&operation=register&redirect=https%3A%2F%2Fmedium.com%2F%40iamprovidence%2Farchitecture-tests-878d76e4fd56&source=---author_recirc--840b36d8f8c4----1-----------------bookmark_preview----f12095ca_1e89_4095_a674_8ab8c9a15b12--------------)

![IOptions: The Backbone of App Configuration in C#](https://miro.medium.com/v2/resize:fit:679/format:webp/1*JQhIs80iRNMHM-UGEU_arg.png)

[

![iamprovidence](https://miro.medium.com/v2/resize:fill:20:20/1*5_4tdBAsyyi0qA4XgMD1xA.png)



](https://medium.com/@iamprovidence?source=post_page---author_recirc--840b36d8f8c4----2---------------------f12095ca_1e89_4095_a674_8ab8c9a15b12--------------)

[

iamprovidence

](https://medium.com/@iamprovidence?source=post_page---author_recirc--840b36d8f8c4----2---------------------f12095ca_1e89_4095_a674_8ab8c9a15b12--------------)

[

## IOptions: The Backbone of App Configuration in C#

### Working with configurations is an essential part of any ASP application. While you may have basic knowledge, for a professional developer…



](https://medium.com/@iamprovidence/ioptions-the-backbone-of-app-configuration-in-c-48b46a29f075?source=post_page---author_recirc--840b36d8f8c4----2---------------------f12095ca_1e89_4095_a674_8ab8c9a15b12--------------)

Dec 7, 2024

[

](https://medium.com/@iamprovidence/ioptions-the-backbone-of-app-configuration-in-c-48b46a29f075?source=post_page---author_recirc--840b36d8f8c4----2---------------------f12095ca_1e89_4095_a674_8ab8c9a15b12--------------)

[

137

](https://medium.com/@iamprovidence/ioptions-the-backbone-of-app-configuration-in-c-48b46a29f075?source=post_page---author_recirc--840b36d8f8c4----2---------------------f12095ca_1e89_4095_a674_8ab8c9a15b12--------------)

[

1







](https://medium.com/@iamprovidence/ioptions-the-backbone-of-app-configuration-in-c-48b46a29f075?source=post_page---author_recirc--840b36d8f8c4----2---------------------f12095ca_1e89_4095_a674_8ab8c9a15b12--------------)

[](https://medium.com/m/signin?actionUrl=https%3A%2F%2Fmedium.com%2F_%2Fbookmark%2Fp%2F48b46a29f075&operation=register&redirect=https%3A%2F%2Fmedium.com%2F%40iamprovidence%2Fioptions-the-backbone-of-app-configuration-in-c-48b46a29f075&source=---author_recirc--840b36d8f8c4----2-----------------bookmark_preview----f12095ca_1e89_4095_a674_8ab8c9a15b12--------------)

![Backend side architecture evolution (N-layered, DDD, Hexagon, Onion, Clean Architecture)](https://miro.medium.com/v2/resize:fit:679/format:webp/1*D_23xbycDJugeWoKJDiD7Q.png)

[

![iamprovidence](https://miro.medium.com/v2/resize:fill:20:20/1*5_4tdBAsyyi0qA4XgMD1xA.png)



](https://medium.com/@iamprovidence?source=post_page---author_recirc--840b36d8f8c4----3---------------------f12095ca_1e89_4095_a674_8ab8c9a15b12--------------)

[

iamprovidence

](https://medium.com/@iamprovidence?source=post_page---author_recirc--840b36d8f8c4----3---------------------f12095ca_1e89_4095_a674_8ab8c9a15b12--------------)

[

## Backend side architecture evolution (N-layered, DDD, Hexagon, Onion, Clean Architecture)

### Hola!🤠 So you want to be an architect, don't ya? Don’t lie to me, I know you do. Even if you don’t, you still want to be a better…



](https://medium.com/@iamprovidence/backend-side-architecture-evolution-n-layered-ddd-hexagon-onion-clean-architecture-643d72444ce4?source=post_page---author_recirc--840b36d8f8c4----3---------------------f12095ca_1e89_4095_a674_8ab8c9a15b12--------------)

Jun 27, 2023

[

](https://medium.com/@iamprovidence/backend-side-architecture-evolution-n-layered-ddd-hexagon-onion-clean-architecture-643d72444ce4?source=post_page---author_recirc--840b36d8f8c4----3---------------------f12095ca_1e89_4095_a674_8ab8c9a15b12--------------)

[

3.1K

](https://medium.com/@iamprovidence/backend-side-architecture-evolution-n-layered-ddd-hexagon-onion-clean-architecture-643d72444ce4?source=post_page---author_recirc--840b36d8f8c4----3---------------------f12095ca_1e89_4095_a674_8ab8c9a15b12--------------)

[

32







](https://medium.com/@iamprovidence/backend-side-architecture-evolution-n-layered-ddd-hexagon-onion-clean-architecture-643d72444ce4?source=post_page---author_recirc--840b36d8f8c4----3---------------------f12095ca_1e89_4095_a674_8ab8c9a15b12--------------)

[](https://medium.com/m/signin?actionUrl=https%3A%2F%2Fmedium.com%2F_%2Fbookmark%2Fp%2F643d72444ce4&operation=register&redirect=https%3A%2F%2Fmedium.com%2F%40iamprovidence%2Fbackend-side-architecture-evolution-n-layered-ddd-hexagon-onion-clean-architecture-643d72444ce4&source=---author_recirc--840b36d8f8c4----3-----------------bookmark_preview----f12095ca_1e89_4095_a674_8ab8c9a15b12--------------)

[

See all from iamprovidence

](https://medium.com/@iamprovidence?source=post_page---author_recirc--840b36d8f8c4---------------------------------------)

## Recommended from Medium

![Understanding the Factory Design Pattern in C# with a Real-World Example (Using .NET 9)](https://miro.medium.com/v2/resize:fit:679/format:webp/1*tTDXao7fYY2gF46rW8tF8g.png)

[

![.Net Programming](https://miro.medium.com/v2/da:true/resize:fill:20:20/1*JtC1CS6-OT218_QzRlLXFw.gif)



](https://medium.com/c-sharp-programming?source=post_page---read_next_recirc--840b36d8f8c4----0---------------------3f77bbaf_54f5_4542_ac57_2e98afce6a19--------------)

In

[

.Net Programming

](https://medium.com/c-sharp-programming?source=post_page---read_next_recirc--840b36d8f8c4----0---------------------3f77bbaf_54f5_4542_ac57_2e98afce6a19--------------)

by

[

Shubham Kumar

](https://medium.com/@itsshubhamk?source=post_page---read_next_recirc--840b36d8f8c4----0---------------------3f77bbaf_54f5_4542_ac57_2e98afce6a19--------------)

[

## Understanding the Factory Design Pattern in C# with a Real-World Example (Using .NET 9)

### In today’s world of Artificial Intelligence and advanced tools, we should still remember the importance of basic coding principles like…



](https://medium.com/c-sharp-programming/understanding-the-factory-design-pattern-in-c-with-a-real-world-example-using-net-9-7a7897518896?source=post_page---read_next_recirc--840b36d8f8c4----0---------------------3f77bbaf_54f5_4542_ac57_2e98afce6a19--------------)

Jul 9

[

](https://medium.com/c-sharp-programming/understanding-the-factory-design-pattern-in-c-with-a-real-world-example-using-net-9-7a7897518896?source=post_page---read_next_recirc--840b36d8f8c4----0---------------------3f77bbaf_54f5_4542_ac57_2e98afce6a19--------------)

[

92

](https://medium.com/c-sharp-programming/understanding-the-factory-design-pattern-in-c-with-a-real-world-example-using-net-9-7a7897518896?source=post_page---read_next_recirc--840b36d8f8c4----0---------------------3f77bbaf_54f5_4542_ac57_2e98afce6a19--------------)

[

2







](https://medium.com/c-sharp-programming/understanding-the-factory-design-pattern-in-c-with-a-real-world-example-using-net-9-7a7897518896?source=post_page---read_next_recirc--840b36d8f8c4----0---------------------3f77bbaf_54f5_4542_ac57_2e98afce6a19--------------)

[](https://medium.com/m/signin?actionUrl=https%3A%2F%2Fmedium.com%2F_%2Fbookmark%2Fp%2F7a7897518896&operation=register&redirect=https%3A%2F%2Fmedium.com%2Fc-sharp-programming%2Funderstanding-the-factory-design-pattern-in-c-with-a-real-world-example-using-net-9-7a7897518896&source=---read_next_recirc--840b36d8f8c4----0-----------------bookmark_preview----3f77bbaf_54f5_4542_ac57_2e98afce6a19--------------)

![Asynchronous Streams in .NET (IAsyncEnumerable)](https://miro.medium.com/v2/resize:fit:679/format:webp/0*XkmF6F_EiioWfZAB)

[

![Karthikeyan NS](https://miro.medium.com/v2/resize:fill:20:20/1*S2HKhn47gdKUPVdQwghXgQ.jpeg)



](https://medium.com/@karthikns999?source=post_page---read_next_recirc--840b36d8f8c4----1---------------------3f77bbaf_54f5_4542_ac57_2e98afce6a19--------------)

[

Karthikeyan NS

](https://medium.com/@karthikns999?source=post_page---read_next_recirc--840b36d8f8c4----1---------------------3f77bbaf_54f5_4542_ac57_2e98afce6a19--------------)

[

## Asynchronous Streams in .NET (IAsyncEnumerable)

### Efficient, readable, and modern asynchronous data handling



](https://medium.com/@karthikns999/asynchronous-streams-in-dotnet-iasyncenumerable-63d2a283b9b5?source=post_page---read_next_recirc--840b36d8f8c4----1---------------------3f77bbaf_54f5_4542_ac57_2e98afce6a19--------------)

6d ago

[

](https://medium.com/@karthikns999/asynchronous-streams-in-dotnet-iasyncenumerable-63d2a283b9b5?source=post_page---read_next_recirc--840b36d8f8c4----1---------------------3f77bbaf_54f5_4542_ac57_2e98afce6a19--------------)

[

4







](https://medium.com/@karthikns999/asynchronous-streams-in-dotnet-iasyncenumerable-63d2a283b9b5?source=post_page---read_next_recirc--840b36d8f8c4----1---------------------3f77bbaf_54f5_4542_ac57_2e98afce6a19--------------)

[](https://medium.com/m/signin?actionUrl=https%3A%2F%2Fmedium.com%2F_%2Fbookmark%2Fp%2F63d2a283b9b5&operation=register&redirect=https%3A%2F%2Fmedium.com%2F%40karthikns999%2Fasynchronous-streams-in-dotnet-iasyncenumerable-63d2a283b9b5&source=---read_next_recirc--840b36d8f8c4----1-----------------bookmark_preview----3f77bbaf_54f5_4542_ac57_2e98afce6a19--------------)

![Stop Wasting Threads: 5 Async Tricks That Separate Senior .NET Devs from the Rest](https://miro.medium.com/v2/resize:fit:679/format:webp/0*90JbnjdUwFKj-4MD.jpeg)

[

![Stackademic](https://miro.medium.com/v2/resize:fill:20:20/1*U-kjsW7IZUobnoy1gAp1UQ.png)



](https://medium.com/stackademic?source=post_page---read_next_recirc--840b36d8f8c4----0---------------------3f77bbaf_54f5_4542_ac57_2e98afce6a19--------------)

In

[

Stackademic

](https://medium.com/stackademic?source=post_page---read_next_recirc--840b36d8f8c4----0---------------------3f77bbaf_54f5_4542_ac57_2e98afce6a19--------------)

by

[

Gulam Ali H.

](https://medium.com/@freakyali?source=post_page---read_next_recirc--840b36d8f8c4----0---------------------3f77bbaf_54f5_4542_ac57_2e98afce6a19--------------)

[

## Stop Wasting Threads: 5 Async Tricks That Separate Senior .NET Devs from the Rest

### From channels to suppressed continuations, these async techniques will make your code smoother, faster, and smarter.



](https://medium.com/stackademic/stop-wasting-threads-5-async-tricks-that-separate-senior-net-devs-from-the-rest-a09a5ca779ad?source=post_page---read_next_recirc--840b36d8f8c4----0---------------------3f77bbaf_54f5_4542_ac57_2e98afce6a19--------------)

5d ago

[

](https://medium.com/stackademic/stop-wasting-threads-5-async-tricks-that-separate-senior-net-devs-from-the-rest-a09a5ca779ad?source=post_page---read_next_recirc--840b36d8f8c4----0---------------------3f77bbaf_54f5_4542_ac57_2e98afce6a19--------------)

[

118

](https://medium.com/stackademic/stop-wasting-threads-5-async-tricks-that-separate-senior-net-devs-from-the-rest-a09a5ca779ad?source=post_page---read_next_recirc--840b36d8f8c4----0---------------------3f77bbaf_54f5_4542_ac57_2e98afce6a19--------------)

[

3







](https://medium.com/stackademic/stop-wasting-threads-5-async-tricks-that-separate-senior-net-devs-from-the-rest-a09a5ca779ad?source=post_page---read_next_recirc--840b36d8f8c4----0---------------------3f77bbaf_54f5_4542_ac57_2e98afce6a19--------------)

[](https://medium.com/m/signin?actionUrl=https%3A%2F%2Fmedium.com%2F_%2Fbookmark%2Fp%2Fa09a5ca779ad&operation=register&redirect=https%3A%2F%2Fblog.stackademic.com%2Fstop-wasting-threads-5-async-tricks-that-separate-senior-net-devs-from-the-rest-a09a5ca779ad&source=---read_next_recirc--840b36d8f8c4----0-----------------bookmark_preview----3f77bbaf_54f5_4542_ac57_2e98afce6a19--------------)

![Mastering Transaction Management in .NET 9](https://miro.medium.com/v2/resize:fit:679/format:webp/0*k4trviIf6J6bfRda)

[

![DevOps.dev](https://miro.medium.com/v2/resize:fill:20:20/1*3SZtM9yhQyfh-dfWk5gGFw.jpeg)



](https://medium.com/devops-dev?source=post_page---read_next_recirc--840b36d8f8c4----1---------------------3f77bbaf_54f5_4542_ac57_2e98afce6a19--------------)

In

[

DevOps.dev

](https://medium.com/devops-dev?source=post_page---read_next_recirc--840b36d8f8c4----1---------------------3f77bbaf_54f5_4542_ac57_2e98afce6a19--------------)

by

[

Adem KORKMAZ

](https://medium.com/@Adem_Korkmaz?source=post_page---read_next_recirc--840b36d8f8c4----1---------------------3f77bbaf_54f5_4542_ac57_2e98afce6a19--------------)

[

## Mastering Transaction Management in .NET 9

### Transactions From TransactionScope to Distributed Patterns



](https://medium.com/devops-dev/mastering-transaction-management-in-net-9-94e63eff0504?source=post_page---read_next_recirc--840b36d8f8c4----1---------------------3f77bbaf_54f5_4542_ac57_2e98afce6a19--------------)

May 25

[

](https://medium.com/devops-dev/mastering-transaction-management-in-net-9-94e63eff0504?source=post_page---read_next_recirc--840b36d8f8c4----1---------------------3f77bbaf_54f5_4542_ac57_2e98afce6a19--------------)

[

65

](https://medium.com/devops-dev/mastering-transaction-management-in-net-9-94e63eff0504?source=post_page---read_next_recirc--840b36d8f8c4----1---------------------3f77bbaf_54f5_4542_ac57_2e98afce6a19--------------)

[

1







](https://medium.com/devops-dev/mastering-transaction-management-in-net-9-94e63eff0504?source=post_page---read_next_recirc--840b36d8f8c4----1---------------------3f77bbaf_54f5_4542_ac57_2e98afce6a19--------------)

[](https://medium.com/m/signin?actionUrl=https%3A%2F%2Fmedium.com%2F_%2Fbookmark%2Fp%2F94e63eff0504&operation=register&redirect=https%3A%2F%2Fblog.devops.dev%2Fmastering-transaction-management-in-net-9-94e63eff0504&source=---read_next_recirc--840b36d8f8c4----1-----------------bookmark_preview----3f77bbaf_54f5_4542_ac57_2e98afce6a19--------------)

![Avoid Bottlenecks: 3 Async Patterns to Supercharge .NET API Speed](https://miro.medium.com/v2/resize:fit:679/format:webp/0*ACfudwsMSn0mjkH7)

[

![ITNEXT](https://miro.medium.com/v2/resize:fill:20:20/1*yAqDFIFA5F_NXalOJKz4TA.png)



](https://medium.com/itnext?source=post_page---read_next_recirc--840b36d8f8c4----2---------------------3f77bbaf_54f5_4542_ac57_2e98afce6a19--------------)

In

[

ITNEXT

](https://medium.com/itnext?source=post_page---read_next_recirc--840b36d8f8c4----2---------------------3f77bbaf_54f5_4542_ac57_2e98afce6a19--------------)

by

[

Hossein Kohzadi

](https://medium.com/@kohzadi90?source=post_page---read_next_recirc--840b36d8f8c4----2---------------------3f77bbaf_54f5_4542_ac57_2e98afce6a19--------------)

[

## Avoid Bottlenecks: 3 Async Patterns to Supercharge .NET API Speed

### Discover performance techniques every .NET developer should master — fast, clean, and scalable.



](https://medium.com/itnext/avoid-bottlenecks-3-async-patterns-to-supercharge-net-api-speed-d5d7763ad1fd?source=post_page---read_next_recirc--840b36d8f8c4----2---------------------3f77bbaf_54f5_4542_ac57_2e98afce6a19--------------)

May 15

[

](https://medium.com/itnext/avoid-bottlenecks-3-async-patterns-to-supercharge-net-api-speed-d5d7763ad1fd?source=post_page---read_next_recirc--840b36d8f8c4----2---------------------3f77bbaf_54f5_4542_ac57_2e98afce6a19--------------)

[

176

](https://medium.com/itnext/avoid-bottlenecks-3-async-patterns-to-supercharge-net-api-speed-d5d7763ad1fd?source=post_page---read_next_recirc--840b36d8f8c4----2---------------------3f77bbaf_54f5_4542_ac57_2e98afce6a19--------------)

[

3







](https://medium.com/itnext/avoid-bottlenecks-3-async-patterns-to-supercharge-net-api-speed-d5d7763ad1fd?source=post_page---read_next_recirc--840b36d8f8c4----2---------------------3f77bbaf_54f5_4542_ac57_2e98afce6a19--------------)

[](https://medium.com/m/signin?actionUrl=https%3A%2F%2Fmedium.com%2F_%2Fbookmark%2Fp%2Fd5d7763ad1fd&operation=register&redirect=https%3A%2F%2Fitnext.io%2Favoid-bottlenecks-3-async-patterns-to-supercharge-net-api-speed-d5d7763ad1fd&source=---read_next_recirc--840b36d8f8c4----2-----------------bookmark_preview----3f77bbaf_54f5_4542_ac57_2e98afce6a19--------------)

![DI mistakes you should not be doing](https://miro.medium.com/v2/resize:fit:679/format:webp/1*fzg5DUGuZGcv6wISM68npg.jpeg)

[

![iamprovidence](https://miro.medium.com/v2/resize:fill:20:20/1*5_4tdBAsyyi0qA4XgMD1xA.png)



](https://medium.com/@iamprovidence?source=post_page---read_next_recirc--840b36d8f8c4----3---------------------3f77bbaf_54f5_4542_ac57_2e98afce6a19--------------)

[

iamprovidence

](https://medium.com/@iamprovidence?source=post_page---read_next_recirc--840b36d8f8c4----3---------------------3f77bbaf_54f5_4542_ac57_2e98afce6a19--------------)

[

## DI mistakes you should not be doing

### Dependency Injection — a golden pillar of any program. Despite how common it is, some devs are still using it wrong 😒.



](https://medium.com/@iamprovidence/di-mistakes-you-should-not-be-doing-6d1dcaa80d13?source=post_page---read_next_recirc--840b36d8f8c4----3---------------------3f77bbaf_54f5_4542_ac57_2e98afce6a19--------------)

Apr 27

[

](https://medium.com/@iamprovidence/di-mistakes-you-should-not-be-doing-6d1dcaa80d13?source=post_page---read_next_recirc--840b36d8f8c4----3---------------------3f77bbaf_54f5_4542_ac57_2e98afce6a19--------------)

[

31







](https://medium.com/@iamprovidence/di-mistakes-you-should-not-be-doing-6d1dcaa80d13?source=post_page---read_next_recirc--840b36d8f8c4----3---------------------3f77bbaf_54f5_4542_ac57_2e98afce6a19--------------)

[](https://medium.com/m/signin?actionUrl=https%3A%2F%2Fmedium.com%2F_%2Fbookmark%2Fp%2F6d1dcaa80d13&operation=register&redirect=https%3A%2F%2Fmedium.com%2F%40iamprovidence%2Fdi-mistakes-you-should-not-be-doing-6d1dcaa80d13&source=---read_next_recirc--840b36d8f8c4----3-----------------bookmark_preview----3f77bbaf_54f5_4542_ac57_2e98afce6a19--------------)

[

See more recommendations

](https://medium.com/?source=post_page---read_next_recirc--840b36d8f8c4---------------------------------------)

[

Help

](https://help.medium.com/hc/en-us?source=post_page-----840b36d8f8c4---------------------------------------)

[

Status

](https://status.medium.com/?source=post_page-----840b36d8f8c4---------------------------------------)

[

About

](https://medium.com/about?autoplay=1&source=post_page-----840b36d8f8c4---------------------------------------)

[

Careers

](https://medium.com/jobs-at-medium/work-at-medium-959d1a85284e?source=post_page-----840b36d8f8c4---------------------------------------)

[

Press

](mailto:pressinquiries@medium.com)

[

Blog

](https://blog.medium.com/?source=post_page-----840b36d8f8c4---------------------------------------)

[

Privacy

](https://policy.medium.com/medium-privacy-policy-f03bf92035c9?source=post_page-----840b36d8f8c4---------------------------------------)

[

Rules

](https://policy.medium.com/medium-rules-30e5502c4eb4?source=post_page-----840b36d8f8c4---------------------------------------)

[

Terms

](https://policy.medium.com/medium-terms-of-service-9db0094a1e0f?source=post_page-----840b36d8f8c4---------------------------------------)

[

Text to speech

](https://speechify.com/medium?source=post_page-----840b36d8f8c4---------------------------------------)