using FluentAssertions;
using Moq;
using TestingDomain.NestedServices;

namespace UsingBuilders;

public class MultipleReturnValuesFromMockTests
{
    [Fact]
    public void Mock_multiple_values()
    {
        Mock<ISupporting1> service1 = new Mock<ISupporting1>();
        Mock<ISupporting2> service2 = new Mock<ISupporting2>();

        service1
            .SetupSequence(x => x.Do())
            .Returns(true)
            .Returns(false);

        service2
            .Setup(x => x.Do())
            .Returns(true);

        BlobService sut = new BlobService();
        var callItFirstTime = sut.Do(service1.Object, service2.Object, "hello");
        var callItSecondTime = sut.Do(service1.Object, service2.Object, "hello");
        var callItThirdTime = sut.Do(service1.Object, service2.Object, "hello");

        callItFirstTime.Should().Be(201);
        callItSecondTime.Should().Be(401);
        callItThirdTime.Should().Be(202);
    }
}