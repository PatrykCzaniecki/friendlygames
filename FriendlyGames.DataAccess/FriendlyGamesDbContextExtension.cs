using FriendlyGames.Domain.Categories;
using FriendlyGames.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FriendlyGames.DataAccess
{
    public static class FriendlyGamesDbContextExtension
    {
        public static void SeedingSurroundingCategory(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SurroundingCategory>().HasData(new SurroundingCategory { Id = 1, Name = "Węwnątrz" });
            modelBuilder.Entity<SurroundingCategory>().HasData(new SurroundingCategory { Id = 2, Name = "Na zewnątrz" });
        }

        public static void SeedingSurfaceCategory(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SurfaceCategory>().HasData(new SurfaceCategory { Id = 1, Name = "Trawa" });
            modelBuilder.Entity<SurfaceCategory>().HasData(new SurfaceCategory { Id = 2, Name = "Kort" });
            modelBuilder.Entity<SurfaceCategory>().HasData(new SurfaceCategory { Id = 3, Name = "Piasek" });
            modelBuilder.Entity<SurfaceCategory>().HasData(new SurfaceCategory { Id = 4, Name = "Hala" });
            modelBuilder.Entity<SurfaceCategory>().HasData(new SurfaceCategory { Id = 5, Name = "Basen" });
            modelBuilder.Entity<SurfaceCategory>().HasData(new SurfaceCategory { Id = 6, Name = "Syntetyczna" });
            modelBuilder.Entity<SurfaceCategory>().HasData(new SurfaceCategory { Id = 7, Name = "Inne" });
        }

        public static void SeedingLevelCategory(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LevelCategory>().HasData(new LevelCategory { Id = 1, Name = "Łatwy" });
            modelBuilder.Entity<LevelCategory>().HasData(new LevelCategory { Id = 2, Name = "Średni" });
            modelBuilder.Entity<LevelCategory>().HasData(new LevelCategory { Id = 3, Name = "Zaawanzowany" });
        }

        public static void SeedingEventCategory(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventCategory>()
            .HasData(new EventCategory
            {
                Id = 1,
                Name = "Koszykówka",
                ImageForSearchBar = "ball-of-basketball.png",
                ImageForBoxWithEventInfo = "basketball-box.png"
            });
            modelBuilder.Entity<EventCategory>()
                .HasData(new EventCategory
                {
                    Id = 2,
                    Name = "Piłka Nożna",
                    ImageForSearchBar = "football.png",
                    ImageForBoxWithEventInfo = "football-box.png"
                });
            modelBuilder.Entity<EventCategory>()
                .HasData(new EventCategory
                {
                    Id = 3,
                    Name = "Siłownia",
                    ImageForSearchBar = "dumbbell.png",
                    ImageForBoxWithEventInfo = "siłownia-box.png"
                });
            modelBuilder.Entity<EventCategory>()
                .HasData(new EventCategory
                {
                    Id = 4,
                    Name = "Bieganie",
                    ImageForSearchBar = "running.png",
                    ImageForBoxWithEventInfo = "bieganie-box.png"
                });
            modelBuilder.Entity<EventCategory>()
                .HasData(new EventCategory
                {
                    Id = 5,
                    Name = "Rower",
                    ImageForSearchBar = "bicycle.png",
                    ImageForBoxWithEventInfo = "rower-box.png"
                });
            modelBuilder.Entity<EventCategory>()
                .HasData(new EventCategory
                {
                    Id = 6,
                    Name = "Siatkówka",
                    ImageForSearchBar = "siatkowka.png",
                    ImageForBoxWithEventInfo = "siatkowka-box.png"
                });
            modelBuilder.Entity<EventCategory>()
                .HasData(new EventCategory
                { Id = 7, Name = "Tenis", ImageForSearchBar = "tennis.png", ImageForBoxWithEventInfo = "tenis-box.png" });
            modelBuilder.Entity<EventCategory>()
                .HasData(new EventCategory
                {
                    Id = 8,
                    Name = "Ping Pong",
                    ImageForSearchBar = "table-tennis.png",
                    ImageForBoxWithEventInfo = "table-tennis-box.png"
                });
            modelBuilder.Entity<EventCategory>()
                .HasData(new EventCategory
                {
                    Id = 9,
                    Name = "Kręgielnia",
                    ImageForSearchBar = "bowling.png",
                    ImageForBoxWithEventInfo = "kręgle-box.png"
                });
        }

        public static void SeedingIdentityRole(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>()
                .HasData(new IdentityRole { Name = "User", NormalizedName = "USER" });
            modelBuilder.Entity<IdentityRole>()
                .HasData(new IdentityRole { Name = "Administrator", NormalizedName = "ADMINISTRATOR" });
        }

        public static void DefiningRelationsAndTypeConversions(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Registration>()
                .HasKey(r => new { r.EventId, UserId = r.ApiUserId });
            modelBuilder.Entity<Registration>()
                .HasOne(r => r.Event)
                .WithMany(e => e.Registrations)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Registration>()
                .HasOne(r => r.ApiUser)
                .WithMany(u => u.Registrations)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}