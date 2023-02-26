using System.Net;
using System.Text.Json;

namespace TestingApi;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception error)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            string message;
            switch (error)
            {
                case InvalidOperationException e:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    message = e.Message;
                    break;

                case ArgumentException e:
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    message = e.Message;
                    break;

                default:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    message = $"Unexpected exception. {error?.Message}";
                    break;
            }

            await response.WriteAsync(JsonSerializer.Serialize(new { message }));
        }
    }
}

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder AddCommonExceptionsHandler(this IApplicationBuilder applicationBuilder)
        => applicationBuilder.UseMiddleware<ExceptionHandlingMiddleware>();
}