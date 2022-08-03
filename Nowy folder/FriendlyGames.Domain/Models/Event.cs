using System.ComponentModel.DataAnnotations.Schema;

namespace FriendlyGames.Domain.Models;

public class Event
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    [ForeignKey(nameof(CreatorId))]
    public User Creator { get; set; } = null!;
    public int CreatorId { get; set; }
    [ForeignKey(nameof(EventCategoryId))]
    public EventCategory EventCategory { get; set; }
    public int EventCategoryId { get; set; }
    public List<Registration> Registrations { get; set; } = new List<Registration>();
}