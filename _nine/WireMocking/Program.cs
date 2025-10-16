using System.Net.Mime;
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


Console.ReadLine();

// create the sub
/*
1. Path /test
 */