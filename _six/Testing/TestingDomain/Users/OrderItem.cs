namespace TestingDomain.Users;

public class OrderItem : AuditableEntity
{
    public Guid ItemId { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}