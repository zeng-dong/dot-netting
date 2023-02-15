using FluentAssertions;
using Microsoft.Extensions.Options;
using TestingDomain.Options;

namespace UsingBuilders;

public class SampleRepositoryTests
{
    private readonly IOptions<SampleOptions> _options;
    private readonly SampleRepository _repo;

    public SampleRepositoryTests()
    {
        _options = Options.Create<SampleOptions>(new SampleOptions() { FirstSetting = "AzureBlobSuperSecret", SecondSetting = 98765 });

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
}