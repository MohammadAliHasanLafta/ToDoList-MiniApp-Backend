using ToDoApi.Domain.ToDoEntities.Common;

namespace ToDoApi.Domain.Entities;

public class AppUser : EntityBase
{
    public long TelegramId { get; set; }
}
