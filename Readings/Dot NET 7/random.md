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


# [make concurrent requests with HttpClient](https://makolyte.com/csharp-how-to-make-concurrent-requests-with-httpclient/)

The HttpClient class was designed to be used concurrently. It’s thread-safe and can handle multiple requests. You can fire off multiple requests from the same thread and await all of the responses, or fire off requests from multiple threads. No matter what the scenario, HttpClient was built to handle concurrent requests.

To use HttpClient effectively for concurrent requests, there are a few guidelines:

## Use a single instance of HttpClient.


## Define the max concurrent requests per URL.

## Avoid port exhaustion – Don’t use HttpClient as a request queue.


## Only use DefaultRequestHeaders for headers that don’t change.