using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApi.Application.ToDoCommandsQueries.Commands.Create;
using ToDoApi.Domain.Entities;
using ToDoApi.Domain.Interfaces;

namespace ToDoApi.Application.AccountCommandsQueries.Create;

public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, long>
{
    private readonly IAccountRepository _accountRepository;

    public CreateAccountCommandHandler(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public async Task<long> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        var userId = request.UserId;

        if (_accountRepository.UserIsExist(userId))
        {
            return 0000;
        }


        var result = await _accountRepository.AddUser(new AppUser(request.UserId,request.FirstName,request.UserName,request.InitData));

        return result;
    }
}
