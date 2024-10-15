

using ToDoApi.Application.ToDoCommandsQueries.Commands.Create;

namespace ToDoApi.Domain.Interfaces;

public interface ICreateToDoRepository
{
    long NewToDoId(CreateTodoCommand request);
}
