using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApi.Domain.ToDoEntities.Common;

namespace ToDoApi.Domain.Entities;

public class MiniAppUserContact : EntityBase
{
    public MiniAppUserContact(long id, string contactRequest, string mobile, bool isValid)
    {
        UserId = id;
        ContactRequest = contactRequest;
        Mobile = mobile;
        IsValid = isValid;
    }
    public long UserId { get; set; }
    public string? ContactRequest { get; set; }
    public string? Mobile { get; set; }
    public bool IsValid { get; set; } = false;

}
