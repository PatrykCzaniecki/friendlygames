using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriendlyGames.Domain.Enums;

namespace FriendlyGames.Domain.Models
{
    public class Soccer : Event
    {
        public SurfaceType SurfaceType { get; set; }
        public List<Team> TeamList { get; set; }

    }
}
