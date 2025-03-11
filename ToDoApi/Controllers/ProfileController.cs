using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoApi.Application.ProfileCommandsQueries.Commands.Delete;
using ToDoApi.Application.ProfileCommandsQueries.Commands.Update;
using ToDoApi.Application.ProfileCommandsQueries.Queries.Get;
using ToDoApi.Domain.Entities;

namespace ToDoApi.API.Controllers;

[ApiController]
[Route("/")]
public class ProfileController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProfileController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("get-profile")]
    public async Task<ActionResult<UserProfile>> GetProfile([FromQuery] GetProfileQuery query)
    {
        var profile = await _mediator.Send(query);
        return Ok(profile);
    }

    [HttpPut("update-profile/{id}")]
    public async Task<IActionResult> UpdateTodo(long id, UpdateProfileCommand command)
    {
        if (id != command.Id) return BadRequest();

        var result = await _mediator.Send(command);
        if (!result) return NotFound();

        return Ok(result);
    }

    [HttpDelete("remove-profile/{id}")]
    public async Task<IActionResult> DeleteTodo(long id)
    {
        var result = await _mediator.Send(new DeleteProfileCommand { Id = id });
        if (!result) return NotFound();

        return Ok(result);
    }
}
