using MudTodo.Shared.Models;

namespace MudTodo.Shared.Interfaces;

public interface ITodoRepository
{
    Task<bool> CreateAsync(Todo newItem);
    Task<bool> DeleteAsync(Todo deleteItem);
    Task<List<Todo>> GetAllAsync();
    Task<bool> UpdateAsync(Todo updateItem);
}
