using AutoFixture;
using TestingDomain.Users;
using Xunit.Abstractions;

namespace UsingAutoFixture;

public class EmployeeTests
{
    private readonly Fixture _fixture;
    private readonly ITestOutputHelper _output;

    [Fact]
    public void Employee_bonus()
    {
        var dell = _fixture.Build<Employee>()
            .OmitAutoProperties()
            .With(x => x.Salary, 60000)
            .With(x => x.BonusRate, 0.2m)
            .Create();

        var result = new HrManager().Bonus(dell);

        _output.WriteLine($"bonus: {result}");
        result.Should().Be(12000);
    }

    public EmployeeTests(ITestOutputHelper output)
    {
        _fixture = new Fixture();
        _output = output;
    }
}