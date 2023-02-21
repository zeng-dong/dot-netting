namespace TestingDomain.NestedServices;

public interface IBlobService
{
    int Do(ISupporting1 service1, ISupporting2 service2, string name);
}

public interface ISupporting1
{
    int Do();
}

public interface ISupporting2
{
    bool Do();
}

public class BlobService : IBlobService
{
    public int Do(ISupporting1 service1, ISupporting2 service2, string name)
    {
        var x = service1.Do();
        if (x < 10) { return 201; }

        if (x < 100) { return 401; }

        if (x < 1000) { return 501; }

        return 999;
    }
}