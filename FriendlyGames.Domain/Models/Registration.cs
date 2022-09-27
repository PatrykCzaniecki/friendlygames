using System.ComponentModel.DataAnnotations.Schema;

namespace FriendlyGames.Domain.Models;

public class Registration
{
    [ForeignKey(nameof(EventId))] public Event Event { get; set; } = null!;

    public int EventId { get; set; }

    [ForeignKey(nameof(ApiUserId))] public ApiUser ApiUser { get; set; } = null!;

    public string ApiUserId { get; set; } = string.Empty;
    public DateTime RegistrationDateTime { get; set; } = DateTime.Now;
}