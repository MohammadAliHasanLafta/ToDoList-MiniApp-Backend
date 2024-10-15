
using MediatR;

namespace ToDoApi.Application.ToDoCommandsQueries.Commands.Create;

public class CreateTodoCommand : IRequest<long>
{
    public string? Context { get; set; }
    public long UserId { get; set; }
}
