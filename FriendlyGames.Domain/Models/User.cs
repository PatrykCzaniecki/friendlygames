using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendlyGames.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string NickName { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<Event> EventsHistory { get; set; }

        /*get
        {
            return EventsHistory;
        }
        set
        {
            foreach (var Event in ActualEvents)
            {
                //do przetestowania czy data sie zgadza
                if (Event.EndTime >= DateTime.Now)
                {
                    EventsHistory.Add(Event);
                }
            }
        }*/

        [NotMapped]
        public List<Event> ActualEvents { get; set; }
    }
}
