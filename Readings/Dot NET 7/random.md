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

public class BorrowerBuilder : BaseDataBuilder<Borrower>
    {
        public BorrowerBuilder() : base(new Borrower()) { }

        public BorrowerBuilder(Borrower borrower)
            : base(borrower) { }

        public BorrowerBuilder WithBorrowerItpSettingId(long borrowerItpSettingId)
        {
            Result.BorrowerItpSettingId = borrowerItpSettingId;
            return this;
        }
    }
```

Anonymous test data: data that is required to be present for the test to be able to execute, but where the value itself is unimportant