using Codeblaze.SemanticKernel.Connectors.Ollama;
using HelloWorld;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;

//var builder = Kernel.CreateBuilder()
//    .AddOllamaChatCompletion("deepseek-r1:1.5b", "http://localhost:11434");
//builder.Services.AddScoped<HttpClient>();
//var kernel = builder.Build();

//string input = string.Empty;
//while (true)
//{
//    Console.WriteLine("Ask Deepseek anything");
//    input = Console.ReadLine();

//    var response = await kernel.InvokePromptAsync(input);
//    Console.WriteLine($"\nDeepseek: {response}\n");
//}

//var openRouterClient = new OpenRouterClient("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");
//string generatedText = await openRouterClient.GenerateText("Write a poem about a cat");
//Console.WriteLine(generatedText);

await OpenRouterClient.Run();