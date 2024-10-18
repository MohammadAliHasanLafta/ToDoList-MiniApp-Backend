
using MediatR;
using ToDoApi.Domain.Entities;
using ToDoApi.Domain.Interfaces;

namespace ToDoApi.Application.ToDoCommandsQueries.Queries.GetTodos;

public class GetTodosQueryHandler : IRequestHandler<GetTodosQuery, IEnumerable<ToDoItem>>
{
    private readonly IToDoRepository _todoRepository;

    public GetTodosQueryHandler(IToDoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<IEnumerable<ToDoItem>> Handle(GetTodosQuery request, CancellationToken cancellationToken)
    {
        var result = await _todoRepository.GetAllAsync(request.UserId);

        return result;
    }
}

