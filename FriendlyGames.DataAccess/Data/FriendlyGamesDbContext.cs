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
        public DbSet<Soccer> Soccer { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<User> User { get; set; }

        public FriendlyGamesDbContext(DbContextOptions options) : base(options){}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //}
    }
}
