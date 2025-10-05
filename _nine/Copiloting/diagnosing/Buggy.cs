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
}