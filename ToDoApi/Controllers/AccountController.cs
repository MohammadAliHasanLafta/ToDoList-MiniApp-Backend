using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDoApi.Application.AccountCommandsQueries.Create;
using ToDoApi.Core.ToDoDtosProfiles.Dtos;
using ToDoApi.Domain.Interfaces;

namespace ToDoApi.Application.Controllers;


[ApiController]
[Route("/")]
public class AccountController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IAccountRepository _accountRepository;
    //private readonly IOtpService _otpService;

    public AccountController(IMediator mediator, IAccountRepository accountRepository)
    {
        _mediator = mediator;
        _accountRepository = accountRepository;
    }

    [HttpPost("verify-initdata")]
    public async Task<ActionResult<long>> VerifyInitData(CreateAccountCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPost("send-otp")]
    public async Task<IActionResult> SendOtp([FromBody] SendOtpDto dto)
    {
        //var otp = new Random().Next(100000, 999999).ToString();
        //var message = $"Your OTP code is: {otp}";

        //var result = await _otpService.SendOtpAsync(dto.PhoneNumber, message);

        //if (!result)
        //    return StatusCode(500, "Failed to send OTP.");
        var otp = "123456";

        await _accountRepository.SaveChangesInUsers(dto.PhoneNumber, otp);

        return Ok("OTP sent successfully.");
    }

    [HttpPost("verify-otp")]
    public async Task<IActionResult> VerifyOtp([FromBody] VerifyOtpDto dto)
    {
        var user = _accountRepository.GetUserByNumber(dto.PhoneNumber);

        if (user == null)
            return Unauthorized("User not found.");

        if (user.Otp != dto.Otp)
            return Unauthorized($"Invalid OTP. Received: {dto.Otp}, Expected: {user.Otp}");

        return Ok(user);
    }
}
