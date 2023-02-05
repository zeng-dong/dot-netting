using TestingDomain.Users;

namespace UsingBuilders.Builders;

public class EmployeeOldFashionBuilder : BaseDataBuilder<Employee>
{
    public EmployeeOldFashionBuilder() : base(new Employee())
    {
    }

    public EmployeeOldFashionBuilder(Employee borrower)
        : base(borrower) { }

    public EmployeeOldFashionBuilder WithFirstName(string firstName)
    {
        Result.FirstName = firstName;
        return this;
    }

    public EmployeeOldFashionBuilder WithLastName(string lastName)
    {
        Result.LastName = lastName;
        return this;
    }

    public EmployeeOldFashionBuilder WithBonusRate(decimal bonusRate)
    {
        Result.BonusRate = bonusRate;
        return this;
    }

    public EmployeeOldFashionBuilder WithSalary(int salary)
    {
        Result.Salary = salary;
        return this;
    }

    public EmployeeOldFashionBuilder WithStart(DateTime start)
    {
        Result.Start = start;
        return this;
    }

    public EmployeeOldFashionBuilder WithTitle(string title)
    {
        Result.Title = title;
        return this;
    }
}