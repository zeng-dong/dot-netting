using FluentAssertions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingApi;

namespace UsingBuilders;

public class ExceptionHandlingMiddlewareTests
{
    [Fact]
    public void test_500()
    {
        RequestDelegate next = (HttpContext httpContext) =>
        {
            //   httpContext.Response.WriteAsync("");
            return Task.FromException(new DivideByZeroException("xyz"));
        };

        var middleware = new ExceptionHandlingMiddleware(next);

        var httpContext = new DefaultHttpContext();
        httpContext.Response.Body = new MemoryStream();
        /*
         To the rescue for this, we have DefaultHttpContext. Nothing to mock, saved from messing up with login information, it’s there waiting to be used. The only thing to keep in mind is the Response.Body property. The Response.Body stream in DefaultHttpContext is Stream.Null, which is a stream that just ignores all reads/writes. No exceptions, no nothing if you use it, just a “talk to the hand” attitude! Solution of course, to setup the Stream ourselves before calling the method:

var context = new DefaultHttpContext();
context.Response.Body = new MemoryStream();
         */

        var r = middleware.InvokeAsync(httpContext);

        var x = httpContext.Response;

        //var originalBodyStream = x.Body;

        //try
        //{
        //    using var memoryStream = new MemoryStream();
        //    x.Body = memoryStream;

        //    ///next(httpContext);

        //    memoryStream.Position = 0;
        //    var reader = new StreamReader(memoryStream);
        //    var responseBody = reader.ReadToEndAsync().Result;

        //    memoryStream.Position = 0;
        //    memoryStream.CopyToAsync(originalBodyStream).Wait();
        //}
        //finally
        //{
        //    x.Body = originalBodyStream;
        //}

        x.Body.Seek(0, SeekOrigin.Begin);

        string text = new StreamReader(x.Body).ReadToEnd(); // Async().Result;

        text.Should().Contain("Unexpected");

        x.StatusCode.Should().Be(500);
    }

    [Fact]
    public void Message_and_500()
    {
        var middleware = new ExceptionHandlingMiddleware(
            next: (innerHttpContext) =>
            {
                innerHttpContext.Response.WriteAsync("");
                return Task.FromException(new DivideByZeroException("xyz"));
            }
        );

        var context = new DefaultHttpContext();
        context.Response.Body = new MemoryStream();

        middleware.InvokeAsync(context).Wait();

        context.Response.Body.Seek(0, SeekOrigin.Begin);
        var body = new StreamReader(context.Response.Body).ReadToEnd();

        //'en' seems OK for me as the default

        var expectedErrorMessage = "{\"message\":\"Unexpected exception. xyz\"}";
        context.Response.StatusCode.Should().Be(500);
        body.Should().Contain(expectedErrorMessage);
    }

    [Fact]
    public void RequestCultureMiddleware_DefaultBehaviour()
    {
        var middleware = new ExceptionHandlingMiddleware(
            next: (innerHttpContext) =>
            {
                innerHttpContext.Response.WriteAsync("{'message': 'xyz'}");
                return Task.CompletedTask;
            }
        );

        var context = new DefaultHttpContext();
        context.Response.Body = new MemoryStream();

        middleware.InvokeAsync(context).Wait();

        context.Response.Body.Seek(0, SeekOrigin.Begin);
        var body = new StreamReader(context.Response.Body).ReadToEnd();

        //'en' seems OK for me as the default

        body.Should().Be("xyz");
    }

    [Fact]
    public void test_400()
    {
        var httpContext = new DefaultHttpContext();
        RequestDelegate next = (HttpContext httpContext) => Task.FromException(new InvalidOperationException("xyz"));

        var middleware = new ExceptionHandlingMiddleware(next);

        middleware.InvokeAsync(httpContext);

        var x = httpContext.Response;
        x.StatusCode.Should().Be(400);
    }

    [Fact]
    public void test_404()
    {
        var httpContext = new DefaultHttpContext();
        RequestDelegate next = (HttpContext httpContext) => Task.FromException(new ArgumentException("xyz"));

        var middleware = new ExceptionHandlingMiddleware(next);

        middleware.InvokeAsync(httpContext);

        var x = httpContext.Response;
        x.StatusCode.Should().Be(404);
    }
}