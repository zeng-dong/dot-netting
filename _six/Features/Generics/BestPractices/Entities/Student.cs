namespace BestPractices.Entities;

public class Student : IComparable<Student>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Student(string firstName, string lastName)
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
        if (obj is Student otherStudent)
        {
            if (otherStudent.LastName == this.LastName)
            {
                return this.FirstName.CompareTo(otherStudent.FirstName);
            }

            return this.LastName.CompareTo(otherStudent.LastName);
        }
        throw new ArgumentException("Not a Student", nameof(obj));
    }

    public int CompareTo(Student? other)
    {
        if (other == null) return 1;

        if (other.LastName == this.LastName)
        {
            return this.FirstName.CompareTo(other.FirstName);
        }
        return this.LastName.CompareTo(other.LastName);
    }
}