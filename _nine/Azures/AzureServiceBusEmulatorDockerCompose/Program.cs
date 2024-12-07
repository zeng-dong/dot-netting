using Azure.Messaging.ServiceBus;

Console.WriteLine("Hello, Azure Service Bus Emulator brought to you by Docker Compose!");

ServiceBusClient client;

ServiceBusSender sender;

const int numOfMessages = 3;

// get the right port from docker
client = new ServiceBusClient(
    "Endpoint=sb://localhost:5672;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=SAS_KEY_VALUE;UseDevelopmentEmulator=true;");
sender = client.CreateSender("queue.1");

using ServiceBusMessageBatch messageBatch = await sender.CreateMessageBatchAsync();
for (int i = 1; i <= numOfMessages; i++)
{
    if (!messageBatch.TryAddMessage(new ServiceBusMessage($"Message {i}")))
    {
        throw new Exception($"The message {i} is too large to fit in the batch.");
    }
}

try
{
    // Use the producer client to send the batch of messages to the Service Bus queue
    await sender.SendMessagesAsync(messageBatch);
    Console.WriteLine($"A batch of {numOfMessages} messages has been published to the queue.");
}
finally
{
    await sender.DisposeAsync();
    await client.DisposeAsync();
}

Console.WriteLine("Press any key to end the application");
Console.ReadKey();