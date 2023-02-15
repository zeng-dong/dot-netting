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
        return $"The IOption I have is: {_options.FirstSetting}, {_options.SecondSetting}";
    }
}