using System.ComponentModel.DataAnnotations;

namespace FriendlyGames.Api.Dtos;

public class RegisterApiUserDto : LoginApiUserDto
{
    [Required] public string FirstName { get; set; } = null!;

    [Required] public string LastName { get; set; } = null!;

    public ICollection<string> Roles { get; set; } = null!;
}