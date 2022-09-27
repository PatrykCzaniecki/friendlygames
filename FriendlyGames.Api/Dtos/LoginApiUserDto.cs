using System.ComponentModel.DataAnnotations;

namespace FriendlyGames.Api.Dtos;

public class LoginApiUserDto
{
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    [Required]
    [StringLength(20, ErrorMessage = "Your password is limited to {2} to {1} characters", MinimumLength = 5)]
    public string Password { get; set; } = null!;
}