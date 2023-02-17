namespace BestPractices.Entities;

public class Author : IComparable<Author>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Author(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }

    public int CompareTo(object? obj)
    {
        if (obj == null) return 1;
        if (obj is Author otherAuthor)
        {
            return this.ToString().CompareTo(otherAuthor.ToString());
        }
        throw new ArgumentException("Not a Author", nameof(obj));
    }

    public int CompareTo(Author? other)
    {
        if (other == null) return 1;

        return this.ToString().CompareTo(other.ToString());
    }
}