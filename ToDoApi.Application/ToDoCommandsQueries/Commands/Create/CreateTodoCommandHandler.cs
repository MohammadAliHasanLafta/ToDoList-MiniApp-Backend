using MediatR;
using ToDoApi.Domain.Entities;
using ToDoApi.Domain.Interfaces;

namespace ToDoApi.Application.ToDoCommandsQueries.Commands.Create
{
    public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand, long>
    {

        private readonly IToDoRepository _todoRepository;
        private readonly IProfileService _profileService;

        public CreateTodoCommandHandler(IToDoRepository todoRepository, IProfileService profileService)
        {
            _todoRepository = todoRepository;
            _profileService = profileService;
        }

        public async Task<long> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
        {
            var userId = _profileService.GetUserId();
            var result = await _todoRepository.CreateAsync(new ToDoItem(request.Context, false, userId));

            return result;
        }
    }

}
