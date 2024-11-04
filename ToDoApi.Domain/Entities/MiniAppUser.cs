using ToDoApi.Domain.ToDoEntities.Common;

namespace ToDoApi.Domain.Entities;

public class MiniAppUser : EntityBase
{
    public MiniAppUser(long id, string firstName, string lastName, string initdata, string mobile, string contactRequest, bool isValid)
    {
        UserId = id;
        FirstName = firstName;
        LastName = lastName;
        Initdata = initdata;
        Mobile = mobile;
        ContactRequest = contactRequest;
        IsValid = isValid;
    }
    public long UserId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string Initdata { get; set; }
    public string Mobile { get; set; }
    public string ContactRequest { get; set; }
    public bool IsValid { get; set; } = false;
}
