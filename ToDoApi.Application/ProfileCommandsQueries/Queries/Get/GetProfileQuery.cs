using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApi.Domain.Entities;

namespace ToDoApi.Application.ProfileCommandsQueries.Queries.Get;

public class GetProfileQuery : IRequest<UserProfile>
{
    public long UserId { get; set; }
    public string? PhoneNumber { get; set; }
}
