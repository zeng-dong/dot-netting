using TestingDomain;

namespace UsingAutoFixture;

public class IntCalculatorTests
{
    [Fact]
    [Trait("Category", "traditional")]
    [Trait("IntCalculator", "op")]
    public void Can_sub()
    {
        var calculator = new IntCalculator();

        var toBeSubtracted = 1;
        calculator.Subtract(toBeSubtracted);

        calculator.Value.Should().BeLessThan(0);
    }

    [Fact]
    [Trait("Category", "fixture")]
    [Trait("IntCalculator", "op")]
    public void Can_sub_fixture_style()
    {
        var calculator = new IntCalculator();
        var fixture = new Fixture();
        var toBeSubtracted = fixture.Create<int>();

        calculator.Subtract(toBeSubtracted);

        calculator.Value.Should().BeLessThan(0);
    }
}