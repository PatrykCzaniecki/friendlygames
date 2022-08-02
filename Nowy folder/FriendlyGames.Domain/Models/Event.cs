using FriendlyGames.Domain.Enums;

namespace FriendlyGames.Domain.Models;

public class Event
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public LevelType Level { get; set; }
    public double Price { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public int MaxPLayers { get; set; }
    public SurroundingType SurroundingType { get; set; }

    public SurfaceType SurfaceType { get; set; }

    //public User EventCreator { get; set; }
    public Location Location { get; set; }
    //public List<User> CurrentPlayers { get; set; }
    //public List<User> WaitingList { get; set; }
}