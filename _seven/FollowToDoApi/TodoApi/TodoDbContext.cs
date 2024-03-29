﻿using Microsoft.EntityFrameworkCore;
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

public class TodoDbContext2 : DbContext
{
    public TodoDbContext2(DbContextOptions<TodoDbContext2> options) : base(options)
    {
    }

    public DbSet<Todo> Todos { get; set; }
}