using FriendlyGames.Domain.Categories;
using FriendlyGames.Domain.Models;
using Microsoft.AspNetCore.Identity;
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

        // Defining relations and type conversions
        modelBuilder.Entity<Registration>()
            .HasKey(r => new {r.EventId, UserId = r.ApiUserId});
        modelBuilder.Entity<Registration>()
            .HasOne(r => r.Event)
            .WithMany(e => e.Registrations)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Registration>()
            .HasOne(r => r.ApiUser)
            .WithMany(u => u.Registrations)
            .OnDelete(DeleteBehavior.Restrict);

        // Seeding data
        modelBuilder.Entity<SurroundingCategory>().HasData(new SurroundingCategory {Id = 1, Name = "Węwnątrz"});
        modelBuilder.Entity<SurroundingCategory>().HasData(new SurroundingCategory {Id = 2, Name = "Na zewnątrz"});
        modelBuilder.Entity<SurfaceCategory>().HasData(new SurfaceCategory {Id = 1, Name = "Trawa"});
        modelBuilder.Entity<SurfaceCategory>().HasData(new SurfaceCategory {Id = 2, Name = "Kort"});
        modelBuilder.Entity<SurfaceCategory>().HasData(new SurfaceCategory {Id = 3, Name = "Piasek"});
        modelBuilder.Entity<SurfaceCategory>().HasData(new SurfaceCategory {Id = 4, Name = "Hala"});
        modelBuilder.Entity<SurfaceCategory>().HasData(new SurfaceCategory {Id = 5, Name = "Basen"});
        modelBuilder.Entity<SurfaceCategory>().HasData(new SurfaceCategory {Id = 6, Name = "Syntetyczna"});
        modelBuilder.Entity<SurfaceCategory>().HasData(new SurfaceCategory {Id = 7, Name = "Inne"});
        modelBuilder.Entity<LevelCategory>().HasData(new LevelCategory {Id = 1, Name = "Łatwy"});
        modelBuilder.Entity<LevelCategory>().HasData(new LevelCategory {Id = 2, Name = "Średni"});
        modelBuilder.Entity<LevelCategory>().HasData(new LevelCategory {Id = 3, Name = "Zaawanzowany"});
        modelBuilder.Entity<EventCategory>()
            .HasData(new EventCategory
            {
                Id = 1, Name = "Koszykówka", ImageForSearchBar = "ball-of-basketball.png",
                ImageForBoxWithEventInfo = "basketball-box.png"
            });
        modelBuilder.Entity<EventCategory>()
            .HasData(new EventCategory
            {
                Id = 2, Name = "Piłka Nożna", ImageForSearchBar = "football.png",
                ImageForBoxWithEventInfo = "football-box.png"
            });
        modelBuilder.Entity<EventCategory>()
            .HasData(new EventCategory
            {
                Id = 3, Name = "Siłownia", ImageForSearchBar = "dumbbell.png",
                ImageForBoxWithEventInfo = "siłownia-box.png"
            });
        modelBuilder.Entity<EventCategory>()
            .HasData(new EventCategory
            {
                Id = 4, Name = "Bieganie", ImageForSearchBar = "running.png",
                ImageForBoxWithEventInfo = "bieganie-box.png"
            });
        modelBuilder.Entity<EventCategory>()
            .HasData(new EventCategory
            {
                Id = 5, Name = "Rower", ImageForSearchBar = "bicycle.png", ImageForBoxWithEventInfo = "rower-box.png"
            });
        modelBuilder.Entity<EventCategory>()
            .HasData(new EventCategory
            {
                Id = 6, Name = "Siatkówka", ImageForSearchBar = "siatkowka.png",
                ImageForBoxWithEventInfo = "siatkowka-box.png"
            });
        modelBuilder.Entity<EventCategory>()
            .HasData(new EventCategory
                {Id = 7, Name = "Tenis", ImageForSearchBar = "tennis.png", ImageForBoxWithEventInfo = "tenis-box.png"});
        modelBuilder.Entity<EventCategory>()
            .HasData(new EventCategory
            {
                Id = 8, Name = "Ping Pong", ImageForSearchBar = "table-tennis.png",
                ImageForBoxWithEventInfo = "table-tennis-box.png"
            });
        modelBuilder.Entity<EventCategory>()
            .HasData(new EventCategory
            {
                Id = 9, Name = "Kręgielnia", ImageForSearchBar = "bowling.png",
                ImageForBoxWithEventInfo = "kręgle-box.png"
            });
        modelBuilder.Entity<IdentityRole>()
            .HasData(new IdentityRole {Name = "User", NormalizedName = "USER"});
        modelBuilder.Entity<IdentityRole>()
            .HasData(new IdentityRole {Name = "Administrator", NormalizedName = "ADMINISTRATOR"});
    }
}