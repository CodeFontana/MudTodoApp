using Microsoft.EntityFrameworkCore;
using MudTodo.Shared.Entities;

namespace MudTodo.Shared;

public class TodoDbContext : DbContext
{
    public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
    {

    }

    public DbSet<Todo> Todos { get; set; }
}
