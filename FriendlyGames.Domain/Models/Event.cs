using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriendlyGames.Domain.Enums;
using Microsoft.VisualBasic;

namespace FriendlyGames.Domain.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey(nameof(UserId))]
        public User EventCreator { get; set; }
        public int UserId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        //[ForeignKey(nameof(LocationId))]
        public Location Location { get; set; }
        public int LocationId { get; set; }
        public int MaxPLayers { get; set; }
        public List<User> CurrentPlayers { get; set; }
        public double Price { get; set; }
        public LevelType Level { get; set; }
        public string Description { get; set; }
        //[NotMapped]
        public List<User> WaitingList { get; set; }
        public SurroundingType SurroundingType { get; set; }
        public SurfaceType SurfaceType { get; set; }
    }
}
