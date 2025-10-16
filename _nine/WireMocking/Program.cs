using WireMock.Server;
using WireMock.Settings;

Console.WriteLine("Hello, World!");

var server = WireMockServer.Start(new WireMockServerSettings
{
    Urls = ["http://localhost:9091/"],
    Port = 9091,
    StartAdminInterface = true,
    ReadStaticMappings = true,
    WatchStaticMappings = true
});