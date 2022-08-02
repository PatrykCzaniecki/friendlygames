namespace FriendlyGames.Domain.Models;

public class Team
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<User> CurrentPlayers { get; set; }
    public int MaxPlayers { get; set; }
}