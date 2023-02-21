namespace TestingDomain.NestedServices;

public interface IBlobService
{
    int Do(ISupporting1 service1, ISupporting2 service2, string name);
}

public interface ISupporting1
{
    bool Do();
}

public interface ISupporting2
{
    bool Do();
}

public class BlobService : IBlobService
{
    public int Do(ISupporting1 service1, ISupporting2 service2, string name)
    {
        if (service1.Do()) { return 201; }

        if (!service1.Do()) { return 401; }

        if (service2.Do()) { return 202; }

        return 999;
    }
}