using Microsoft.AspNetCore.Mvc;

namespace TestingApi.Controllers;

[ApiController]
[Route("[controller]")]

public class HomeController : ControllerBase
{
    [HttpGet]
    public IActionResult Index([FromQuery] string name)
    {
        string? x = null;
        ArgumentNullException.ThrowIfNull(x);

        if (name == "hello") { throw new InvalidOperationException("Cannot apply hello to hello"); }

        if (name == "null") { throw new ArgumentException("null cannot be hello"); }

        if (name.StartsWith("bad")) { throw new DivideByZeroException(nameof(name)); }

        return Ok($"Hello {name}");
    }
}