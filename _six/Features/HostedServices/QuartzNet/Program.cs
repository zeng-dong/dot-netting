using Quartz;

namespace QuartzNet;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddQuartz(q =>
        {
            // use a scoped container to create jobs.
            q.UseMicrosoftDependencyInjectionScopedJobFactory();

            // Create a "key" for the job
            var jobKey = new JobKey("HelloWorldJob");

            // Register the job with the DI container
            q.AddJob<HelloWorldJob>(opts => opts.WithIdentity(jobKey));

            // Create a trigger for the job
            q.AddTrigger(opts => opts
                .ForJob(jobKey) // link to the HelloWorldJob
                .WithIdentity("HelloWorldJob-trigger") // give the trigger a unique name
                .WithCronSchedule("0/15 * * * * ?")); // run every 15 seconds
        });
        builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}