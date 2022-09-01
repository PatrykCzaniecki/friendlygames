using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FriendlyGames.Domain.Categories;
using FriendlyGames.Domain.Enums;

namespace FriendlyGames.Domain.Models;

public class Event
{
    [Key] public int Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    [ForeignKey(nameof(CreatorId))] public User Creator { get; set; } = null!;
    public int CreatorId { get; set; }
    [ForeignKey(nameof(EventCategoryId))] public EventCategory EventCategory { get; set; } = null!;
    public int EventCategoryId { get; set; }
    public List<Registration> Registrations { get; set; } = new();
    public int LevelCategoryId { get; set; }
    [ForeignKey(nameof(LevelCategoryId))] public LevelCategory LevelCategory { get; set; } = null!;
    public int SurfaceCategoryId { get; set; }

    [ForeignKey(nameof(SurfaceCategoryId))]
    public SurfaceCategory SurfaceCategory { get; set; } = null!;

    public int SurroundingCategoryId { get; set; }

    [ForeignKey(nameof(SurroundingCategoryId))]
    public SurroundingCategory SurroundingCategory { get; set; } = null!;

    public int MaxNumberOfPlayers { get; set; }
    public double PriceForEvent { get; set; }
    public string Street { get; set; } = null!;
    public string City { get; set; } = null!;
    public string ImageForEvent { get; set; } = null!;
    public string Description { get; set; } = null!;
}