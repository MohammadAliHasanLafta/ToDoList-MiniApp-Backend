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
        var result = await _todoRepository.UpdateAsync(request.Id, request.Context, request.IsComplete);

        return result;
    }
}

