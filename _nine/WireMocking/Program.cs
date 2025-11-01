using System.Net.Mime;
using WireMock.Matchers;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using WireMock.Settings;

Console.WriteLine("Wire Mocking Server Starting");

var server = WireMockServer.Start(new WireMockServerSettings
{
    Urls = ["http://localhost:9091/"],
    Port = 9091,
    StartAdminInterface = true,
    ReadStaticMappings = true,
    WatchStaticMappings = true
});

server.Given(Request.Create().WithPath("/test").UsingGet())
    .RespondWith(Response.Create()
        .WithStatusCode(200)
        .WithHeader("Content-Type", "application/json")
        .WithBody("Welcome to WireMocking!"));

server.Given(Request.Create().WithPath("/headers").UsingGet())
    .RespondWith(Response.Create()
        .WithStatusCode(200)
        .WithHeaders(new Dictionary<string, string>
        {
            { "Content-Type", "application/json" },
            { "x-custom-header", "custom-value" },
            { "accept", MediaTypeNames.Application.Json },
            { "Cache-Control", "no-cache" }
        })
        .WithBody("Welcome to WireMocking!"));

// stub productId - match one particular value
server.Given(Request.Create().WithPath("/product/123").UsingGet())
    .RespondWith(Response.Create()
        .WithStatusCode(200)
        .WithHeader("Content-Type", "application/json")
        .WithBody("{ \"productId\": 123, \"productName\": \"Sample Product\" }"));

server.Given(Request.Create().WithPath(new RegexMatcher("/product/[0-9]+$")).UsingGet())
    .RespondWith(Response.Create()
        .WithStatusCode(200)
        .WithHeader("Content-Type", "application/json")
        .WithBody("{ \"productId\": 123, \"productName\": \"Sample Product\" }"));

server.Given(Request.Create().WithPath(new WildcardMatcher("/product/*")).UsingGet())
    .RespondWith(Response.Create()
        .WithStatusCode(200)
        .WithHeader("Content-Type", "application/json")
        .WithBody("{ \"productId\": 123, \"productName\": \"Sample Product\", \"description\": \"can match any alphabet\" }"));

server.Given(Request.Create().WithPath(new ExactMatcher("/Address")).UsingGet())
    .RespondWith(Response.Create()
        .WithStatusCode(200)
        .WithHeader("Content-Type", "application/json")
        .WithBodyAsJson(
            new
            {
                street = "123 Main St",
                city = "Anytown",
                state = "CA",
                zip = "12345"
            }));

// stub - login
server.Given(
    Request.Create()
    .WithPath("/login")
    .UsingGet()
    //.WithHeader("Authorization", "Bearer 123-abc-xyz789"))
    .WithHeader("Authorization", new WildcardMatcher("Bearer *")))
    .RespondWith(Response.Create()
        .WithStatusCode(200)
        .WithHeader("Content-Type", "application/json")
        .WithBody("Login successfully"));

// stub - login rejected
server.Given(
    Request.Create()
    .WithPath("/login")
    .UsingGet()
    .WithHeader("Authorization", "*", MatchBehaviour.RejectOnMatch))
    .RespondWith(Response.Create()
        .WithStatusCode(System.Net.HttpStatusCode.Unauthorized)
        .WithHeader("Content-Type", "application/json")
        .WithBody("Login unsuccessfully"));

Console.ReadLine();

// create the sub
/*
1. Path /test
 */

/*

 var githubUser = await _gitHubApi.GetUserAsync(gitHubUserName)

 new Dto {
    followers = githubUser.Followers
}

 */

//var ws = WireMockServer.Start();
//Console.WriteLine($"Server is running at: {ws.Urls[0]}");
//const baseAddress = "https://api.github.com";

//Console.ReadKey();
//ws.Stop();
//ws.Dispose();