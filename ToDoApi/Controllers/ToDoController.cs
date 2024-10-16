using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ToDoApi.Application.ToDoCommandsQueries.Commands.Create;
using ToDoApi.Application.ToDoCommandsQueries.Commands.Delete;
using ToDoApi.Application.ToDoCommandsQueries.Commands.Update;
using ToDoApi.Application.ToDoCommandsQueries.Queries.GetTodos;
using ToDoApi.Core.ToDoDtosProfiles.Dtos;
using ToDoApi.Domain.Interfaces;

namespace ToDoApi.API.Controllers;

[ApiController]
[Route("api/v1/todo")]
[Authorize]
public class TodoController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IProfileService _profileService;

    public TodoController(IMediator mediator, IProfileService profileService)
    {
        _mediator = mediator;
        _profileService = profileService;
    }

    [HttpGet("get-all-todos")]
    public async Task<ActionResult<IEnumerable<TodoItemDto>>> GetTodos()
    {
        var query = new GetTodosQuery();
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

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTodo(long id)
    {
        var result = await _mediator.Send(new DeleteTodoCommand { Id = id });
        if (!result) return NotFound();

        return Ok(result);
    }
}

