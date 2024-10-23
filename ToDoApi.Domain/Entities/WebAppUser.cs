
using ToDoApi.Domain.ToDoEntities.Common;

namespace ToDoApi.Domain.Entities;

public class WebAppUser : EntityBase
{
    public WebAppUser(string phoneNumber, string otp)
    {
        PhoneNumber = phoneNumber;
        Otp = otp;
    }
    public string? PhoneNumber { get; set; }
    public string? Otp { get; set; }
}
