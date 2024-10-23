
using ToDoApi.Domain.ToDoEntities.Common;

namespace ToDoApi.Domain.Entities;

public class UserProfile : EntityBase
{
    public UserProfile()
    {
    }

    public UserProfile(string userName, string email, long? userId, string? phoneNumber)
    {
        UserName = userName;
        Email = email;
        UserId = userId;
        PhoneNumber = phoneNumber;
    }



    public string? UserName { get; set; }
    public string? Email { get; set; }
    public long? UserId { get; set; }
    public MiniAppUser? MiniAppUser { get; set; }
    public string? PhoneNumber { get; set; }
    public WebAppUser? WebAppUser { get; set; }
}
