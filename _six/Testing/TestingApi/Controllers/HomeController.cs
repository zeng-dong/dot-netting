using Microsoft.AspNetCore.Mvc;

namespace TestingApi.Controllers;

[ApiController]
[Route("[controller]")]

public class HomeController : ControllerBase
{
    [HttpGet]
    public IActionResult Index([FromQuery] string name)
    {
        if (name == null) { throw new ArgumentNullException("name"); }

        if (name == "null") { throw new ArgumentException("null cannot be hello"); }

        return Ok($"Hello {name}");
    }
}