using Microsoft.Extensions.Options;

namespace TestingDomain.Options;

public class SampleRepository : ISampleRepository
{
    private readonly SampleOptions _options;

    public SampleRepository(IOptions<SampleOptions> options)
    {
        _options = options.Value;
    }

    public async Task<bool> Get()
    {
        return await Task.FromResult(true);
    }

    public string OptionDetail()
    {
        if (_options.ConnStr is null)
        {
            throw new ArgumentException("no, not good");
        }

        return $"The IOption I have is: {_options.ConnStr}, {_options.PriceTier}";
    }
}