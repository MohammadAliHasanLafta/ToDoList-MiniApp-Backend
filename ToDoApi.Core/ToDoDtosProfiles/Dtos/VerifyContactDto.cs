using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApi.Core.ToDoDtosProfiles.Dtos;

public class VerifyContactDto
{
    public long UserId { get; set; }
    public string? Mobile { get; set; }
    public string? ContactRequest { get; set; }
}
