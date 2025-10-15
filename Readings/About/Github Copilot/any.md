
# some questions

The Test Pyramid: succeeding with agile, the importance of automation

* how do you handle external api calls when developing api tests
* is it possible to develop robust test automation without following FIRST
* what is the impact when not following isolation principle during development test automation

imaging **==Bridge==** Stock Market API
GET: stocks/texas/
how to assert the count of stocks
how to assert attributes (price, volume) of each stock
or should we
what is our SUT, what is the specification for this SUT

imaging **==Bridge==** NASA near earth objects API
GET: nasa/api/earth/near/objects/v2/within10000miles
how to assert the count of objects
how to assert the object xyz which was 9500 miles from earth last time we ran the api now is not being return at all?
how to assert the description of each object (size, weight, chemicals, distance,  etc)
or should we
what is our SUT, what is the specification for this SUT

imaging we test a **==Bridge==** over troubled water to enable Apollo 13 to be transported from build site to launch site
how to assert the count of Apollo 13s being transported
how to assert the attributes of Apollo 13: let me open the command cabin and issue a series operational commands?
or should we
what is our SUT, what is the specification for this SUT

some other scenarios of bridge/interface we can think: 
	nuclear bomb detonating device testing
	nuclear bomb dropping testing
	nuclear bomb dismantling testing


have we considered:
WireMock or WireMock.net, 
why do they even exist
why so many downloads

# weather forecast with integration test with wiremock.net
zeng-dong: create a simple asp.net core web api project in this folder, with the goal to demo how to develope integration tests mocking external api calls, pleae use wiremock.net

GitHub Copilot: I'll help you create an ASP.NET Core Web API project with integration tests using WireMock.NET. Let me break this down into steps and create a proper project structure.

First, let me create a new workspace for this project: 

Generating plan to create a new workspace

Let me create the solution with two projects - one for the API and one for integration tests. I'll first set up the basic project structure: 

Ran terminal command: dotnet new sln -n GhcIntegrationTesting

Now, let's create the Web API project: 

Ran terminal command: dotnet new webapi -n GhcIntegrationTesting.Api

Let's create the integration tests project: 

Ran terminal command: dotnet new xunit -n GhcIntegrationTesting.IntegrationTests

Now, let's add both projects to the solution: 

Ran terminal command: dotnet sln add GhcIntegrationTesting.Api/GhcIntegrationTesting.Api.csproj GhcIntegrationTesting.IntegrationTests/GhcIntegrationTesting.IntegrationTests.csproj

Let's add the required packages for WireMock.NET and other testing dependencies to the integration tests project: 

Ran terminal command: cd GhcIntegrationTesting.IntegrationTests && dotnet add package WireMock.Net && dotnet add package Microsoft.AspNetCore.Mvc.Testing && dotnet add package FluentAssertions && dotnet add reference ../GhcIntegrationTesting.Api/GhcIntegrationTesting.Api.csproj

I apologize for the command syntax error. Let me fix that and run the commands separately: 

Ran terminal command: cd GhcIntegrationTesting.IntegrationTests; dotnet add package WireMock.Net; dotnet add package Microsoft.AspNetCore.Mvc.Testing; dotnet add package FluentAssertions; dotnet add reference ../GhcIntegrationTesting.Api/GhcIntegrationTesting.Api.csproj

Now I'll create a simple weather forecast API endpoint in the API project and an external service interface to demonstrate mocking: 

