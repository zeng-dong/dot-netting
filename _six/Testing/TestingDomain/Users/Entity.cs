namespace TestingDomain.Users;

public abstract class Entity
{
    public Guid Id { get; set; }

    // The Builders should only expose this in builder classes where the attribute has enabled it
    internal string InternalString { get; set; }
}

public abstract class AuditableEntity : Entity
{
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string UpdatedBy { get; set; }
}

public class User : AuditableEntity
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? MiddleName { get; set; }
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}

public class Order : AuditableEntity
{
    public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
    public DateTime OrderDate { get; set; }
    public ICollection<OrderItem> Orders { get; set; } = new List<OrderItem>();
    public OrderStatus Status { get; set; }
}