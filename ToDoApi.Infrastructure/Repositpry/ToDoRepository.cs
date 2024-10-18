
using ToDoApi.Domain.Entities;
using ToDoApi.Domain.Interfaces;
using ToDoApi.Infrastructure.Data;


namespace ToDoApi.Infrastructure.Repositpry;

public class ToDoRepository : IToDoRepository
{
    private readonly AppDbContext _context;

    public ToDoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<long> CreateAsync(ToDoItem model)
    {

        var entity = _context.TodoItems.Add(model);
        _context.SaveChanges();

        return entity.Entity.Id;
    }

    public async Task<bool> UpdateAsync(long id, string context, bool iscompleted)
    {
        var todo = await GetByIdAsync(id);

        if (todo == null) return false;

        todo.Context = context;
        todo.IsComplete = iscompleted;
        todo.UpdatedAt = DateTime.Now;

        _context.SaveChanges();

        return true;
    }

    public async Task<ToDoItem> GetByIdAsync(long id)
    {
        return _context.TodoItems.FirstOrDefault(t => t.Id == id);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var todo = await GetByIdAsync(id);

        if (todo == null) return false;

        todo.IsDeleted = true;
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<IEnumerable<ToDoItem>> GetAllAsync(long id)
    {
        return _context.TodoItems
            .Where(todo => todo.UserId == id && todo.IsDeleted == false)
            .ToList();
    }
}
