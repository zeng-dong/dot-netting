using System.Text.Json;

namespace TestingApi.AwardingBonus;

public class EmployeeBonusReport
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Bonus { get; set; } = 0;
}

public interface IAdminService
{
    IList<EmployeeBonusReport> GetAll(string jsonEmployees);
}

public class AdminService : IAdminService
{
    public IList<EmployeeBonusReport> GetAll(string jsonEmployees)
    {
        var employees = JsonSerializer.Deserialize<List<EmployeeBonusReport>>(jsonEmployees);

        employees.ForEach(e => e.Bonus = 100);

        return employees;
    }
}