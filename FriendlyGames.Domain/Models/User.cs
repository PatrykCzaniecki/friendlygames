using System.ComponentModel.DataAnnotations;

namespace FriendlyGames.Domain.Models;

public class User
{
    [Key] public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public List<Registration> Registrations { get; set; } = new();
}