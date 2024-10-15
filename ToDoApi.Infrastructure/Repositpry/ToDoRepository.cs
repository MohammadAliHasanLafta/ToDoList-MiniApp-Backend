using Azure.Core;
using Microsoft.EntityFrameworkCore;
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

    public async Task<long> Create(ToDoItem model)
    {

        var entity = _context.TodoItems.Add(model);
        _context.SaveChanges();

        return entity.Entity.Id;
    }

    public async Task<ToDoItem> GetByIdAsync(long id)
    {
        return _context.TodoItems.FirstOrDefault(t => t.Id == id);
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}
