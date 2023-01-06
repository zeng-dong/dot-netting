namespace Concepts.Entity.DongZengInFreshbyte;

public interface IEntity
{
    void AddEvent(IDomainEvent @event);

    IEnumerable<IDomainEvent> GetEvents();

    void ClearEvents();

    Guid Id { get; set; }
}

public abstract class Entity : IEntity
{
    public Guid Id { get; set; }
    protected virtual object Actual => this;
    ICollection<IDomainEvent> Events { get; } = new List<IDomainEvent>();

    public override bool Equals(object obj)
    {
        var other = obj as Entity;

        if (other is null)
            return false;

        if (ReferenceEquals(this, other))
            return true;

        if (Actual.GetType() != other.Actual.GetType())
            return false;

        if (Id == Guid.Empty || other.Id == Guid.Empty)
            return false;

        return Id == other.Id;
    }

    public static bool operator ==(Entity a, Entity b)
    {
        if (a is null && b is null)
            return true;

        if (a is null || b is null)
            return false;

        return a.Equals(b);
    }

    public static bool operator !=(Entity a, Entity b)
    {
        return !(a == b);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public object Clone()
    {
        return MemberwiseClone();
    }

    public void AddEvent(IDomainEvent @event)
    {
        Events.Add(@event);
        EventAdded(@event);
    }

    protected virtual void EventAdded(IDomainEvent @event)
    {
    }

    public IEnumerable<IDomainEvent> GetEvents()
    {
        return Events.OrderBy(_ => _.Timestamp);
    }

    public void ClearEvents()
    {
        Events.Clear();
    }
}