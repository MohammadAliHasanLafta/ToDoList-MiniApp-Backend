using ToDoApi.Domain.ToDoEntities.Common;

namespace ToDoApi.Domain.Entities;

public class MiniAppUser : EntityBase
{
    public MiniAppUser(long id, string firstName, string lastName, string initdata, bool isValid)
    {
        UserId = id;
        FirstName = firstName;
        LastName = lastName;
        Initdata = initdata;
        IsValid = isValid;
    }
    public long UserId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string Initdata { get; set; }
    public bool IsValid { get; set; } = false;
}
