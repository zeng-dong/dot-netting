namespace Concepts.Entity.DongZengInFreshbyte;

public interface IDomainEvent
{
    public DateTime Timestamp { get; }
}

public record DomainEvent : IDomainEvent
{
    public DateTime Timestamp { get; } = Clock.Now;
}

public static class Clock
{
    static Func<DateTime> _nowGetter = () => DateTime.UtcNow;
    public static DateTime Now => _nowGetter.Invoke();

    public static void SetNowGetter(Func<DateTime> getter)
    {
        _nowGetter = getter;
    }
}