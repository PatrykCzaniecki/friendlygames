namespace FriendlyGames.Api.Dtos;

public class RegistrationCreateUpdateDto
{
    public int EventId { get; set; }
    public string UserId { get; set; }
    public DateTime RegistrationDateTime { get; set; } = DateTime.Now;
    public int RegistrationCategoryId { get; set; }
}