using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HelloWorld;

public class OpenRouterClient
{
    private readonly string _apiKey;
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "https://openrouter.ai/api/v1"; // Replace with your OpenRouter API base URL

    public async static Task Run()
    {
        string prompt = "Write a short story about a pie shop.";

        string response = await CallWith(prompt);
        Console.WriteLine("Response from GPT-4:");
        Console.WriteLine(response);
    }

    public static async Task<string> CallWith(string prompt)
    {
        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer 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");

            var requestBody = new
            {
                model = "deepseek/deepseek-r1:free",
                messages = new[]
                {
                    new { role = "system", content = "You are a helpful assistant." },
                    new { role = "user", content = prompt }
                },
                max_tokens = 200,
                temperature = 0.7
            };

            string jsonContent = JsonSerializer.Serialize(requestBody);
            StringContent httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("https://openrouter.ai/api/v1/chat/completions", httpContent);

            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                dynamic jsonResponse = JsonSerializer.Deserialize<dynamic>(result);
                return jsonResponse.choices[0].message.content;
            }
            else
            {
                string error = await response.Content.ReadAsStringAsync();
                throw new Exception($"OpenAI API error: {response.StatusCode} - {error}");
            }
        }
    }

    public OpenRouterClient(string apiKey)
    {
        _apiKey = apiKey;
        _httpClient = new HttpClient { BaseAddress = new Uri(BaseUrl) };
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");
    }

    public async Task<string> GenerateText(string prompt, string model = "deepseek/deepseek-r1:free")
    {
        var payload = new
        {
            model = model,
            messages = new[]
            {
                new { role = "user", content = prompt }
            }
        };

        var json = JsonSerializer.Serialize(payload);
        var response = await _httpClient.PostAsync("/chat/completions", new StringContent(json, System.Text.Encoding.UTF8, "application/json"));

        response.EnsureSuccessStatusCode(); // Check for errors

        var responseJson = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<dynamic>(responseJson);
        return result.choices[0].message.content;
    }
}