namespace UsingAutoFixture;

public class IntCalculatorTests
{
    [Fact]
    public void Can_sub()
    {
        var calculator = new IntCalculator();

        calculator.Subtract(1);

        calculator.Value.Should().BeLessThan(0);
    }
}