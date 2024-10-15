using ToDoApi.Domain.ToDoEntities.Common;

namespace ToDoApi.Domain.Entities;

public class ToDoItem : EntityBase
{
    public string? Context { get; set; }
    public bool IsComplete { get; set; }
    public long UserId { get; set; }
}
