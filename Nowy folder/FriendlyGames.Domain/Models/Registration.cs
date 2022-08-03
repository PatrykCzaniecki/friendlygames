using FriendlyGames.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace FriendlyGames.Domain.Models;

public class Registration
{
    [ForeignKey(nameof(EventId))]
    public Event Event { get; set; } = null!;
    public int EventId { get; set; }
    [ForeignKey(nameof(UserId))]
    public User User { get; set; } = null!;
    public int UserId { get; set; }
    public DateTime RegistrationDateTime { get; set; } = DateTime.Now;
    public RegistrationStatus RegistrationStatus { get; set; } = RegistrationStatus.Waiting;
    public RegistrationStatus RegistrationStatusAsString
    {
        get => RegistrationStatus;
        set => RegistrationStatus = value;
    }
}