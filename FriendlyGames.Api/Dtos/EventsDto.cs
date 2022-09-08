using FriendlyGames.Domain.Categories;
using FriendlyGames.Domain.Enums;
using FriendlyGames.Domain.Models;

namespace FriendlyGames.Api.Dtos;

public class EventsDto : EventCreateUpdateDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime StartDateTime { get; set; }
    public int MaxNumberOfPlayers { get; set; }
    public double PriceForEvent { get; set; }
    public string Street { get; set; } = null!;
    public string City { get; set; } = null!;
    public EventCategory EventCategory { get; set; } = null!;
    public List<Registration> Registrations { get; set; }
}