Created [](file:///c%3A/_github/ghc-integration-testing/GhcIntegrationTesting.Api/Services/IWeatherService.cs)

Created [](file:///c%3A/_github/ghc-integration-testing/GhcIntegrationTesting.Api/Services/ExternalWeatherService.cs)

Created [](file:///c%3A/_github/ghc-integration-testing/GhcIntegrationTesting.Api/Controllers/WeatherForecastController.cs)

Let me fix the accessibility issue with WeatherForecast and update the Program.cs to register our services: 

Created [](file:///c%3A/_github/ghc-integration-testing/GhcIntegrationTesting.Api/Program.cs)

I apologize for the error. Let me use the replace_string_in_file tool to modify the Program.cs: 

Read [](file:///c%3A/_github/ghc-integration-testing/GhcIntegrationTesting.Api/Program.cs#1-1), lines 1 to 30

Using "Replace String in File"


```

```
Let me add the required package for Swagger and remove the extra code from Program.cs: 

Ran terminal command: cd GhcIntegrationTesting.Api; dotnet add package Swashbuckle.AspNetCore

I apologize for the path error. Let me try again with the correct path: 

Ran terminal command: cd ..; cd GhcIntegrationTesting.Api; dotnet add package Swashbuckle.AspNetCore

Now, let's create an integration test that uses WireMock.NET to mock the external weather service: 

Created [](file:///c%3A/_github/ghc-integration-testing/GhcIntegrationTesting.IntegrationTests/WeatherForecastIntegrationTests.cs)

Let's make the WeatherForecast class public: 

Using "Replace String in File"

I apologize for the confusion. Let's try to build the solution and see if there are any errors: 

Ran terminal command: dotnet build

Let me fix the Program.cs file to remove the remaining extra code: 

Read [](file:///c%3A/_github/ghc-integration-testing/GhcIntegrationTesting.Api/Program.cs#1-1), lines 1 to 33

Using "Replace String in File"


```

```
Now, let's make the Program class public so the test project can reference it. We need to add the following line to Program.cs: 

Using "Replace String in File"


```

```
I apologize for the mistake. Let's modify the Program.cs again: 

Created [](file:///c%3A/_github/ghc-integration-testing/GhcIntegrationTesting.Api/Program.cs)

I apologize for the confusion. Let me try the replace_string_in_file tool again with the correct approach: 

Using "Replace String in File"

Let me read the entire file content first: 

Read [](file:///c%3A/_github/ghc-integration-testing/GhcIntegrationTesting.Api/Program.cs)

Using "Replace String in File"


```

```
Now let's try building and running the tests: 

Continue to iterate?
[object Object]

Made changes.

zeng-dong: @agent Continue: "Continue to iterate?"

GitHub Copilot: Ran terminal command: dotnet test

The basic integration test project is now set up. Let me summarize what we've created:

1. An ASP.NET Core Web API project with:
   - A `WeatherForecast` controller that depends on `IWeatherService`
   - An `ExternalWeatherService` that makes HTTP calls to fetch weather data
   - Swagger configuration for API documentation

2. An Integration Tests project with:
   - WireMock.NET for mocking external HTTP dependencies
   - A complete integration test that:
     - Starts a WireMock server
     - Configures the test application to use the mock server
     - Sets up mock responses for the external API
     - Tests the actual API endpoint

To run the test, you can use:
```
dotnet test
```

The test demonstrates how to:
1. Mock external HTTP dependencies using WireMock.NET
2. Set up mock responses with specific data
3. Verify that the API correctly processes the mocked response
4. Use FluentAssertions for cleaner assertions

Would you like me to add more test cases or demonstrate other scenarios?

zeng-dong: I get an exception "System.Net.Http.HttpRequestException: Response status code does not indicate success: 404 (Not Found)." when I try to GET from the api, please explain and fix

GitHub Copilot: Let me check the relevant files to see what might be causing the 404 error. 

Read [](file:///c%3A/_github/ghc-integration-testing/GhcIntegrationTesting.Api/Services/ExternalWeatherService.cs)

Read [](file:///c%3A/_github/ghc-integration-testing/GhcIntegrationTesting.IntegrationTests/WeatherForecastIntegrationTests.cs#1-1), lines 1 to 50

I can see the issue. The problem is in the path mismatch between what the `ExternalWeatherService` is requesting and what the controller is expecting:

1. In ExternalWeatherService.cs, we're making a request to `/api/weatherforecast`
2. The WireMock mock server is correctly set up to respond to `/api/weatherforecast`
3. But when you're calling the API directly, it's mapped to `/WeatherForecast` (based on the controller name)

Let's modify the `ExternalWeatherService` to match the correct path: 

Using "Replace String in File"


```

```
And let's update the integration test to match: 

Using "Replace String in File"


```

```
The changes I made:
1. Updated `ExternalWeatherService` to use `WeatherForecast` as the endpoint path (removing the `/api/` prefix)
2. Updated the WireMock mock server configuration to match the same path

Now when you make a GET request to your API, this is what happens:
1. Client calls `/WeatherForecast`
2. The request is handled by `WeatherForecastController`
3. The controller calls `ExternalWeatherService`
4. `ExternalWeatherService` makes a request to `WeatherForecast` on the configured base URL
5. The mock server receives the request and returns the configured mock response

Try running the API again and it should work now. You can verify this by running:
```
dotnet run
```
And then making a GET request to `/WeatherForecast` using your browser, Swagger UI, or a tool like Postman.

Made changes.

zeng-dong: Add a negative test case please

GitHub Copilot: I'll add a test case that verifies how the API behaves when the external service returns an error. Here's a test that checks the scenario when the external service returns a 500 Internal Server Error: 

Using "Replace String in File"


```

```
For this test to work properly, we need to modify the WeatherForecastController to handle the external service error appropriately and return a 500 status code: 

Read [](file:///c%3A/_github/ghc-integration-testing/GhcIntegrationTesting.Api/Controllers/WeatherForecastController.cs)

Using "Replace String in File"


```

```
I've made the following changes:

1. Added a new test case `Get_ShouldReturn500_WhenExternalServiceFails` that:
   - Configures the mock server to return a 500 Internal Server Error
   - Verifies that our API also returns a 500 status code
   - Checks that the error message contains information about the failure

2. Modified the `WeatherForecastController` to:
   - Return `IActionResult` instead of directly returning the forecast data
   - Add proper error handling using try-catch
   - Return appropriate HTTP status codes and error messages

This test ensures that our API properly handles and communicates external service failures to its clients. When the external service fails, instead of crashing or returning a generic error, our API:
1. Catches the exception
2. Returns a 500 Internal Server Error status code
3. Provides a meaningful error message

You can run the tests to verify both the success and failure scenarios:
```
dotnet test
```

Would you like me to add more test cases for other scenarios, such as:
1. External service timeout
2. Invalid JSON response
3. Empty response
4. Different HTTP status codes (404, 403, etc.)?

Made changes.

zeng-dong: add a test case that for the response to be an arrya of weathers

GitHub Copilot: I'll add a test case that verifies the API can handle multiple weather forecasts in the response array: 

Using "Replace String in File"


```

```
I've added a new test case `Get_ShouldReturnMultipleForecasts_WhenExternalServiceProvidesArray` that:

1. Sets up a mock response with an array of three weather forecasts, each having:
   - Different dates (sequential days)
   - Different temperatures
   - Different summaries

2. Verifies that:
   - The response contains exactly 3 forecasts
   - Each forecast has the correct data (temperature and summary)
   - The dates are sequential (each forecast is for a later date than the previous one)

This test ensures that our API can properly:
1. Handle multiple forecasts in the response
2. Preserve the order of the forecasts
3. Correctly deserialize all properties for each forecast
4. Maintain the relationships between forecasts (like date sequencing)

You can run the tests to verify all scenarios:
```
dotnet test
```

This complements our existing tests by verifying not just the success/failure cases but also the ability to handle collections of data. Would you like me to add more test cases or enhance the existing ones with additional assertions?

Made changes.

zeng-dong: please write another integration tests using named httpclient instead of wiremock.net

GitHub Copilot: I'll create another test class that demonstrates integration testing using a named HttpClient with message handlers. This is another common approach to mocking HTTP dependencies. 

Created [](file:///c%3A/_github/ghc-integration-testing/GhcIntegrationTesting.IntegrationTests/WeatherForecastNamedHttpClientTests.cs)

Created [](file:///c%3A/_github/ghc-integration-testing/GhcIntegrationTesting.IntegrationTests/TestMessageHandler.cs)

I've created two new files that demonstrate an alternative approach to integration testing using named HttpClient with a custom message handler:

1. `WeatherForecastNamedHttpClientTests.cs`:
   - Uses `TestMessageHandler` instead of WireMock.NET
   - Configures the test handler through dependency injection
   - Includes the same test cases as the WireMock version
   - Adds request verification to ensure correct URLs are called

2. `TestMessageHandler.cs`:
   - A custom `HttpMessageHandler` for testing
   - Allows queuing responses for different requests
   - Tracks all requests made through it
   - Supports both JSON and string responses

Key differences from the WireMock.NET approach:

1. **Dependency Injection**:
   - Instead of configuring a mock server URL, we inject our test handler
   - Removes the existing HttpClient registration and adds our own
   - More closely matches how you might test in a microservices environment

2. **Request Verification**:
   - We can verify exactly what requests were made
   - Access to full request details (headers, content, etc.)
   - No need for port management or network calls

3. **Response Queue**:
   - Responses are queued in memory
   - No need for setting up mock server rules
   - Simpler setup for most common scenarios

To use this approach:

```csharp
// Queue a response
_testMessageHandler.QueueResponse(HttpStatusCode.OK, mockResponse);

// Make the request
var response = await _client.GetAsync("/WeatherForecast");

// Verify the request (optional)
_testMessageHandler.Requests.Should().HaveCount(1);
_testMessageHandler.Requests[0].RequestUri?.PathAndQuery.Should().Be("/WeatherForecast");
```

This approach is particularly useful when:
1. You want to avoid network calls in tests
2. You need detailed request verification
3. You're testing in environments where network ports might be restricted
4. You want simpler setup without external dependencies

Both approaches (WireMock.NET and named HttpClient) are valid, and which one you choose often depends on your specific needs:
- WireMock.NET is great for more complex scenarios and when you want to simulate a real HTTP server
- Named HttpClient with test handler is simpler and more lightweight for basic HTTP mocking needs

You can run both sets of tests with:
```
dotnet test
```

Would you like me to add more test cases or explain any part in more detail?

Made changes.

zeng-dong: add some detailed explanation why named httpclient is useful

GitHub Copilot: I'll add detailed documentation explaining the benefits and use cases of named HttpClient through code comments: 

Using "Replace String in File"


```

```
Let me also enhance the TestMessageHandler documentation to explain its role in testing: 

Using "Replace String in File"


```

```
I've added comprehensive documentation that explains:

1. For Named HttpClient (WeatherForecastNamedHttpClientTests.cs):
   - Lifecycle Management benefits
   - Dependency Injection advantages
   - Configuration Management capabilities
   - Testing Benefits
   - Resilience and Security features

2. For TestMessageHandler (TestMessageHandler.cs):
   - Response Queue functionality
   - Request Tracking capabilities
   - Integration Testing support
   - Usage examples and scenarios

The documentation provides a clear understanding of:
- Why you would choose named HttpClient over traditional HttpClient
- How it improves testability and maintenance
- Common use cases and benefits
- Integration with dependency injection
- Best practices for testing HTTP clients

These patterns are particularly valuable when:
1. Building microservices that communicate over HTTP
2. Working with external APIs
3. Needing to test network-dependent code
4. Implementing resilient HTTP communication
5. Managing multiple HTTP client configurations

The documentation should help team members understand:
- The motivation behind using named HttpClient
- How to effectively test HTTP communications
- Best practices for HTTP client management
- Ways to verify HTTP interactions in tests

Would you like me to add more examples or explain any specific aspect in more detail?

Made changes.


# zd's generic question to ghc without a concrete context
zeng-dong: explain how to mock external api calls in asp.net core integration tests, can you also give me a simple esampel

GitHub Copilot: I'll start by creating a short todo plan for this multi-step response (explanation, example code, run instructions), marking the first item in-progress. Then I'll provide the explanation and a compact, copy-pastable example including a WebApplicationFactory-based integration test that mocks external HTTP calls using RichardSzalay.MockHttp. 

Created 3 todos

I'll update the todo list to mark all items completed because I'm delivering the explanation, example code, and run instructions in this message. 

Completed (1/3) *Write explanation of mocking approaches*

I'll explain the approaches and then give a compact, copy-pasteable example: a minimal ASP.NET Core app with a typed HttpClient, a controller that calls an external API, and an xUnit integration test using WebApplicationFactory that injects a mocked HttpMessageHandler via RichardSzalay.MockHttp.

## How to mock external API calls in ASP.NET Core integration tests (short guide)
Contract:
- Inputs: your app makes outbound HTTP calls using HttpClient (either IHttpClientFactory/typed clients or direct HttpClient).
- Output: integration tests that exercise your app end-to-end but replace external network calls with deterministic mock responses.
- Error modes: network timeouts, non-200 responses, invalid JSON.
- Success criteria: app handles mocked responses as expected; tests don't hit the real network.

Common strategies (choose one based on your architecture):

1. Replace the HttpMessageHandler used by HttpClient
- If you use IHttpClientFactory / typed clients, you can register a custom HttpMessageHandler (or a mock handler) in DI for tests.
- Advantage: simple, no external server needed, deterministic responses.
- Tools: RichardSzalay.MockHttp (MockHttpMessageHandler) is a widely-used library.

2. Provide a fake implementation of your API client interface
- If you wrap outbound calls in an interface (IExternalApiClient), in integration tests you can replace that implementation with an in-memory fake.
- Advantage: pure DI swap; works even if you don't use HttpClientFactory.
- Downside: less "integration" (you skip the real HttpClient behavior).

3. Run a local fake server (WireMock.Net, MockServer, testserver) and point your HttpClient to it
- Start an in-process mock HTTP server with predetermined responses; configure your app under test to call that server.
- Advantage: exercises HTTP stack more fully (serialization, auth, headers).
- Use WireMock.Net if you want rich request/response mappings.

4. Use WebApplicationFactory.ConfigureTestServices to swap service registrations
- In ASP.NET Core integration tests (WebApplicationFactory<T>), use ConfigureTestServices to replace services (typed client registrations, named clients, or your IExternalApiClient).
- Works well combined with approaches 1 or 2.

Edge cases to consider
- Typed/named client configuration: ensure the test overrides the same registration name/type the app expects.
- HttpClient base address: when mocking message handler, base address may still be used for relative URLs—ensure it matches expectations.
- Concurrency/timeouts: ensure your mock can handle multiple calls concurrently if tests do so.
- Resilience policies (e.g., Polly): if you use retry/circuit-breakers, you may need to relax timeouts or return responses that exercise policy paths.
- Authentication: if outbound requests require tokens, either mock token providers or keep the mock server independent of auth checks.

When to use which:
- Replace handler (MockHttp): best when you want quick deterministic integration tests and you use typed HttpClient.
- Fake implementation: best for unit tests or when you want to avoid touching HttpClient at all.
- WireMock / real fake server: best when you need to validate HTTP-level behavior (headers, content-type, redirects).

---

## Minimal example
- App: controller that calls an external API via a typed HttpClient (IExternalApiClient).
- Test: WebApplicationFactory-based integration test using RichardSzalay.MockHttp to mock the HttpMessageHandler for that typed client.

Files below are minimal and focused on the core idea; adapt to your project structure.

Example code (C#)

1) Interface and typed client
- IExternalApiClient.cs
- ExternalApiClient.cs

IExternalApiClient:
- Task<string> GetDataAsync();

ExternalApiClient:
- Uses injected HttpClient to call "/external/data" and returns response string.

2) Controller
- ExternalProxyController.cs
- GET /api/proxy/data -> calls IExternalApiClient.GetDataAsync and returns it.

3) Program.cs (minimal for ASP.NET Core)
- Registers ExternalApiClient as typed client:
  services.AddHttpClient<IExternalApiClient, ExternalApiClient>(c => c.BaseAddress = new Uri("https://external.api"));

4) Integration test
- Uses xUnit, Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactory<TProgram>, and RichardSzalay.MockHttp.
- In test, create a MockHttpMessageHandler, set up expected request and response, then inject it into the IServiceCollection by overriding the typed client registration to use HttpClient with the mocked handler.
- Then run a test client against the in-memory factory and assert response.

Concrete C# snippets (combine into your project):

- IExternalApiClient.cs
  interface IExternalApiClient
  {
      Task<string> GetDataAsync();
  }

- ExternalApiClient.cs
  using System.Net.Http;
  using System.Threading.Tasks;
  using System;

  public class ExternalApiClient : IExternalApiClient
  {
      private readonly HttpClient _http;

      public ExternalApiClient(HttpClient http)
      {
          _http = http;
      }

      public async Task<string> GetDataAsync()
      {
          var resp = await _http.GetAsync("/external/data");
          resp.EnsureSuccessStatusCode();
          return await resp.Content.ReadAsStringAsync();
      }
  }

- ExternalProxyController.cs
  using Microsoft.AspNetCore.Mvc;
  using System.Threading.Tasks;

  [ApiController]
  [Route("api/proxy")]
  public class ExternalProxyController : ControllerBase
  {
      private readonly IExternalApiClient _client;
      public ExternalProxyController(IExternalApiClient client) => _client = client;

      [HttpGet("data")]
      public async Task<IActionResult> Get()
      {
          var data = await _client.GetDataAsync();
          return Ok(new { data });
      }
  }

- Program.cs (minimal)
  using Microsoft.AspNetCore.Builder;
  using Microsoft.Extensions.DependencyInjection;
  using Microsoft.Extensions.Hosting;
  using System;

  var builder = WebApplication.CreateBuilder(args);
  builder.Services.AddControllers();

  // Register typed HttpClient for IExternalApiClient; in production this would point to the real API.
  builder.Services.AddHttpClient<IExternalApiClient, ExternalApiClient>(client =>
  {
      client.BaseAddress = new Uri("https://external.api"); // production base address; in tests we inject handler
  });

  var app = builder.Build();
  app.MapControllers();
  app.Run();

- Integration test using xUnit and MockHttp
  using System.Net;
  using System.Net.Http;
  using System.Threading.Tasks;
  using Microsoft.AspNetCore.Mvc.Testing;
  using Microsoft.Extensions.DependencyInjection;
  using RichardSzalay.MockHttp;
  using Xunit;

  public class ExternalProxyIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
  {
      private readonly WebApplicationFactory<Program> _factory;

      public ExternalProxyIntegrationTests(WebApplicationFactory<Program> factory)
      {
          _factory = factory;
      }

      [Fact]
      public async Task ProxyEndpoint_ReturnsMockedExternalData()
      {
          // Arrange: create a MockHttpMessageHandler and setup expected external API call
          var mockHttp = new MockHttpMessageHandler();

          mockHttp.When(HttpMethod.Get, "https://external.api/external/data")
                  .Respond("application/json", "\"mocked-value\"");

          // Build factory with overridden HttpClient for IExternalApiClient
          var clientFactory = _factory.WithWebHostBuilder(builder =>
          {
              builder.ConfigureServices(services =>
              {
                  // Remove existing typed client registrations for IExternalApiClient if any
                  // and add a new HttpClient that uses the mock handler.
                  services.AddHttpClient<IExternalApiClient, ExternalApiClient>(c =>
                  {
                      c.BaseAddress = new System.Uri("https://external.api");
                  })
                  .ConfigurePrimaryHttpMessageHandler(() => mockHttp);
              });
          });

          var client = clientFactory.CreateClient();

          // Act
          var response = await client.GetAsync("/api/proxy/data");

          // Assert
          response.EnsureSuccessStatusCode();
          var body = await response.Content.ReadAsStringAsync();
          Assert.Contains("mocked-value", body);
      }
  }

Notes on the test:
- We set the BaseAddress to the same URL the app expects (https://external.api) so relative calls in ExternalApiClient (GetAsync("/external/data")) resolve to the URL mocked by MockHttp.
- The MockHttpMessageHandler handles requests without needing a real network.
- Use ConfigurePrimaryHttpMessageHandler to inject the handler used by HttpClient.

Alternative: Replace specific service registration
If your app registers an IExternalApiClient implementation directly (not via AddHttpClient<TClient>), in ConfigureTestServices you can remove the registration and add a test implementation:
services.RemoveAll<IExternalApiClient>();
services.AddSingleton<IExternalApiClient>(new FakeExternalApiClient());

Alternative: Use WireMock.Net
- Start a WireMockServer in test (WireMock.Net.StandAlone or in-process).
- Configure mappings and set typed client's BaseAddress to the server's URL.
- Useful when you want to test headers, delays, or more complex HTTP behaviors.

---

## Run instructions (PowerShell on Windows) - packages and run
Commands to install required NuGet packages (for test project). Run in your solution folder:

- Add package for MockHttp and testing:
```powershell
dotnet add <YourTestProject>.csproj package RichardSzalay.MockHttp
dotnet add <YourTestProject>.csproj package Microsoft.AspNetCore.Mvc.Testing
dotnet add <YourTestProject>.csproj package xunit
dotnet add <YourTestProject>.csproj package xunit.runner.visualstudio
```

Replace <YourTestProject>.csproj with your actual test project file path. If you don't have a separate test project, create one:
```powershell
dotnet new xunit -o tests/IntegrationTests
dotnet sln add tests/IntegrationTests/IntegrationTests.csproj
```

Then run tests:
```powershell
dotnet test
```

---

## Quick pitfalls and tips
- Ensure the registration you override in tests matches how your app resolves the client (typed vs named client).
- If your typed client uses authentication handlers, be aware they will run unless you disable them or make the mock handler handle auth requests.
- MockHttp is thread-safe and supports expectations for multiple calls; read its docs when setting up sequences or verifications.
- If your code uses IHttpClientFactory.CreateClient("name") with a named client, override that named client in tests using services.AddHttpClient("name").ConfigurePrimaryHttpMessageHandler(...).
- For richer verification (assert that a certain request was made), MockHttp provides Verify methods or you can use its Expectations to ensure specific calls occurred.

---

Completion summary
- Explained the main approaches to mocking external API calls in ASP.NET Core integration tests and when to use each.
- Provided a complete, minimal example showing:
  - A typed HttpClient wrapper (IExternalApiClient)
  - Controller that proxies external API
  - An xUnit WebApplicationFactory integration test that injects a RichardSzalay.MockHttp handler for deterministic responses
- Provided PowerShell-friendly commands to add NuGet packages and run tests.

If you'd like, I can:
- Integrate this example into your repository (create files under your project layout) and run the tests here.
- Show an example using a named HttpClient or WireMock.Net.
- Add assertions for request headers or a sequence of responses (e.g., retries).