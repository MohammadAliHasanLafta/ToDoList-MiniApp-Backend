using ToDoApi.Domain.ToDoEntities.Common;

namespace ToDoApi.Domain.Entities;

public class ToDoItem : EntityBase
{
    public ToDoItem(string? context, bool isComplete, long userId)
    {
        Context = context;
        IsComplete = isComplete;
        UserId = userId;
    }

    public string? Context { get; set; }
    public bool IsComplete { get; set; }
    public long UserId { get; set; }

}
