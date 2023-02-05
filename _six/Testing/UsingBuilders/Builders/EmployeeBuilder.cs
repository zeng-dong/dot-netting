using BuilderGenerator;
using TestingDomain.Users;

namespace UsingBuilders.Builders;

public partial class EmployeeBuilder
{
    public static EmployeeBuilder CeoBuilder()
    {
        var builder = new EmployeeBuilder()
            .WithFirstName("Michael")
            .WithBonusRate(100)
            .WithLastName("Dell")
            .WithSalary(5000000)
            .WithTitle("CEO")
            .WithStart(new DateTime(1, 1, 1990));

        return builder;
    }

    public static EmployeeBuilder JoeBuilder()
    {
        var builder = new EmployeeBuilder()
            .WithFirstName("John")
            .WithBonusRate(0.15m)
            .WithLastName("Doe")
            .WithSalary(50000)
            .WithTitle("HR Consult")
            .WithStart(new DateTime(1, 1, 2020));

        return builder;
    }
}

public partial class EmployeeBuilder : BuilderGenerator.Builder<TestingDomain.Users.Employee>
{
    public System.Lazy<decimal> BonusRate = new System.Lazy<decimal>(() => default(decimal));
    public System.Lazy<string> FirstName = new System.Lazy<string>(() => default(string));
    public System.Lazy<string> LastName = new System.Lazy<string>(() => default(string));
    public System.Lazy<int> Salary = new System.Lazy<int>(() => default(int));
    public System.Lazy<System.DateTime> Start = new System.Lazy<System.DateTime>(() => default(System.DateTime));
    public System.Lazy<string> Title = new System.Lazy<string>(() => default(string));

    public override TestingDomain.Users.Employee Build()
    {
        if (Object?.IsValueCreated != true)
        {
            Object = new System.Lazy<TestingDomain.Users.Employee>(() =>
            {
                var result = new TestingDomain.Users.Employee
                {
                    BonusRate = BonusRate.Value,
                    FirstName = FirstName.Value,
                    LastName = LastName.Value,
                    Salary = Salary.Value,
                    Start = Start.Value,
                    Title = Title.Value,
                };

                return result;
            });

            PostProcess(Object.Value);
        }

        return Object.Value;
    }

    public EmployeeBuilder WithBonusRate(decimal value)
    {
        return WithBonusRate(() => value);
    }

    public EmployeeBuilder WithBonusRate(System.Func<decimal> func)
    {
        BonusRate = new System.Lazy<decimal>(func);
        return this;
    }

    public EmployeeBuilder WithoutBonusRate()
    {
        BonusRate = new System.Lazy<decimal>(() => default(decimal));
        return this;
    }

    public EmployeeBuilder WithFirstName(string value)
    {
        return WithFirstName(() => value);
    }

    public EmployeeBuilder WithFirstName(System.Func<string> func)
    {
        FirstName = new System.Lazy<string>(func);
        return this;
    }

    public EmployeeBuilder WithoutFirstName()
    {
        FirstName = new System.Lazy<string>(() => default(string));
        return this;
    }

    public EmployeeBuilder WithLastName(string value)
    {
        return WithLastName(() => value);
    }

    public EmployeeBuilder WithLastName(System.Func<string> func)
    {
        LastName = new System.Lazy<string>(func);
        return this;
    }

    public EmployeeBuilder WithoutLastName()
    {
        LastName = new System.Lazy<string>(() => default(string));
        return this;
    }

    public EmployeeBuilder WithSalary(int value)
    {
        return WithSalary(() => value);
    }

    public EmployeeBuilder WithSalary(System.Func<int> func)
    {
        Salary = new System.Lazy<int>(func);
        return this;
    }

    public EmployeeBuilder WithoutSalary()
    {
        Salary = new System.Lazy<int>(() => default(int));
        return this;
    }

    public EmployeeBuilder WithStart(System.DateTime value)
    {
        return WithStart(() => value);
    }

    public EmployeeBuilder WithStart(System.Func<System.DateTime> func)
    {
        Start = new System.Lazy<System.DateTime>(func);
        return this;
    }

    public EmployeeBuilder WithoutStart()
    {
        Start = new System.Lazy<System.DateTime>(() => default(System.DateTime));
        return this;
    }

    public EmployeeBuilder WithTitle(string value)
    {
        return WithTitle(() => value);
    }

    public EmployeeBuilder WithTitle(System.Func<string> func)
    {
        Title = new System.Lazy<string>(func);
        return this;
    }

    public EmployeeBuilder WithoutTitle()
    {
        Title = new System.Lazy<string>(() => default(string));
        return this;
    }
}