using Microsoft.AspNetCore.Identity;

namespace FriendlyGames.Domain.Models;

public class ApiUser : IdentityUser
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public List<Registration> Registrations { get; set; } = new();
}