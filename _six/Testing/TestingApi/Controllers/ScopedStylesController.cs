using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TestingApi.AwardingBonus;
using TestingDomain.Users;

namespace TestingApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ScopedStylesController : ControllerBase
{
    private readonly IHumanResourceService _hrService;
    private const decimal GainShare = 0.25m;

    public ScopedStylesController(IHumanResourceService humanResourceService)
    {
        _hrService = humanResourceService;
    }

    [HttpGet("Original")]
    public IActionResult List()
    {
        var localEmployees = _hrService.ThoseDeservingBonus();
        var localEmployeeBonus = new List<EmployeeBonusApiModel>();

        foreach (var employee in localEmployees)
        {
            localEmployeeBonus.Add(GetEmployeeBonus(employee, GainShare));
        }

        return Ok(localEmployeeBonus);
    }

    [HttpGet("Change")]
    public IActionResult TreatPeopleWell()
    {
        var localEmployees = _hrService.ThoseDeservingBonus();
        var localEmployeeBonus = new List<EmployeeBonusApiModel>();

        foreach (var employee in localEmployees)
        {
            if (employee.FirstName == "Mike" && employee.LastName == "Miller")
            {
                var hisRate = GainShare * 2;
                localEmployeeBonus.Add(GetEmployeeBonus(employee, hisRate));
            }
            else
                localEmployeeBonus.Add(GetEmployeeBonus(employee, GainShare));
        }

        return Ok(localEmployeeBonus);
    }

    private EmployeeBonusApiModel GetEmployeeBonus(Employee employee, decimal rate)
    {
        return new EmployeeBonusApiModel
        {
            Name = $"{employee.FirstName} {employee.LastName}",
            Bonus = employee.Salary * rate
        };
    }
}