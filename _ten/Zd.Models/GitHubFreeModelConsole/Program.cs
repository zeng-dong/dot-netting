using Azure;
using Azure.AI.Inference;

var token = Environment.GetEnvironmentVariable("GITHUB_TOKEN") ?? throw new InvalidOperationException("Set GITHUB_TOKEN environment variable first.");


var endpoint = new Uri("https://models.inference.ai.azure.com");
var client = new ChatCompletionsClient(endpoint, new AzureKeyCredential(token));

var chatHistory = new List<ChatRequestMessage>
{
    new ChatRequestSystemMessage("You are a friendly, concise assistant.")
};

Console.WriteLine("Simple chat app (type 'exit' to quit)");
Console.WriteLine("--------------------------------------");

while (true)
{
    Console.Write("\nYou: ");
    var input = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(input) || input.Trim().ToLower() == "exit")
        break;

    chatHistory.Add(new ChatRequestUserMessage(input));

    var options = new ChatCompletionsOptions(chatHistory)
    {
        Model = "gpt-4o-mini" // try "Meta-Llama-3.1-8B-Instruct" or "Mistral-large" too
    };

    Response<ChatCompletions> response = await client.CompleteAsync(options);
    var reply = response.Value.Content;

    Console.WriteLine($"\nAssistant: {reply}");
    chatHistory.Add(new ChatRequestAssistantMessage(reply));
}