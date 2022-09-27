using FriendlyGames.Domain.Categories;
using FriendlyGames.Domain.Models;

namespace FriendlyGames.Api.Dtos;

public class EventsDto : EventCreateUpdateDto
{
    public int Id { get; set; }
    public new string Name { get; set; } = null!;
    public new DateTime StartDateTime { get; set; }
    public new int MaxNumberOfPlayers { get; set; }
    public new double PriceForEvent { get; set; }
    public new string Street { get; set; } = null!;
    public new string City { get; set; } = null!;
    public EventCategory EventCategory { get; set; } = null!;
    public List<Registration> Registrations { get; set; } = null!;
}