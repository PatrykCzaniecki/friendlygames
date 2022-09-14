using FriendlyGames.Domain.Enums;
using FriendlyGames.Domain.Models;

namespace FriendlyGames.Api.Dtos;

public class RegistrationDto
{
    public Event Event { get; set; } = null!;
    public ApiUser ApiUser { get; set; } = null!;
    public DateTime RegistrationDateTime { get; set; } = DateTime.Now;
}