using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TestingApi.AwardingBonus;
using TestingDomain.Users;

namespace TestingApi.Controllers;

[ApiController]
[Route("[controller]")]
public class DxStyleGlobalsController : ControllerBase
{
    private readonly IHumanResourceService _hrService;
    private decimal _globalRate;
    private IList<Employee> _globalEmployees;
    private List<EmployeeBonusApiModel> _globalEmployeeBonus = new();
    private const decimal GainShare = 0.25m;
    private EmployeeBonusApiModel _miller;

    public DxStyleGlobalsController(IHumanResourceService humanResourceService)
    {
        _hrService = humanResourceService;
    }

    [HttpGet("add")]
    public IActionResult Add(int a, int b)
    {
        return Ok(MyVeryComplexOperation(a, b));
    }

    private static int MyVeryComplexOperation(int a, int b)
    {
        /// 7000 lines of algorithm goes here.
        return a + b;
    }

    [HttpGet("Original")]
    public IActionResult List()
    {
        SetRate();
        GetEmployees();
        foreach (var employee in _globalEmployees)
        {
            _globalEmployeeBonus.Add(GetEmployeeBonus(employee));
        }

        return Ok(_globalEmployeeBonus);
    }

    [HttpGet("Change")]
    public IActionResult TreatPeopleWell()
    {
        SetRate();
        GetEmployees();

        RevisitSpecialCases();
        _globalEmployeeBonus.Add(_miller);

        foreach (var employee in _globalEmployees)
        {
            if (employee.FirstName == "Mike" && employee.LastName == "Miller") continue;
            _globalEmployeeBonus.Add(GetEmployeeBonus(employee));
        }

        return Ok(_globalEmployeeBonus);
    }

    private void RevisitSpecialCases()
    {
        SetMillerRate();
        _miller = GetEmployeeBonus(_globalEmployees.First(x => x.FirstName == "Mike" && x.LastName == "Miller"));
    }

    private void SetMillerRate()
    {
        _globalRate = GainShare * 2;
    }

    private void SetRate()
    {
        _globalRate = GainShare;
    }

    private void GetEmployees()
    {
        _globalEmployees = _hrService.ThoseDeservingBonus();
    }

    private EmployeeBonusApiModel GetEmployeeBonus(Employee employee)
    {
        return new EmployeeBonusApiModel
        {
            Name = $"{employee.FirstName} {employee.LastName}",
            Bonus = employee.Salary * _globalRate
        };
    }
}

public class EmployeeBonusApiModel
{
    public string Name { get; set; }
    public decimal Bonus { get; set; }
}