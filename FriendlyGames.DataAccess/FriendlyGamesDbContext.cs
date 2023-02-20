﻿using FriendlyGames.Domain.Categories;
using FriendlyGames.Domain.Enums;
using FriendlyGames.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FriendlyGames.DataAccess;

public class FriendlyGamesDbContext : IdentityDbContext<User>
{
    public FriendlyGamesDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<EventCategory> EventCategories { get; set; }
    public DbSet<SurfaceCategory> SurfaceCategories { get; set; }
    public DbSet<SurroundingCategory> SurroundingCategories { get; set; }
    public DbSet<RegistrationCategory> RegistrationCategories { get; set; }
    public DbSet<LevelCategory> LevelCategories { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Registration> Registrations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Defining relations and type conversions
        modelBuilder.Entity<Registration>()
            .HasKey(r => new {r.EventId, r.UserId});
        modelBuilder.Entity<Registration>()
            .HasOne(r => r.Event)
            .WithMany(e => e.Registrations)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Registration>()
            .HasOne(r => r.User)
            .WithMany(u => u.Registrations)
            .OnDelete(DeleteBehavior.Restrict);

        // Seeding data //jak seedujesz dane to daj to do osobnej metody wtedy nie musisz uzywac komentarzy
        modelBuilder.Entity<RegistrationCategory>().HasData(new RegistrationCategory {Id = 1, Name = "Oczekujące"});
        modelBuilder.Entity<RegistrationCategory>().HasData(new RegistrationCategory {Id = 2, Name = "Zaakceptowane"});
        modelBuilder.Entity<RegistrationCategory>().HasData(new RegistrationCategory {Id = 3, Name = "Odrzucone"});
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
                {Id = 1, Name = "Koszykówka", ImageForSearchBar = "ball-of-basketball.png", ImageForBoxWithEventInfo = "basketball-box.png"});
        modelBuilder.Entity<EventCategory>()
            .HasData(new EventCategory
                {Id = 2, Name = "Piłka Nożna", ImageForSearchBar = "football.png", ImageForBoxWithEventInfo = "football-box.png" });
        modelBuilder.Entity<EventCategory>()
            .HasData(new EventCategory
                {Id = 3, Name = "Siłownia", ImageForSearchBar = "dumbbell.png", ImageForBoxWithEventInfo = "siłownia-box.png" });
        modelBuilder.Entity<EventCategory>()
            .HasData(new EventCategory
                {Id = 4, Name = "Bieganie", ImageForSearchBar = "running.png", ImageForBoxWithEventInfo = "bieganie-box.png" });
        modelBuilder.Entity<EventCategory>()
            .HasData(new EventCategory
                {Id = 5, Name = "Rower", ImageForSearchBar = "bicycle.png", ImageForBoxWithEventInfo = "rower-box.png" });
        modelBuilder.Entity<EventCategory>()
            .HasData(new EventCategory
                {Id = 6, Name = "Siatkówka", ImageForSearchBar = "siatkowka.png", ImageForBoxWithEventInfo = "siatkowka-box.png" });
        modelBuilder.Entity<EventCategory>()
            .HasData(new EventCategory
                {Id = 7, Name = "Tenis", ImageForSearchBar = "tennis.png", ImageForBoxWithEventInfo = "tenis-box.png" });
        modelBuilder.Entity<EventCategory>()
            .HasData(new EventCategory
                {Id = 8, Name = "Ping Pong", ImageForSearchBar = "table-tennis.png", ImageForBoxWithEventInfo = "table-tennis-box.png" });
        modelBuilder.Entity<EventCategory>()
            .HasData(new EventCategory
                {Id = 9, Name = "Kręgielnia", ImageForSearchBar = "bowling.png", ImageForBoxWithEventInfo = "kręgle-box.png" });
        /*modelBuilder.Entity<User>()
            .HasData(new User {Id = 1, FirstName = "John", LastName = "Doe"}); //zbedny komentarz do usuniecia
        modelBuilder.Entity<User>()
            .HasData(new User {Id = 2, FirstName = "Adam", LastName = "Smith"});
        modelBuilder.Entity<User>()
            .HasData(new User {Id = 3, FirstName = "Franek", LastName = "Stopka"});
        modelBuilder.Entity<User>()
            .HasData(new User {Id = 4, FirstName = "Asia", LastName = "Szul"});
        modelBuilder.Entity<User>()
            .HasData(new User {Id = 5, FirstName = "Tomek", LastName = "Broda"});
        modelBuilder.Entity<User>()
            .HasData(new User {Id = 6, FirstName = "Grzegorz", LastName = "Wisła"});
        modelBuilder.Entity<Event>()
            .HasData(new Event
            {
                Id = 1,
                Name = "Koszykówka",
                CreatorId = 1,
                StartDateTime = new DateTime(2022, 8, 1, 10, 0, 0),
                EndDateTime = new DateTime(2022, 8, 1, 10, 0, 0),
                EventCategoryId = 1,
                LevelCategoryId = 2,
                SurfaceCategoryId = 6,
                SurroundingCategoryId = 2,
                MaxNumberOfPlayers = 8,
                PriceForEvent = 30.0,
                City = "Tarnów",
                Street = "Piłsudskiego 24",
                Description = "Szukam osób do gry w kosza"
            });
        modelBuilder.Entity<Event>()
            .HasData(new Event
            {
                Id = 2,
                Name = "Piłka Nożna",
                CreatorId = 2,
                StartDateTime = new DateTime(2022, 8, 1, 12, 0, 0),
                EndDateTime = new DateTime(2022, 8, 1, 14, 0, 0),
                EventCategoryId = 2,
                LevelCategoryId = 1,
                SurfaceCategoryId = 1,
                SurroundingCategoryId = 2,
                MaxNumberOfPlayers = 10,
                PriceForEvent = 0.0,
                City = "Kraków",
                Street = "Grzegórzecka 24",
                Description = "Orlikowe granie"
            });
        modelBuilder.Entity<Event>()
            .HasData(new Event
            {
                Id = 3,
                Name = "Siłownia",
                CreatorId = 3,
                StartDateTime = new DateTime(2022, 8, 1, 12, 0, 0),
                EndDateTime = new DateTime(2022, 8, 1, 14, 0, 0),
                EventCategoryId = 3,
                LevelCategoryId = 2,
                SurfaceCategoryId = 3,
                SurroundingCategoryId = 2,
                MaxNumberOfPlayers = 10,
                PriceForEvent = 0.0,
                City = "Żywiec",
                Street = "Kazimierza Tetmajera 75",
                Description = "Ciężki trening"
            });
        modelBuilder.Entity<Event>()
            .HasData(new Event
            {
                Id = 4,
                Name = "Bieganie",
                CreatorId = 4,
                StartDateTime = new DateTime(2022, 8, 1, 12, 0, 0),
                EndDateTime = new DateTime(2022, 8, 1, 14, 0, 0),
                EventCategoryId = 4,
                LevelCategoryId = 3,
                SurfaceCategoryId = 7,
                SurroundingCategoryId = 2,
                MaxNumberOfPlayers = 3,
                PriceForEvent = 0.0,
                City = "Wrocław",
                Street = "Różanka",
                Description = "Sprinty na 200m"
            });
        modelBuilder.Entity<Event>()
            .HasData(new Event
            {
                Id = 5,
                Name = "Rower",
                CreatorId = 5,
                StartDateTime = new DateTime(2022, 8, 1, 12, 0, 0),
                EndDateTime = new DateTime(2022, 8, 1, 14, 0, 0),
                EventCategoryId = 5,
                LevelCategoryId = 2,
                SurfaceCategoryId = 7,
                SurroundingCategoryId = 2,
                MaxNumberOfPlayers = 15,
                PriceForEvent = 10.0,
                City = "Szczecin",
                Street = "Modra 104",
                Description = "Nauka jazdy na jednym kole"
            });
        modelBuilder.Entity<Event>()
            .HasData(new Event
            {
                Id = 6,
                Name = "Kręgle",
                CreatorId = 6,
                StartDateTime = new DateTime(2022, 8, 1, 12, 0, 0),
                EndDateTime = new DateTime(2022, 8, 1, 14, 0, 0),
                EventCategoryId = 9,
                LevelCategoryId = 1,
                SurfaceCategoryId = 4,
                SurroundingCategoryId = 1,
                MaxNumberOfPlayers = 4,
                PriceForEvent = 16.0,
                City = "Warszawa",
                Street = "Vincenta van Gogha 1",
                Description = "Sobotni chill"
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
        modelBuilder.Entity<Registration>()
            .HasData(new Registration
            {
                EventId = 3,
                UserId = 3,
                RegistrationCategoryId = 2
            });
        modelBuilder.Entity<Registration>()
            .HasData(new Registration
            {
                EventId = 4,
                UserId = 4,
                RegistrationCategoryId = 2
            });
        modelBuilder.Entity<Registration>()
            .HasData(new Registration
            {
                EventId = 5,
                UserId = 5,
                RegistrationCategoryId = 2
            });
        modelBuilder.Entity<Registration>()
            .HasData(new Registration
            {
                EventId = 6,
                UserId = 6,
                RegistrationCategoryId = 2
            });*/
    }
}
