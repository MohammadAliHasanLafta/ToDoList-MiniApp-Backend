
using MediatR;
using ToDoApi.Domain.Entities;
using ToDoApi.Domain.Interfaces;

namespace ToDoApi.Application.ToDoCommandsQueries.Queries.GetTodos;

public class GetTodosQueryHandler : IRequestHandler<GetTodosQuery, IEnumerable<ToDoItem>>
{
    private readonly IToDoRepository _todoRepository;
    private readonly IProfileService _profileService;

    public GetTodosQueryHandler(IToDoRepository todoRepository, IProfileService profileService)
    {
        _todoRepository = todoRepository;
        _profileService = profileService;
    }

    public async Task<IEnumerable<ToDoItem>> Handle(GetTodosQuery request, CancellationToken cancellationToken)
    {
        var userId = _profileService.GetUserId();
        var result = await _todoRepository.GetAllAsync(userId);

        return result;
    }
}

