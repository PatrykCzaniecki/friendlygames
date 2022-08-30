using FriendlyGames.Domain.Categories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendlyGames.Domain.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int EventId { get; set; }
        [ForeignKey(nameof(EventId))] public Event Event { get; set; }
    }
}
