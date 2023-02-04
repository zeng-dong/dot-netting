```c#
public abstract class BaseDataBuilder<T> where T: class
    {
        protected T Result { get; set; }

        protected BaseDataBuilder(T entity)
        {
            Result = entity;
        }

        public virtual T Build() => Result;
    }
```

Anonymous test data: data that is required to be present for the test to be able to execute, but where the value itself is unimportant