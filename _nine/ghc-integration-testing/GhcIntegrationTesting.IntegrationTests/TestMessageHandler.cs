using System.Net;
using System.Net.Http.Json;

using System.Text.Json;

namespace GhcIntegrationTesting.IntegrationTests;

/// <summary>
/// A custom HttpMessageHandler for testing HTTP clients without making real network calls.
///
/// This handler provides several testing capabilities:
///
/// 1. Response Queue:
///    - Pre-configure responses for upcoming requests
///    - Support both JSON and plain text responses
///    - Control status codes and response content
///
/// 2. Request Tracking:
///    - Records all requests made through the handler
///    - Enables verification of request properties:
///      * URLs and query parameters
///      * Headers
///      * Request content
///      * HTTP methods
///
/// 3. Integration Testing Support:
///    - Works with HttpClient factory pattern
///    - Can be injected through dependency injection
///    - Supports async/await patterns
///
/// Usage Example:
/// ```csharp
/// var handler = new TestMessageHandler();
///
/// // Queue a success response
/// handler.QueueResponse(HttpStatusCode.OK, new { data = "test" });
///
/// // Queue an error response
/// handler.QueueResponse(HttpStatusCode.InternalServerError, "Error occurred");
///
/// // Verify requests after execution
/// handler.Requests.Should().HaveCount(2);
/// handler.Requests[0].RequestUri.Should().Be("/api/endpoint");
/// ```
///
/// This handler is particularly useful for:
/// - Unit testing HTTP clients
/// - Integration testing without network dependencies
/// - Verifying request/response handling
/// - Testing error scenarios and edge cases
/// </summary>
public class TestMessageHandler : HttpMessageHandler
{
    private readonly Queue<(HttpStatusCode StatusCode, object Content)> _responses = new();
    private readonly List<HttpRequestMessage> _requests = new();

    public IReadOnlyList<HttpRequestMessage> Requests => _requests;

    public void QueueResponse(HttpStatusCode statusCode, object content)
    {
        _responses.Enqueue((statusCode, content));
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        _requests.Add(request);

        if (_responses.Count == 0)
        {
            throw new InvalidOperationException("No responses queued");
        }

        var (statusCode, content) = _responses.Dequeue();
        var response = new HttpResponseMessage(statusCode);

        if (content is string stringContent)
        {
            response.Content = new StringContent(stringContent);
        }
        else
        {
            var json = JsonSerializer.Serialize(content);
            response.Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
        }

        return Task.FromResult(response);
    }
}