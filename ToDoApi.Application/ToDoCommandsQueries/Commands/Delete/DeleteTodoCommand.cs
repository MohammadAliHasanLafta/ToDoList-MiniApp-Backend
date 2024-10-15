using MediatR;

namespace ToDoApi.Application.ToDoCommandsQueries.Commands.Delete;

public class DeleteTodoCommand : IRequest<bool>
{
    public long Id { get; set; }
}
