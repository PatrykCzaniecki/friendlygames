namespace FriendlyGames.Domain.Models;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public List<Registration> Registrations { get; set; } = new List<Registration>();
}