using Microsoft.EntityFrameworkCore;
using TodoApi.Todos;

namespace TodoApi;

public class TodoDbContext : DbContext
{
    public DbSet<Todo> Todos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Todos.db");
    }
}