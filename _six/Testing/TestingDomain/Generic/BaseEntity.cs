﻿namespace TestingDomain.Generic;

public abstract class Entity
{
    public virtual string? Id { get; protected set; }

    public Entity(string id)
    {
        Id = id;
    }

    public override bool Equals(object obj)
    {
        if (obj is not Entity other)
            return false;

        if (ReferenceEquals(this, other))
            return true;

        return Id.Equals(other.Id);
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
}