using Microsoft.EntityFrameworkCore;
using TodoApi;
using TodoApi.Todos;
using TodoApi.Weathers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TodoDbContext2>(o => o.UseSqlite("DataSource=Todos.db"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapWeathers();
TodoApi3.MapRoutes(app);

app.Run();