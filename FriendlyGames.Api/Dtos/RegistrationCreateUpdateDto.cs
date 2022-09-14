namespace FriendlyGames.Api.Dtos;

public class RegistrationCreateUpdateDto
{
    public int EventId { get; set; }
    public string ApiUserId { get; set; }
    public DateTime RegistrationDateTime { get; set; } = DateTime.Now;
}