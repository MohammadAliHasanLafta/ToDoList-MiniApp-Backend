using ToDoApi.Domain.ToDoEntities.Common;

namespace ToDoApi.Domain.Entities;

public class ToDoItem : EntityBase
{
    public ToDoItem(string? context, bool isComplete, string? userId)
    {
        Context = context;
        IsComplete = isComplete;
        UserId = userId;
    }

    public string? Context { get; set; }
    public bool IsComplete { get; set; }
    public string? UserId { get; set; }

    public AppUser User { get; set; }



}
