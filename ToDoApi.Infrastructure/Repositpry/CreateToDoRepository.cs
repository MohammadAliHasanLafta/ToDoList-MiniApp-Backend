using Azure.Core;
using Microsoft.EntityFrameworkCore;
using ToDoApi.Application.ToDoCommandsQueries.Commands.Create;
using ToDoApi.Domain.Entities;
using ToDoApi.Domain.Interfaces;
using ToDoApi.Infrastructure.Data;

namespace ToDoApi.Infrastructure.Repositpry;

public class CreateToDoRepository : ICreateToDoRepository
{
    private readonly AppDbContext _context;

    public CreateToDoRepository(AppDbContext context)
    {
        _context = context;
    }

    public long NewToDoId(CreateTodoCommand request)
    {
        var newTodo = new ToDoItem
        {
            Context = request.Context,
            UserId = request.UserId,
            IsComplete = false
        };

        _context.TodoItems.Add(newTodo);
        _context.SaveChangesAsync();

        return newTodo.Id;
    }
}
