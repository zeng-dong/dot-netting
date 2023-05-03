using Bogus;
using TestingDomain.Users;

namespace TestingApi.AwardingBonus;

public interface IHumanResourceService
{
    IList<Employee> ThoseDeservingBonus();
}

public class HumanResourceService : IHumanResourceService
{
    static readonly List<string> Names = new() { "Mike", "Anthony", "Ryan" };

    public IList<Employee> ThoseDeservingBonus()
    {
        var employees = new List<Employee>();
        Names.ForEach(n =>
        {
            employees.Add(new Employee() { FirstName = n, LastName = "Miller" });
        });
        var faker = new Faker<Employee>()
            .RuleFor(o => o.FirstName, f => f.Name.FirstName())
            .RuleFor(o => o.LastName, f => f.Name.LastName());
        employees.AddRange(faker.Generate(50));

        return employees;
    }
}