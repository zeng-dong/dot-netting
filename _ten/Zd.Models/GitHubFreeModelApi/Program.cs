using Azure;
using Azure.AI.Inference;
using Microsoft.AspNetCore.OpenApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

var token = builder.Configuration["GITHUB_TOKEN"]
    ?? Environment.GetEnvironmentVariable("GITHUB_TOKEN")
    ?? throw new InvalidOperationException("Set GITHUB_TOKEN (env var or user secret).");

builder.Services.AddSingleton(new ChatCompletionsClient(
    new Uri("https://models.inference.ai.azure.com"),
    new AzureKeyCredential(token)));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.MapPost("/chat", async (ChatRequest req, ChatCompletionsClient client) =>
{
    var messages = new List<ChatRequestMessage>
    {
        new ChatRequestSystemMessage("You are a friendly, concise assistant.")
    };

    foreach (var turn in req.History ?? [])
    {
        messages.Add(turn.Role == "assistant"
            ? new ChatRequestAssistantMessage(turn.Content)
            : new ChatRequestUserMessage(turn.Content));
    }

    messages.Add(new ChatRequestUserMessage(req.Message));

    var options = new ChatCompletionsOptions(messages) { Model = "gpt-4o-mini" };

    try
    {
        Response<ChatCompletions> response = await client.CompleteAsync(options);
        return Results.Ok(new { reply = response.Value.Content });
    }
    catch (RequestFailedException ex)
    {
        return Results.Problem($"Model call failed: {ex.Message}", statusCode: ex.Status);
    }
})
.WithName("Chat")
.WithOpenApi()
.Produces<object>(200)
.ProducesProblem(401);

app.Run();

record ChatRequest(string Message, List<ChatTurn>? History);
record ChatTurn(string Role, string Content); // Role: "user" | "assistant"


/*
 dotnet add package Azure.AI.Inference --prerelease
dotnet user-secrets init
dotnet user-secrets set "GITHUB_TOKEN" "github_pat_xxxxxxxx"
dotnet run

Test it:

bash
curl -X POST http://localhost:5000/chat \
  -H "Content-Type: application/json" \
  -d '{"message":"What is dependency injection?","history":[]}'
 */