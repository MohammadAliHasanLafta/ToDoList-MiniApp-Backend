
namespace ToDoApi.Domain.ToDoEntities.Common;

public abstract class EntityBase
{
    public long Id { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public EntityBase()
    {
        CreatedAt = DateTime.Now;
    }

    public void Delete()
    {
        this.IsDeleted = true;
    }
}
