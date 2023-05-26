namespace Renamer;

internal class Program
{
    static void Main(string[] args)
    {
        var prefix = args[1];
        var rootDir = args[0];
        var fileNames = Directory.EnumerateFiles(rootDir).ToArray();

        var count = fileNames.Count();

        for (var i = 0; i < count; i++)
        {
            var path = fileNames[i];
            var dir = Path.GetDirectoryName(path);
            var fileName = Path.GetFileName(path);
            var newPath = Path.Combine(dir, prefix + fileName);

            Console.WriteLine($"renaming {path} to {newPath}");
            Console.WriteLine("");
            File.Move(path, newPath);
        }
    }
}