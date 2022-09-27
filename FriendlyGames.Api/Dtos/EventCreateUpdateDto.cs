namespace FriendlyGames.Api.Dtos;

public class EventCreateUpdateDto
{
    public string Name { get; set; } = null!;
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public string ApiUserId { get; set; } = null!;
    public int MaxNumberOfPlayers { get; set; }
    public double PriceForEvent { get; set; }
    public string Street { get; set; } = null!;
    public string City { get; set; } = null!;
    public int EventCategoryId { get; set; }
    public int LevelCategoryId { get; set; }
    public int SurfaceCategoryId { get; set; }
    public int SurroundingCategoryId { get; set; }
}