
using FluentValidation;

namespace ToDoApi.Application.ToDoCommandsQueries.Commands.Update;

public class UpdateTodoCommandValidator : AbstractValidator<UpdateTodoCommand>
{
    public UpdateTodoCommandValidator()
    {
        RuleFor(x => x.Context).NotEmpty().WithMessage("Context is required");
    }
}
