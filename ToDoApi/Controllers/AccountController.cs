using Microsoft.AspNetCore.Mvc;
using ToDoApi.Core.ToDoDtosProfiles.Dtos;
using ToDoApi.Domain.Interfaces;

namespace ToDoApi.Application.Controllers;


[ApiController]
[Route("api/v1/account")]
public class AccountController : ControllerBase
{
    private readonly IAccountRepository _accountRepo;
    private readonly ITokenService _tokenService;

    public AccountController(IAccountRepository accountRepo, ITokenService tokenService)
    {
        _accountRepo = accountRepo;
        _tokenService = tokenService;
    }

    [HttpPost("verify-initdata")]
    public IActionResult VerifyInitData([FromBody] InitDataDto dto)
    {
        var userData = _accountRepo.ParseUserData(dto.InitData);
        var token = _tokenService.CreateToken(userData);

        if (_accountRepo.UserIsExist(userData))
        {
            return Ok(new {Token = token});
        }

        if (!_accountRepo.VerifyTelegramInitData(dto.InitData))
        {
            return Unauthorized("Invalid initData");
        }

        _accountRepo.AddUser(userData);

        return Ok(new { Token = token });
        
    }
}
