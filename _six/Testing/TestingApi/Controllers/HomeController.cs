using Microsoft.AspNetCore.Mvc;

namespace TestingApi.Controllers;

[ApiController]
[Route("[controller]")]

public class HomeController : ControllerBase
{
    [HttpGet]
    public IActionResult Index([FromQuery] string name)
    {
        if (name == "hello") { throw new InvalidOperationException("Cannot apply hello to hello"); }

        if (name == "null") { throw new ArgumentException("null cannot be hello"); }

        return Ok($"Hello {name}");
    }
}