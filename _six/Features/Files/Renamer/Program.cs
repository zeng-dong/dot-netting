using System.IO;

namespace Renamer;

internal class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine($"renaming files under {args[0]}");

        //DirectoryInfo d = new DirectoryInfo(args[0]);
        //FileInfo[] infos = d.GetFiles();
        //foreach (FileInfo f in infos)
        //{
        //    Console.WriteLine($"renaming {f.FullName} to {"abc_" + f.FullName}");
        //    ///File.Move(f.FullName,  "abc_" + f.FullName);
        //}

        var prefix = args[1];
        var rootDir = args[0];
        var fileNames = Directory.EnumerateFiles(rootDir).ToArray();

        var count = fileNames.Count();

        for (var i = 0; i < count; i++)
        {
            var path = fileNames[i];

            var dir = Path.GetDirectoryName(path);
            Console.WriteLine($"dir = {dir}");

            var fileName = Path.GetFileName(path);

            var newPath = Path.Combine(dir, prefix + fileName);
            //Console.WriteLine($"newPath = {newPath}");

            Console.WriteLine($"renaming {path} to {newPath}");
            Console.WriteLine("");
            File.Move(path, newPath);
        }

        //foreach (String path in fileNames)
        //{
        //    //Console.WriteLine($"path = {path}");

        //    var dir = Path.GetDirectoryName(path);
        //    Console.WriteLine($"dir = {dir}");

        //    var fileName = Path.GetFileName(path);
        //    //Console.WriteLine($"fileName = {fileName}");

        //    var newPath = Path.Combine(dir, prefix + fileName);
        //    //Console.WriteLine($"newPath = {newPath}");

        //    Console.WriteLine($"renaming {path} to {newPath}");
        //    Console.WriteLine("");
        //    File.Move(path, newPath);
        //}
    }
}