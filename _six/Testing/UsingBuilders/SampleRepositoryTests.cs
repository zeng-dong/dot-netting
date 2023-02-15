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
        _options = Options.Create<SampleOptions>(new SampleOptions());

        _repo = new(_options);
    }

    [Fact]
    public void It_returns_true()
    {
        var result = _repo.Get().Result;
        result.Should().BeTrue();
    }
}