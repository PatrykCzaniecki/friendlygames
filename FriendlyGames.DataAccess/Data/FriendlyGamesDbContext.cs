using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriendlyGames.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FriendlyGames.DataAccess.Data
{
    public class FriendlyGamesDbContext : DbContext
    {
        public DbSet<Location> Locations { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }

        public FriendlyGamesDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           /*base.OnModelCreating(modelBuilder);
           modelBuilder.Entity<Soccer>().*/
           modelBuilder.Entity<User>().HasMany(U => U.EventsHistory).WithMany(E => E.CurrentPlayers);
           modelBuilder.Entity<Event>().HasOne(E => E.EventCreator);
        }
    }
}
