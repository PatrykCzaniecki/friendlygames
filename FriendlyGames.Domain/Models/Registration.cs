using System.ComponentModel.DataAnnotations.Schema;

namespace FriendlyGames.Domain.Models;

public class Registration
{
    public Event Event { get; set; } = null!;
    [ForeignKey(nameof(EventId))]
    public int EventId { get; set; }
    public ApiUser ApiUser { get; set; } = null!;
    [ForeignKey(nameof(ApiUserId))]
    public string ApiUserId { get; set; } = string.Empty;
    public DateTime RegistrationDateTime { get; set; } = DateTime.Now;
}