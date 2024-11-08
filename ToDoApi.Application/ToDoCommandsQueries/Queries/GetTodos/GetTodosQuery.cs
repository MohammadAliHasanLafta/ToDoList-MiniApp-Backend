﻿using MediatR;
using ToDoApi.Domain.Entities;

namespace ToDoApi.Application.ToDoCommandsQueries.Queries.GetTodos;

public class GetTodosQuery : IRequest<IEnumerable<ToDoItem>>
{
    public long UserId { get; set; }
    public string? PhoneNumber { get; set; }
}

