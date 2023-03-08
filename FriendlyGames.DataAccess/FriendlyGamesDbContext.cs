using FriendlyGames.Domain.Categories;
using FriendlyGames.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FriendlyGames.DataAccess;

public class FriendlyGamesDbContext : IdentityDbContext<ApiUser>
{
    public FriendlyGamesDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<EventCategory>? EventCategories { get; set; }
    public DbSet<SurfaceCategory>? SurfaceCategories { get; set; }
    public DbSet<SurroundingCategory>? SurroundingCategories { get; set; }
    public DbSet<LevelCategory>? LevelCategories { get; set; }
    public DbSet<Event>? Events { get; set; }
    public DbSet<Registration>? Registrations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        FriendlyGamesDbContextExtension.SeedingSurroundingCategory(modelBuilder);
        FriendlyGamesDbContextExtension.SeedingSurfaceCategory(modelBuilder);
        FriendlyGamesDbContextExtension.SeedingLevelCategory(modelBuilder);
        FriendlyGamesDbContextExtension.SeedingEventCategory(modelBuilder);
        FriendlyGamesDbContextExtension.SeedingIdentityRole(modelBuilder);
        FriendlyGamesDbContextExtension.DefiningRelationsAndTypeConversions(modelBuilder);
    }
}