namespace TestingDomain.Options;

public interface ISampleRepository
{
    Task<bool> Get();
}