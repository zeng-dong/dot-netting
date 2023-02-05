namespace TestingDomain.Users;

public class User
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? MiddleName { get; set; }
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}