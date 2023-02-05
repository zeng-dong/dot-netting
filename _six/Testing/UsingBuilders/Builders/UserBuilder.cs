using TestingDomain.Users;
using BuilderGenerator;

namespace UsingBuilders.Builders;

[BuilderFor(typeof(User))]
public partial class UserBuilder
{
    public static UserBuilder Simple()
    {
        var builder = new UserBuilder()
            .WithFirstName(Guid.NewGuid().ToString())

            .WithOrders(new List<Order>())

            .WithLastName(Guid.NewGuid().ToString());

        return builder;
    }
}