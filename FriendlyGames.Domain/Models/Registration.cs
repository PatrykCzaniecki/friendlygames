using System.ComponentModel.DataAnnotations.Schema;
using FriendlyGames.Domain.Enums;

namespace FriendlyGames.Domain.Models;

public class Registration
{
    [ForeignKey(nameof(EventId))] 
    public Event Event { get; set; } = null!;
    public int EventId { get; set; }
    [ForeignKey(nameof(ApiUserId))] 
    public ApiUser ApiUser { get; set; } = null!;
    public string ApiUserId { get; set; }
    public DateTime RegistrationDateTime { get; set; } = DateTime.Now;

}