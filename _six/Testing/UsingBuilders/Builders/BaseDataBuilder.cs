namespace UsingBuilders.Builders;

public abstract class BaseDataBuilder<T> where T : class
{
    protected T Result { get; set; }

    protected BaseDataBuilder(T entity)
    {
        Result = entity;
    }

    public virtual T Build() => Result;
}
