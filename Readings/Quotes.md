> One of the critical pieces of DDD is to encourage better interaction with domain experts. These are the people who live and breed the business or process or whatever you are targeting with the software you're planning to write. You may be thinking, but we already talked to them. 


> Probably you're using your terms, not theirs, and maybe talking in the language of tables in a database rather than domain concepts. 
> 	> After our own history in the business of developing software, we know that that rarely ends well        - Steve Smith


> Developers are drqwn to complexity like moths to a flame, often with the same outcome.  - Neal Ford

> Complex systems will evolve from simple systems much more rapidly if there are stable intermidiate forms than if there are not.  - Herber Simon

> There is no work like early work.
> Clear as you go.
> Muddle makes more muddle.
> Not to wash plates and dishes soon after using makes more work.
> 
>   [Book of household management] - Isabella Beeton 1836 - 1865

> The only kind of writing is rewriting. -Ernest Hemingway

> The Jedi were real?!   -Ray
> Crazy thing is…it’s true.  All of it. The Force, the Jedi. It’s all true.” – Han Solo

> **The goal of the Object Mother pattern is not to provide a factory method for every single test requirement we might have** but instead to provide ways to create a few functionally meaningful versions of an object that can be easily adapted within a concrete test.
> Each time we change one of our test cases, we would also have to change the factory method in our Object Mother. **This violates the [Single Responsibility Principle](https://en.wikipedia.org/wiki/Single_responsibility_principle) since the Object Mother must be changed for a lot of different reasons**.   
> Instead using the builder pattern and **we’ll less likely create a new factory method in our Object Mother that is probably only relevant four our current test**. 
> 
> ## May a Factory Method Call Another Factory Method?
> the same rules apply : **We don’t want to add responsibilities to our factory method that don’t belong there**.
> 
> So, before creating a custom factory method in an Object Mother we want to call from the factory method we’re currently coding, let’s think about whether we should rather use one of the pre-defined factory methods and customize the returned builder via fluent API to suit our requirements.-- from this [article](https://reflectoring.io/objectmother-fluent-builder/)
> 

> Object Mothers do have their faults. In particular there's a heavy coupling in that many tests will depend on the exact data in the mothers. As a result it's tricky should you want to change that standard data for any reason. Changes to classes will also result in the need to migrate the tests - although that will be an issue in any case.  -- Martin Fowler

If we want to make an Assert against each item in the collection, we could do this in a for loop for example
https://app.pluralsight.com/library/courses/dotnet-core-testing-code-xunit-dotnet-getting-started/transcript