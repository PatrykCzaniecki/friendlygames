namespace FriendlyGames.Domain.Categories;

public class EventCategory
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string ImageForSearchBar { get; set; } = null!;
    public string ImageForBoxWithEventInfo { get; set; } = null!;
}