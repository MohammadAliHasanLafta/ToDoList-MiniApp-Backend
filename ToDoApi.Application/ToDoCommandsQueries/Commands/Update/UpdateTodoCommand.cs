using MediatR;

namespace ToDoApi.Application.ToDoCommandsQueries.Commands.Update;

public class UpdateTodoCommand : IRequest<bool>
{
    public long Id { get; set; }
    public string? Context { get; set; }
    public bool IsComplete { get; set; }
}

