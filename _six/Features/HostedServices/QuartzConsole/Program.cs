using Quartz.Impl;
using Quartz;
using Quartz.Logging;

namespace QuartzConsole;

internal class Program
{
    private static async Task Main(string[] args)
    {
        LogProvider.SetCurrentLogProvider(new ConsoleLogProvider());

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

    private class ConsoleLogProvider : ILogProvider
    {
        public Logger GetLogger(string name)
        {
            return (level, func, exception, parameters) =>
            {
                if (level >= LogLevel.Info && func != null)
                {
                    Console.WriteLine("[" + DateTime.Now.ToLongTimeString() + "] [" + level + "] " + func(), parameters);
                }
                return true;
            };
        }

        public IDisposable OpenNestedContext(string message)
        {
            throw new NotImplementedException();
        }

        public IDisposable OpenMappedContext(string key, object value, bool destructure = false)
        {
            throw new NotImplementedException();
        }
    }
}