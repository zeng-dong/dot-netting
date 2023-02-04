namespace UsingAutoFixture;

public class IntCalculatorTests
{
    [Fact]
    [Trait("Category", "traditional")]
    public void Can_sub()
    {
        var calculator = new IntCalculator();

        var toBeSubtracted = 1;
        calculator.Subtract(toBeSubtracted);

        calculator.Value.Should().BeLessThan(0);
    }

    [Fact]
    [Trait("Category", "fixture")]
    public void Can_sub_fixture_style()
    {
        var calculator = new IntCalculator();
        var fixture = new Fixture();
        var toBeSubtracted = fixture.Create<int>();

        calculator.Subtract(toBeSubtracted);

        calculator.Value.Should().BeLessThan(0);
    }
}