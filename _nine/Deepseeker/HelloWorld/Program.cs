using Codeblaze.SemanticKernel.Connectors.Ollama;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

var builder = Kernel.CreateBuilder()
    .AddOllamaChatCompletion("deepseek-r1:1.5b", "http://localhost:11434");
builder.Services.AddScoped<HttpClient>();
var kernel = builder.Build();

while (true)
{
    string input = string.Empty;
    Console.WriteLine("Ask Deepseek anything");
    input = Console.ReadLine();

    var response = await kernel.InvokePromptAsync(input);
    Console.WriteLine($"\nDeepseek: {response}\n");
}