using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApi.Application.ToDoCommandsQueries.Commands.Create
{
    public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand, long>
    {
        private readonly ICreateToDoRepository createoRepo;
        public CreateTodoCommandHandler(TodoContext context)
        {
            _context = context;
        }

        public async Task<long> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
        {
            var newTodo = new TodoItem
            {
                Title = request.Context,
                UserId = request.UserId,
                IsComplete = false
            };

            _context.TodoItems.Add(newTodo);
            await _context.SaveChangesAsync();

            return newTodo.Id;
        }
    }

}
