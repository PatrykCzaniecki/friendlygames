using FriendlyGames.Domain.Categories;
using FriendlyGames.Domain.Enums;
using FriendlyGames.Domain.Models;

namespace FriendlyGames.Api.Dtos;

public class EventDto : EventCreateDto
{
    public User Creator { get; set; }
    public EventCategory EventCategory { get; set; }
    public List<Registration> Registrations { get; set; }
    public LevelCategory LevelCategory { get; set; }
    public SurfaceCategory SurfaceCategory { get; set; }
    public SurroundingCategory SurroundingCategory { get; set; }
}