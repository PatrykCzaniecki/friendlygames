namespace FriendlyGames.Domain.Models;

public class Team
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Player> Players { get; set; }
    public List<FootballMatch> MatchesA { get; set; }
    public List<FootballMatch> MatchesB { get; set; }
}