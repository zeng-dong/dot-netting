using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TestingApi.AwardingBonus;
using TestingDomain.Users;

namespace TestingApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BonusesController : ControllerBase
{
    private readonly IHumanResourceService _hrService;
    private readonly IAdminService _adminService;

    public BonusesController(IHumanResourceService humanResourceService, IAdminService adminService)
    {
        _hrService = humanResourceService;
        _adminService = adminService;
    }

    [HttpGet]
    public IActionResult All()
    {
        var employees = _hrService.ThoseDeservingBonus();
        string jsonString = JsonSerializer.Serialize<IList<Employee>>(employees);
        var bonuses = _adminService.GetAll(jsonString);

        return Ok(bonuses);
    }
}