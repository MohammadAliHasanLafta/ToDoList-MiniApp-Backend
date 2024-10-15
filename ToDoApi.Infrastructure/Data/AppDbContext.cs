
using Microsoft.EntityFrameworkCore;
using ToDoApi.Domain.Entities;

namespace ToDoApi.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<ToDoItem> TodoItems { get; set; }
    public DbSet<AppUser> Users { get; set; }

}
