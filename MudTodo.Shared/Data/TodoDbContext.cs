using Microsoft.EntityFrameworkCore;
using MudTodo.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudTodo.Shared.Data;

public class TodoDbContext : DbContext
{
    public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
    {

    }

    public DbSet<Todo> Todos { get; set; }
}
