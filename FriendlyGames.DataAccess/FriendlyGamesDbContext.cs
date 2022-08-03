using FriendlyGames.Domain.Categories;
using FriendlyGames.Domain.Enums;
using FriendlyGames.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FriendlyGames.DataAccess;

public class FriendlyGamesDbContext : DbContext
{
    public DbSet<EventCategory> EventCategories { get; set; }
    public DbSet<SurfaceCategory> SurfaceCategories { get; set; }

    public DbSet<SurroundingCategory> SurroundingCategories { get; set; }
    public DbSet<RegistrationCategory> RegistrationCategories { get; set; }
    public DbSet<LevelCategory> LevelCategories { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Registration> Registrations { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<Team> Teams { get; set; }

    public DbSet<FootballMatch> FootballMatches { get; set; }

    public FriendlyGamesDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Defining relations and type conversions
        modelBuilder.Entity<Registration>()
            .HasKey(r => new { r.EventId, r.UserId });
        modelBuilder.Entity<Registration>()
            .HasOne(r => r.Event)
            .WithMany(e => e.Registrations)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Registration>()
            .HasOne(r => r.User)
            .WithMany(u => u.Registrations)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<FootballMatch>()
            .HasOne(fm => fm.TeamA)
            .WithMany(t => t.MatchesA)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<FootballMatch>()
            .HasOne(fm => fm.TeamB)
            .WithMany(t => t.MatchesB)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<FootballMatch>()
            .HasOne(fm => fm.Event);

        // Seeding data
        modelBuilder.Entity<RegistrationCategory>().HasData(new RegistrationCategory {Id = 1, Name = "Waiting"});
        modelBuilder.Entity<RegistrationCategory>().HasData(new RegistrationCategory {Id = 2, Name = "Accepted"});
        modelBuilder.Entity<RegistrationCategory>().HasData(new RegistrationCategory {Id = 3, Name = "Rejected"});
        modelBuilder.Entity<SurroundingCategory>().HasData(new SurroundingCategory {Id = 1, Name = "Indoor"});
        modelBuilder.Entity<SurroundingCategory>().HasData(new SurroundingCategory {Id = 2, Name = "Outdoor" });
        modelBuilder.Entity<SurfaceCategory>().HasData(new SurfaceCategory {Id = 1, Name = "Grass"});
        modelBuilder.Entity<SurfaceCategory>().HasData(new SurfaceCategory { Id = 2, Name = "Court" });
        modelBuilder.Entity<SurfaceCategory>().HasData(new SurfaceCategory { Id = 3, Name = "Sand" });
        modelBuilder.Entity<SurfaceCategory>().HasData(new SurfaceCategory { Id = 4, Name = "Hall" });
        modelBuilder.Entity<SurfaceCategory>().HasData(new SurfaceCategory { Id = 5, Name = "Pool" });
        modelBuilder.Entity<SurfaceCategory>().HasData(new SurfaceCategory { Id = 6, Name = "Others" });
        modelBuilder.Entity<LevelCategory>().HasData(new LevelCategory() {Id = 1, Name = "Easy"});
        modelBuilder.Entity<LevelCategory>().HasData(new LevelCategory() { Id = 2, Name = "Medium" });
        modelBuilder.Entity<LevelCategory>().HasData(new LevelCategory() { Id = 3, Name = "Advanced" });
        modelBuilder.Entity<EventCategory>()
            .HasData(new EventCategory
            { Id = 1, Name = "Bieg", Description = "Biegi krótkie, długie i takie sobie..." });
        modelBuilder.Entity<EventCategory>()
            .HasData(new EventCategory
            { Id = 2, Name = "Mecz piłki nożnej", Description = "Nic się nie stało, rodacy nic się nie stało" });
        modelBuilder.Entity<User>()
            .HasData(new User { Id = 1, FirstName = "John", LastName = "Doe" });
        modelBuilder.Entity<User>()
            .HasData(new User { Id = 2, FirstName = "Adam", LastName = "Smith" });
        modelBuilder.Entity<Event>()
            .HasData(new Event
            {
                Id = 1,
                Name = "Runmageddon",
                CreatorId = 1,
                StartDateTime = new DateTime(2022, 8, 1, 10, 0, 0),
                EndDateTime = new DateTime(2022, 8, 1, 10, 0, 0),
                EventCategoryId = 1,
                LevelCategoryId = 2,
                SurfaceCategoryId = 1,
                SurroundingCategoryId = 1
            });
        modelBuilder.Entity<Event>()
            .HasData(new Event
            {
                Id = 2,
                Name = "My kontra Wy",
                CreatorId = 2,
                StartDateTime = new DateTime(2022, 8, 1, 12, 0, 0),
                EndDateTime = new DateTime(2022, 8, 1, 14, 0, 0),
                EventCategoryId = 2,
                LevelCategoryId = 1,
                SurfaceCategoryId = 1,
                SurroundingCategoryId = 2
            });
        modelBuilder.Entity<Registration>()
            .HasData(new Registration
            {
                EventId = 1,
                UserId = 1,
                RegistrationCategoryId = 1
            });
        modelBuilder.Entity<Registration>()
            .HasData(new Registration
            {
                EventId = 1,
                UserId = 2,
                RegistrationCategoryId = 1
            });
        modelBuilder.Entity<Registration>()
            .HasData(new Registration
            {
                EventId = 2,
                UserId = 2,
                RegistrationCategoryId = 2
            });
        modelBuilder.Entity<Registration>()
            .HasData(new Registration
            {
                EventId = 2,
                UserId = 1,
                RegistrationCategoryId = 3
            });
        modelBuilder.Entity<Team>()
            .HasData(new Team
            {
                Id = 1,
                Name = "My",
            });
        modelBuilder.Entity<Team>()
            .HasData(new Team
            {
                Id = 2,
                Name = "Wy",
            });
        modelBuilder.Entity<Player>()
            .HasData(new Player
            {
                Id = 1,
                Nickname = "JD",
                UserId = 1,
                TeamId = 1,
            });
        modelBuilder.Entity<Player>()
            .HasData(new Player
            {
                Id = 2,
                Nickname = "AS",
                UserId = 2,
                TeamId = 1,
            });
        modelBuilder.Entity<Player>()
            .HasData(new Player
            {
                Id = 3,
                Nickname = "DJ",
                UserId = 1,
                TeamId = 2,
            });
        modelBuilder.Entity<Player>()
            .HasData(new Player
            {
                Id = 4,
                Nickname = "SA",
                UserId = 2,
                TeamId = 2
            });
        modelBuilder.Entity<FootballMatch>()
            .HasData(new FootballMatch
            {
                Id = 1,
                TeamAId = 1,
                TeamBId = 2,
                EventId = 2
            });
    }
}