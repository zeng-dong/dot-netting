using OpenAI;
using OpenAI.Chat;

namespace HelloWorld;

public class ChatCompletions
{
    static string key = "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";

    public static void SimpleChat(string modelName)
    {
        ChatClient client = new(modelName, key);

        ChatCompletion completion = client.CompleteChat("Say 'Hello AI world'");

        Console.WriteLine($"[ASSISTANT]: {completion.Content[0].Text}");
    }

    //public static Task Run()
    //{
    //    // Configure the OpenAI SDK to use your local DeepSeek R1 API
    //    var api = new OpenAIClient("https://openrouter.ai/api/v1", "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");

    //    // Create a chat request
    //    var messages = new List<Message>
    //    {
    //        new Message(Role.User, "Hello, how are you?")
    //    };

    //    var chatRequest = new ChatRequest(messages, model: "deepseek-r1");

    //    // Send the chat request
    //    var response = await api.ChatEndpoint.GetCompletionAsync(chatRequest);

    //    // Print the response
    //    Console.WriteLine(response.FirstChoice.Message.Content);
    //}
}