
using FluentValidation;

namespace ToDoApi.Application.ToDoCommandsQueries.Commands.Create;

public class CreateTodoCommandValidator : AbstractValidator<CreateTodoCommand>
{
    public CreateTodoCommandValidator()
    {
        RuleFor(x => x.Context).NotEmpty().WithMessage("Context is required");
    }

}
