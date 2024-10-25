using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApi.Application.AccountCommandsQueries.Create;

public class CreateAccountCommand : IRequest<string>
{
    public string? InitData { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public long UserId { get; set; }
}
