using ToDoApi.Domain.Entities;

namespace ToDoApi.Domain.Interfaces;

public interface IToDoRepository
{
    Task<long> CreateAsync(ToDoItem model);
    Task<bool> UpdateAsync(long id, string context, bool iscompleted);
    Task<bool> DeleteAsync(long id);
    Task<ToDoItem> GetByIdAsync(long id);
    Task<IEnumerable<ToDoItem>> GetAllAsync(long id, string phoneNumber);
}
