using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concepts.Entity.Codewinkels;

public class Entity<Tid> : IEquatable<Entity<Tid>>
{
    protected Entity(Tid id)
    {
        if (!IsValid(id)) throw new ArgumentException("Identifier is not in supported format");
        Id = id;
    }

    public Tid Id { get; }

    public override bool Equals(object obj)
    {
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