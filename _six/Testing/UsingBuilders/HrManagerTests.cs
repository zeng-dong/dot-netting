using FluentAssertions;
using TestingDomain.Users;
using UsingBuilders.Builders;

namespace UsingBuilders;

public class HrManagerTests
{
    [Fact]
    public void Hr_manager_knows_employee_bonus()
    {
        var dell = EmployeeBuilder.CeoBuilder;

        var expected = 5000000 * 100;

        var result = _manager.Bonus(dell.Invoke().Build());

        result.Should().Be(expected);
    }

    [Fact]
    public void Hr_manager_knows_employee_bonus_this_time_much_more_readable()
    {
        var dell = _builder
            .WithSalary(5000000)
            .WithBonusRate(100)
            .Build();

        var expected = 5000000 * 100;

        var result = _manager.Bonus(dell);

        result.Should().Be(expected);
    }

    [Fact]
    public void Hr_manager_knows_employee_years()
    {
        var dell = _builder
            .WithStart(DateTime.Now.AddYears(-6))
            .Build();

        var expected = 6;

        var result = _manager.Years(dell);

        result.Should().Be(expected);
    }

    [Fact]
    public void Hr_manager_knows_employee_years_using_old_fashioned_builder()
    {
        var years = 8;
        var dell = new EmployeeOldFashionBuilder()
            .WithStart(DateTime.Now.AddYears(-years))
            .Build();

        var result = _manager.Years(dell);

        result.Should().Be(years);
    }

    public HrManagerTests()
    {
        _builder = new EmployeeBuilder();
        _manager = new HrManager();
    }

    private readonly EmployeeBuilder _builder;
    private readonly HrManager _manager;
}