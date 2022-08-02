using FriendlyGames.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FriendlyGames.DataAccess;

public class FriendlyGamesDbContext : DbContext
{
    public FriendlyGamesDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Event> Events { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}