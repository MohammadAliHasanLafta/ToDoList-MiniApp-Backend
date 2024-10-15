using MediatR;
using ToDoApi.Domain.Entities;
using ToDoApi.Domain.Interfaces;

namespace ToDoApi.Application.ToDoCommandsQueries.Commands.Create
{
    public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand, long>
    {

        private readonly IToDoRepository _todoRepository;

        public CreateTodoCommandHandler(IToDoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<long> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
        {
            var result = await _todoRepository.Create(new ToDoItem(request.Context, false, request.UserId));

            return result;
        }
    }

}
