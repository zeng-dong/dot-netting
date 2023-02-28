using TestingDomain.Users;
using Xunit.Abstractions;

namespace UsingBuilders;

public class UsingLinqGroupByOrderBy
{
    [Fact]
    public void Test()
    {
        var employees = new List<Employee>();
        employees.Add(new Employee { Title = "5044-01", LastName = "L1", Salary = 100 });
        employees.Add(new Employee { Title = "5044-01", LastName = "L2", Salary = 200 });
        employees.Add(new Employee { Title = "5044-01", LastName = "L3", Salary = 300 });
        employees.Add(new Employee { Title = "5044-02", LastName = "L4", Salary = 900 });
        employees.Add(new Employee { Title = "5044-02", LastName = "L5", Salary = 1000 });
        employees.Add(new Employee { Title = "5044-02", LastName = "L6", Salary = 1000 });
        employees.Add(new Employee { Title = "5044-03", LastName = "L7", Salary = 100 });
        employees.Add(new Employee { Title = "5044-03", LastName = "L8", Salary = 100 });

        var firts = employees.GroupBy(x => x.Title, (key, g) => g.OrderByDescending(e => e.Salary).First()).ToList();

        firts.ForEach(f => _output.WriteLine($"{f.Title} - {f.Salary}, {f.LastName}"));
    }

    private readonly ITestOutputHelper _output;

    public UsingLinqGroupByOrderBy(ITestOutputHelper testOutputHelper)
    {
        _output = testOutputHelper;
    }
}