using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApi.Application.ToDoCommandsQueries.Commands.Create;

namespace ToDoApi.Application.AccountCommandsQueries.Create;

public class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommand>
{
    public CreateAccountCommandValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("Firsname is required");
        RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is required");
        RuleFor(x => x.InitData).NotEmpty().WithMessage("Initdata is required");
        RuleFor(x => x.UserName).NotEmpty().WithMessage("Username is required");
    }

}
