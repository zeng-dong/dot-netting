using TestingApi.AwardingBonus;

namespace TestingApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddTransient<IHumanResourceService, HumanResourceService>();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.AddCommonExceptionsHandler();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}