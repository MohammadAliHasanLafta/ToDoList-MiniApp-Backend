using MediatR;
using ToDoApi.Domain.Interfaces;

namespace ToDoApi.Application.ToDoCommandsQueries.Commands.Update;

public class UpdateTodoCommandHandler : IRequestHandler<UpdateTodoCommand, bool>
{
    private readonly IToDoRepository _todoRepository;

    public UpdateTodoCommandHandler(IToDoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<bool> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = await _todoRepository.GetById(request.Id);

        if (todo == null) return false;

        todo.Context = request.Context;
        todo.IsComplete = request.IsComplete;

        _todoRepository.SaveChanges();

        return true;
    }
}

