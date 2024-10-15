using ToDoApi.Domain.Entities;

namespace ToDoApi.Domain.Interfaces;

public interface IToDoRepository
{
    Task<long> Create(ToDoItem model);
    Task<ToDoItem> GetById(long id);
    void SaveChanges();
}
