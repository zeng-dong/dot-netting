using Microsoft.AspNetCore.Mvc;
using TestingApi.AwardingBonus;

namespace TestingApi.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly IHumanResourceService _hrService;

    public EmployeesController(IHumanResourceService humanResourceService)
    {
        _hrService = humanResourceService;
    }

    [HttpGet]
    public IActionResult Deservings()
    {
        return Ok(_hrService.ThoseDeservingBonus());
    }
}