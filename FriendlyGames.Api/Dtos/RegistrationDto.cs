using FriendlyGames.Domain.Enums;
using FriendlyGames.Domain.Models;

namespace FriendlyGames.Api.Dtos
{
    public class RegistrationDto
    {
        public Event Event { get; set; } = null!;
        public User User { get; set; } = null!;
        public DateTime RegistrationDateTime { get; set; } = DateTime.Now;
        public RegistrationCategory RegistrationCategory { get; set; }
    }
}
