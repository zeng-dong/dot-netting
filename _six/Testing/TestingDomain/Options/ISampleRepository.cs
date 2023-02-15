namespace TestingDomain.Options;

public interface ISampleService
{
    Task<bool> Get();

    string OptionDetail();
}