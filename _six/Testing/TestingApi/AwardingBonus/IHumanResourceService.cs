using TestingDomain.Users;

namespace TestingApi.AwardingBonus;

public interface IHumanResourceService
{
    IList<Employee> ThoseDeservingBonus();
}

public class HumanResourceService : IHumanResourceService
{
    public IList<Employee> ThoseDeservingBonus()
    {
        throw new NotImplementedException();
    }
}