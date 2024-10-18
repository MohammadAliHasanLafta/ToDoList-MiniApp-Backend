using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApi.Application.AccountCommandsQueries.Create;

public class CreateAccountCommand : IRequest<long>
{
    public string? InitData { get; set; }
    public string? FirstName { get; set; }
    public string? UserName { get; set; }
    public long UserId { get; set; }
}
