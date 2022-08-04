using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FriendlyGames.Domain.Models;

public class FootballMatch
{
    [Key] public int EventId { get; set; }

    [ForeignKey(nameof(EventId))] public Event Event { get; set; }

    public int Id { get; set; }

    [ForeignKey(nameof(TeamAId))] public Team TeamA { get; set; }

    public int TeamAId { get; set; }

    [ForeignKey(nameof(TeamBId))] public Team TeamB { get; set; }

    public int TeamBId { get; set; }
}