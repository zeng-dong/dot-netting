using System.Diagnostics.CodeAnalysis;

namespace TestingDomain.Objects;

public class TermEqualityComparer : IEqualityComparer<TermEqualityComparer>
{
    public bool Equals(TermEqualityComparer? x, TermEqualityComparer? y)
    {
        throw new NotImplementedException();
    }

    public int GetHashCode([DisallowNull] TermEqualityComparer obj)
    {
        throw new NotImplementedException();
    }
}

public sealed class TermEquatable : IEquatable<TermEquatable>
{
    public bool Equals(TermEquatable? other)
    {
        throw new NotImplementedException();
    }

    public override bool Equals(object? obj)
    {
        if (obj == null) { return false; }

        return Equals(obj as TermEquatable);
    }

    public override int GetHashCode()
    {
        throw new NotImplementedException();
    }
}