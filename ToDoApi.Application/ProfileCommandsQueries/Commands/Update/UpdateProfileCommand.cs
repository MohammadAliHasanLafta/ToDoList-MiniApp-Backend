using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApi.Application.ProfileCommandsQueries.Commands.Update;

public class UpdateProfileCommand : IRequest<bool>
{
    public long Id { get; set; }
    public string? UserName { get; set; }
    [EmailAddress]
    public string? Email { get; set; }
}
