namespace Copiloting.diagnosing;

internal class Buggy
{
    public void ExceptionIssue()
    {
        Remove(2, ["a", "b", "c"]);
    }

    public void LogicIssue()
    {
        Remove(0, ["a", "b", "c"]);
    }

    public void Remove(int index, List<string> goodies)
    {
        if (index >= 0)
        {
            goodies.RemoveAt(index);

            if (goodies.Count > 0)
            {
                var itemForLogging = goodies[index];

                var logMessage = $"Removed item: {itemForLogging}";

                Console.WriteLine($"Goodie removed: {logMessage}");
            }
        }

        Console.WriteLine("Done removing goodies. The remaining: ");
        goodies.ForEach(g => Console.WriteLine(g));
    }

    /*
     In the shopping bascket an administration fee should be paid if the total price is below 500, but it also shows
    no administration fee is paid while the total price is 489.91. Can you see how this can be caused from and fix this?
     */

    //public void RemoveByCopilot(int index, List<string> goodies)
    //{
    //    if (index >= 0 && index < goodies.Count)
    //    {
    //        var itemForLogging = goodies[index];
    //        goodies.RemoveAt(index);

    //        var logMessage = $"Removed item: {itemForLogging}";
    //        Console.WriteLine($"Goodie removed: {logMessage}");

    //        if (goodies.Count > 0)
    //        {
    //            Console.WriteLine("Remaining goodies:");
    //            goodies.ForEach(g => Console.WriteLine(g));
    //        }
    //    }
    //    else
    //    {
    //        Console.WriteLine("Index out of range. No item removed.");
    //    }

    //    Console.WriteLine("Done removing goodies.");
    //}
}