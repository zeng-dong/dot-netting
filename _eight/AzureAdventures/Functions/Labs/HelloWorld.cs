using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Functions.Labs
{
    public class HelloWorld
    {
        private readonly ILogger<HelloWorld> _logger;

        public HelloWorld(ILogger<HelloWorld> logger)
        {
            _logger = logger;
        }

        [Function("HelloWorld_from_boo")]
        public IActionResult Boo([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("HTTP triggered boo.");
            return new OkObjectResult("Hello world from boo");
        }

        [Function("ReadingFromRequest")]
        public async Task<HttpResponseData> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "ReadingFromRequest/{name}")]
            HttpRequestData req,
            string name)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            _logger.LogInformation(name);
            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
            await response.WriteStringAsync("Hello you entered: " + name);
            return response;
        }
    }
}