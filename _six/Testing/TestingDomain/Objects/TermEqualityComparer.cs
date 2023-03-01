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

public class TermEquatable : IEquatable<TermEquatable>
{
    public bool Equals(TermEquatable? other)
    {
        throw new NotImplementedException();
    }
}