using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDoApi.Application.ToDoCommandsQueries.Commands.Create;
using ToDoApi.Application.ToDoCommandsQueries.Commands.Delete;
using ToDoApi.Application.ToDoCommandsQueries.Commands.Update;
using ToDoApi.Application.ToDoCommandsQueries.Queries.GetTodos;
using ToDoApi.Core.ToDoDtosProfiles.Dtos;

namespace ToDoApi.API.Controllers;

[ApiController]
[Route("api/v1/todo")]
public class TodoController : ControllerBase
{
    private readonly IMediator _mediator;

    public TodoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{userId}")]
    public async Task<ActionResult<IEnumerable<TodoItemDto>>> GetTodos(long userId)
    {
        var query = new GetTodosQuery { UserId = userId };
        var todos = await _mediator.Send(query);
        return Ok(todos);
    }

    [HttpPost]
    public async Task<ActionResult<long>> CreateTodo(CreateTodoCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTodo(long id, UpdateTodoCommand command)
    {
        if (id != command.Id) return BadRequest();

        var result = await _mediator.Send(command);
        if (!result) return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTodo(long id)
    {
        var result = await _mediator.Send(new DeleteTodoCommand { Id = id });
        if (!result) return NotFound();

        return NoContent();
    }
}

