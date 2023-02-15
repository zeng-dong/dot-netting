using FluentAssertions;
using Microsoft.Extensions.Options;
using Moq;
using TestingDomain.Options;

namespace UsingBuilders;

public class SampleRepositoryTests
{
    private IOptions<SampleOptions> _options;
    private SampleRepository _repo;

    public SampleRepositoryTests()
    {
        _options = Options.Create<SampleOptions>(new() { ConnStr = "AzureBlobSuperSecret", PriceTier = 98765 });

        _repo = new(_options);
    }

    [Fact]
    public void It_returns_true()
    {
        var result = _repo.Get().Result;
        result.Should().BeTrue();
    }

    [Fact]
    public void It_returns_options_detail()
    {
        var result = _repo.OptionDetail();
        result.Should().Be("The IOption I have is: AzureBlobSuperSecret, 98765");
    }

    [Fact]
    public void I_can_reset_options()
    {
        _options = Options.Create<SampleOptions>(new() { ConnStr = null, PriceTier = 98765 });
        _repo = new(_options);

        var result = () => _repo.OptionDetail();

        result.Should().Throw<ArgumentException>().WithMessage("no, not good");
    }

    [Fact]
    public void I_can_mock_the_ioptions_interface()
    {
        var opt = new SampleOptions() { ConnStr = "This is mocking the builder thing I talked about", PriceTier = 999 };
        var ioptions = new Mock<IOptions<SampleOptions>>();
        ioptions.Setup(x => x.Value).Returns(opt);

        var rep = new SampleRepository(ioptions.Object);

        var result = rep.OptionDetail();
        result.Should().Be("The IOption I have is: This is mocking the builder thing I talked about, 999");
    }
}