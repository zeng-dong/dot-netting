using OpenAI.Chat;

ChatClient client = new ChatClient(
    model: "gpt-4o",
    apiKey: "");

ChatCompletion completion = client.CompleteChat("what is the capital of China?");

Console.WriteLine(completion.Content[0].Text);