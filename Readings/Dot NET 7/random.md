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

public static class StringExtensions
    {
        public static string ToKebabCase(this string str)
        {
            if (string.IsNullOrEmpty(str)) return str;

            Regex pattern = new Regex(@"[A-Z]{2,}(?=[A-Z][a-z]+[0-9]*|\b)|[A-Z]?[a-z]+[0-9]*|[A-Z]|[0-9]+");

            return string.Join("-", pattern.Matches(str)).ToLower();
        }

        public static string ToSnakeCase(this string str)
        {
            if (string.IsNullOrEmpty(str)) return str;
            Regex pattern = new Regex(@"[A-Z]{2,}(?=[A-Z][a-z]+[0-9]*|\b)|[A-Z]?[a-z]+[0-9]*|[A-Z]|[0-9]+");
            return string.Join("_", pattern.Matches(str)).ToLower();
        }

        public static string ToCamelCase(this string str)
        {
            Regex pattern = new Regex(@"[A-Z]{2,}(?=[A-Z][a-z]+[0-9]*|\b)|[A-Z]?[a-z]+[0-9]*|[A-Z]|[0-9]+");
            return new string(
              new CultureInfo("en-US", false)
                .TextInfo
                .ToTitleCase(
                  string.Join(" ", pattern.Matches(str)).ToLower()
                )
                .Replace(@" ", "")
                .Select((x, i) => i == 0 ? char.ToLower(x) : x)
                .ToArray()
            );
        }

        public static string ToPascalCase(this string str)
        {
            Regex pattern = new Regex(@"[A-Z]{2,}(?=[A-Z][a-z]+[0-9]*|\b)|[A-Z]?[a-z]+[0-9]*|[A-Z]|[0-9]+");
            return new string(
              new CultureInfo("en-US", false)
                .TextInfo
                .ToTitleCase(
                  string.Join(" ", pattern.Matches(str)).ToLower()
                )
                .Replace(@" ", "")
                .ToArray()
            );
        }

        public static string FirstCharToUpper(this string input) =>
        input switch
        {
            null => throw new ArgumentNullException(nameof(input)),
            "" => throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input)),
            _ => input.First().ToString().ToUpper() + input.Substring(1)
        };

        public static string ToTitleCase(this string str)
        {
            Regex pattern = new Regex(@"[A-Z]{2,}(?=[A-Z][a-z]+[0-9]*|\b)|[A-Z]?[a-z]+[0-9]*|[A-Z]|[0-9]+");
            return new CultureInfo("en-US", false)
              .TextInfo
              .ToTitleCase(
                string.Join(" ", pattern.Matches(str)).ToLower()
              );

            /*EXAMPLES
_30s.ToTitleCase("some_database_field_name"); // "Some Database Field Name"
_30s.ToTitleCase("Some label that needs to be title-cased"); // "Some Label That Needs To Be Title Cased"
_30s.ToTitleCase("some-package-name"); // "Some Package Name"
_30s.ToTitleCase("some-mixed_string with spaces_underscores-and-hyphens"); // "Some Mixed String With Spaces Underscores And Hyphens"*/
        }

        public static bool Contains(this string source, string toCheck, StringComparison comparison)
        {
            return source?.IndexOf(toCheck, comparison) >= 0;
        }
    }

```

Anonymous test data: data that is required to be present for the test to be able to execute, but where the value itself is unimportant


# [make concurrent requests with HttpClient](https://makolyte.com/csharp-how-to-make-concurrent-requests-with-httpclient/)

[code in github](https://github.com/makolyte/concurrent-requests-with-httpclient)

#zdnote 
This article [How to Execute Multiple Tasks Asynchronously in C#](https://code-maze.com/csharp-execute-multiple-tasks-asynchronously/) may also be good. It has a github repo.

The HttpClient class was designed to be used concurrently. It’s thread-safe and can handle multiple requests. You can fire off multiple requests from the same thread and await all of the responses, or fire off requests from multiple threads. No matter what the scenario, HttpClient was built to handle concurrent requests.

To use HttpClient effectively for concurrent requests, there are a few guidelines:

## Use a single instance of HttpClient.
HttpClient was designed for concurrency. It was meant for the user to only need a single instance to make multiple requests. It reuses sockets for subsequent requests to the same URL instead of allocating a new socket each time.

``` c#
//Don't do this 
using(HttpClient http = new HttpClient()) { 
var response = await http.GetAsync(url); 
//check status, return content 
}
```
It allocates sockets – one for each request. Because HttpClient was disposed, the allocated socket won’t be used again (until the system eventually closes it). This is not only a waste of resources, but can also lead to port exhaustion (more on this later).


## Define the max concurrent requests per URL.
Here’s how you set the max concurrency:

``` c#
private void SetMaxConcurrency(string url, int maxConcurrentRequests) { 	ServicePointManager.FindServicePoint(new Uri(url)).ConnectionLimit = maxConcurrentRequests; }
```

If you don’t explicitly set this, then it uses the ServicePointManager.DefaultConnectionLimit. This is 10 for ASP.NET and two for everything else.

The single HttpClient instance uses the connection limit to determine the max number of sockets it will use concurrently. Think of it as having a request queue. When the number of concurrent requests > max concurrency, the remaining requests wait in a queue until sockets free up.

## Avoid port exhaustion – Don’t use HttpClient as a request queue.


## Only use DefaultRequestHeaders for headers that don’t change.



[HttpPost("categories/{id}/update")]  
public async Task<ActionResult> Update([FromBody] CategoryUpdateDto dto, [FromRoute] Guid id)

