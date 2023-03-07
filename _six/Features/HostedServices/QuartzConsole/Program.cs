using Quartz.Impl;
using Quartz;

namespace QuartzConsole;

internal class Program
{
    private static async Task Main(string[] args)
    {
        Console.WriteLine("obtains an instance of the scheduler, starts it, then shuts it down");

        StdSchedulerFactory factory = new StdSchedulerFactory();
        IScheduler scheduler = await factory.GetScheduler();

        // and start it off
        await scheduler.Start();

        // some sleep to show what's happening
        await Task.Delay(TimeSpan.FromSeconds(10));

        // and last shut down the scheduler when you are ready to close your program
        await scheduler.Shutdown();
    }
}