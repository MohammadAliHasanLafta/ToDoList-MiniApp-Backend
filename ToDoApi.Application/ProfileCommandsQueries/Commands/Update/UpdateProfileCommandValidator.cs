
using FluentValidation;
using FluentValidation.Validators;

namespace ToDoApi.Application.ProfileCommandsQueries.Commands.Update;

public class UpdateProfileCommandValidator : AbstractValidator<UpdateProfileCommand>
{
    public UpdateProfileCommandValidator()
    {
        RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName is required");
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
    }
}
