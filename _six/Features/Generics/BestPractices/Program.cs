using BestPractices.Entities;

namespace BestPractices;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        var students = new Student[10];
        students[0] = new("Steve", "Smith");
        students[1] = new("Chad", "Smith");
        students[2] = new("Ben", "Smith");
        students[3] = new("Eric", "Smith");
        students[4] = new("Julie", "Lerman");
        students[5] = new("David", "Starr");
        students[6] = new("Aaron", "Skonnard");
        students[7] = new("Aaron", "Stewart");
        students[8] = new("Aaron", "Powell");
        students[9] = new("Aaron", "Frost");

        Array.Sort(students);         // runtime InvalidOperationException: need to implement IComparable

        Console.WriteLine("Students:");
        for (int i = 0; i < students.Length; i++)
        {
            Console.WriteLine(students[i]);
        }

        var authors = new Author[10];
        authors[0] = new("Steve", "Smith");
        authors[1] = new("Chad", "Smith");
        authors[2] = new("Ben", "Smith");
        authors[3] = new("Eric", "Smith");
        authors[4] = new("Julie", "Lerman");
        authors[5] = new("David", "Starr");
        authors[6] = new("Aaron", "Skonnard");
        authors[7] = new("Aaron", "Stewart");
        authors[8] = new("Aaron", "Powell");
        authors[9] = new("Aaron", "Frost");

        Array.Sort(authors);

        Console.WriteLine("Authors:");
        for (int i = 0; i < authors.Length; i++)
        {
            Console.WriteLine(authors[i]);
        }
    }
}