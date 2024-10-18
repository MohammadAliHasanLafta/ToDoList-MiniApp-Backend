using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDoApi.Application.AccountCommandsQueries.Create;

namespace ToDoApi.Application.Controllers;


[ApiController]
[Route("/")]
public class AccountController : ControllerBase
{
    private readonly IMediator _mediator;

    public AccountController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("verify-initdata")]
    public async Task<ActionResult<long>> VerifyInitData(CreateAccountCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}
