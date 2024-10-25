using MediatR;
using ToDoApi.Domain.Entities;
using ToDoApi.Domain.Interfaces;

namespace ToDoApi.Application.AccountCommandsQueries.Create;

public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, string>
{
    private readonly IAccountRepository _accountRepository;
    private readonly ITokenService _tokenService;

    public CreateAccountCommandHandler(IAccountRepository accountRepository, ITokenService tokenService)
    {
        _accountRepository = accountRepository;
        _tokenService = tokenService;
    }

    public async Task<string> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        return "";
    }
}
