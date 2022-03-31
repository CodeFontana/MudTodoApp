using MudTodo.Shared.Entities;

namespace MudTodo.Shared;

public interface ITodoRepository
{
    Task<bool> CreateAsync(Todo newItem);
    Task<bool> DeleteAsync(Todo deleteItem);
    Task<List<Todo>> GetAllAsync();
    Task<bool> UpdateAsync(Todo updateItem);
}
