in C# version 2 released in 2005

along with other features , like covariance and contravariance

Generics add the concept of type parameters to .NET types and members. They make it possible to design classes and methods such that specific types used by them are passed into them by their client rather than fixed when they are defined. 

### benefits
1. code reuse
2. type safety
3. performance
### cons
added some complexity


## comparision

```c#
// interfaces 
public interface IComparable{}

// specific interfaces
public interface IProductRepository {}

// generic interfaces
public interface IComparable<T>
public interface IDictionary<T, V>



```