using ToDoApi.Domain.ToDoEntities.Common;

namespace ToDoApi.Domain.Entities;

public class ToDoItem : EntityBase
{
    private ToDoItem() { }

    public ToDoItem(string context, bool isComplete, long? userId = null, string? phoneNumber = null)
    {
        if (string.IsNullOrWhiteSpace(phoneNumber) && userId == null)
        {
            throw new ArgumentException("Either UserId or PhoneNumber must be provided.");
        }

        Context = context;
        IsComplete = isComplete;
        UserId = userId;
        UserPhoneNumber = phoneNumber;
    }

    public string? Context { get; set; }
    public bool IsComplete { get; set; }
    public long? UserId { get; set; }
    public string? UserPhoneNumber { get; set; }

}
