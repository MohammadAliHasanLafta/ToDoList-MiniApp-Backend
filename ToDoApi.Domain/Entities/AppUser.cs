using ToDoApi.Domain.ToDoEntities.Common;

namespace ToDoApi.Domain.Entities;

public class AppUser 
{
    public AppUser(string id, string firstName, string userName)
    {
        Id = id;
        FirstName = firstName;
        UserName = userName;
    }

    public string Id { get; set; }
    public string FirstName { get; set; }
    public string UserName { get; set; }


}
