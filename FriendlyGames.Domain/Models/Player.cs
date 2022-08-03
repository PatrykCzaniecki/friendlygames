using System.ComponentModel.DataAnnotations.Schema;

namespace FriendlyGames.Domain.Models;

public class Player
{
    public int Id { get; set; }
    public string Nickname { get; set; }
    [ForeignKey(nameof(UserId))]
    public User User { get; set; } = null!;
    public int UserId { get; set; }
    [ForeignKey(nameof(TeamId))]
    public Team Team { get; set; } = null!;
    public int TeamId { get; set; }
}