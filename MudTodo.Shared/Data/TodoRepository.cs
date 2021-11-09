using Microsoft.EntityFrameworkCore;
using MudTodo.Shared.Interfaces;
using MudTodo.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudTodo.Shared.Data;

public class TodoRepository : ITodoRepository
{
    private readonly TodoDbContext _dbContext;

    public TodoRepository(TodoDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> CreateAsync(Todo newItem)
    {
        ArgumentNullException.ThrowIfNull(newItem);
        
        if (string.IsNullOrWhiteSpace(newItem.ItemName))
        {
            return false;
        }

        await _dbContext.AddAsync(newItem);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<List<Todo>> GetAllAsync()
    {
        return await _dbContext.Todos.AsNoTracking().ToListAsync();
    }

    public async Task<bool> UpdateAsync(Todo updateItem)
    {
        ArgumentNullException.ThrowIfNull(updateItem);

        if (string.IsNullOrWhiteSpace(updateItem.ItemName))
        {
            return false;
        }

        Todo result = await _dbContext.Todos.SingleOrDefaultAsync(t => t.Id == updateItem.Id);

        if (result == null)
        {
            return false;
        }
        else
        {
            result.Completed = updateItem.Completed;
            result.ItemName = updateItem.ItemName;
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }

    public async Task<bool> DeleteAsync(Todo deleteItem)
    {
        ArgumentNullException.ThrowIfNull(deleteItem);
        Todo result = await _dbContext.Todos.SingleOrDefaultAsync(t => t.Id == deleteItem.Id);

        if (result == null)
        {
            return false;
        }
        else
        {
            _dbContext.Todos.Remove(result);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
