namespace Concepts.Entity.Codewinkels;

public class Entity<Tid> : IEquatable<Entity<Tid>>
{
    public Tid Id { get; }

    protected Entity(Tid id)
    {
        if (!IsValid(id)) throw new ArgumentException("Identifier is not in supported format");
        Id = id;
    }

    public override bool Equals(object obj)
    {
        if (obj == null) return false;
        return Equals(obj as Entity<Tid>);
    }

    public bool Equals(Entity<Tid> other)
    {
        return Id.GetHashCode() == other.Id.GetHashCode();
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public static bool operator ==(Entity<Tid> lhs, Entity<Tid> rhs)
    {
        return lhs.Equals(rhs);
    }

    public static bool operator !=(Entity<Tid> lhs, Entity<Tid> rhs)
    {
        return !(lhs == rhs);
    }

    private bool IsValid(Tid? id)
    {
        return id is int || id is long || id is Guid;
    }
}