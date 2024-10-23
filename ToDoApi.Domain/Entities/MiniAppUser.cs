using ToDoApi.Domain.ToDoEntities.Common;

namespace ToDoApi.Domain.Entities;

public class MiniAppUser : EntityBase
{
    public MiniAppUser(long id, string firstName, string userName, string initdata)
    {
        UserId = id;
        FirstName = firstName;
        UserName = userName;
        Initdata = initdata;
    }
    public long UserId { get; set; }
    public string? FirstName { get; set; }
    public string? UserName { get; set; }
    public string? Initdata { get; set; }


}
