namespace FriendlyGames.Api.Dtos;

public class EventCreateUpdateDto
{
    public string Name { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public int CreatorId { get; set; }
    public int MaxNumberOfPlayers { get; set; }
    public double PriceForEvent { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public int EventCategoryId { get; set; }
    public int LevelCategoryId { get; set; }
    public int SurfaceCategoryId { get; set; }
    public int SurroundingCategoryId { get; set; }
    public string ImageForEvent { get; set; }
}