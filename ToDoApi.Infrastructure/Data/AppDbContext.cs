
using Microsoft.EntityFrameworkCore;
using ToDoApi.Domain.Entities;

namespace ToDoApi.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<ToDoItem> TodoItems { get; set; }
    public DbSet<MiniAppUser> MiniAppUsers { get; set; }
    public DbSet<WebAppUser> WebAppUsers { get; set; }
    public DbSet<UserProfile> Profiles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ToDoItem>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Context).IsRequired();
            entity.Property(e => e.UserId).IsRequired(false);
            entity.Property(e => e.UserPhoneNumber).IsRequired(false);

            entity.HasCheckConstraint("CK_UserIdOrPhoneNumber",
                "[UserId] IS NOT NULL OR [UserPhoneNumber] IS NOT NULL");
        });
    }
}
