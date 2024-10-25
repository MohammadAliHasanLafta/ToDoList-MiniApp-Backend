using ToDoApi.Domain.ToDoEntities.Common;

namespace ToDoApi.Domain.Entities;

public class MiniAppUser : EntityBase
{
    public MiniAppUser(long id, string firstName, string lastName, string initdata)
    {
        UserId = id;
        FirstName = firstName;
        LastName = lastName;
        Initdata = initdata;
        IsValid = false;
    }
    public long UserId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string Initdata { get; set; }
    public bool IsValid { get; set; }
}
