using Azure.Storage.Queues;
using static System.Net.WebRequestMethods;

namespace Azurites;

internal class QueueStorageService : IStorageService
{
    public async Task Execute()
    {
        var connectionString = "DefaultEndpointsProtocol=http;AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;QueueEndpoint=http://127.0.0.1:10001/devstoreaccount1;";

        var client = new QueueClient(connectionString, "zd-hellos");
        await client.SendMessageAsync("hello 1");
        await client.SendMessageAsync("hello 2");

        var peeks = (await client.PeekMessagesAsync(maxMessages: 2)).Value.Select(x => x.Body.ToString());
        foreach (var message in peeks)
        {
            Console.WriteLine($"{message} peeked from the queue");
        }
    }
}