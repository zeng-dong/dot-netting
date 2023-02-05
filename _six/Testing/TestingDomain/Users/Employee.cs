namespace TestingDomain.Users;

public class Employee
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public decimal BonusRate { get; set; }
    public int Salary { get; set; }
    public DateTime Start { get; set; } = DateTime.MinValue;
    public string Title { get; set; } = string.Empty;
}

public class HrManager
{
    public decimal Bonus(Employee employee)
    {
        return employee.BonusRate * employee.Salary;
    }

    public int Years(Employee employee)
    {
        return DateTime.Today.Year - employee.Start.Year;
    }
}