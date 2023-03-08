using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FriendlyGames.Domain.Categories;

namespace FriendlyGames.Domain.Models;

public class Event
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public DateTime StartDateTime { get; set; }
    [Required]
    public DateTime EndDateTime { get; set; }
    public ApiUser ApiUser { get; set; } = null!;
    [ForeignKey(nameof(ApiUserId))]
    public string ApiUserId { get; set; } = null!;
    [Required]
    public EventCategory EventCategory { get; set; } = null!;
    [ForeignKey(nameof(EventCategoryId))]
    public int EventCategoryId { get; set; }
    public List<Registration> Registrations { get; set; } = new();
    [Required]
    public LevelCategory LevelCategory { get; set; } = null!;
    [ForeignKey(nameof(LevelCategoryId))]
    public int LevelCategoryId { get; set; }
    [Required]
    public SurfaceCategory SurfaceCategory { get; set; } = null!;
    [ForeignKey(nameof(SurfaceCategoryId))]
    public int SurfaceCategoryId { get; set; }
    [Required]
    public SurroundingCategory SurroundingCategory { get; set; } = null!;
    [ForeignKey(nameof(SurroundingCategoryId))]
    public int SurroundingCategoryId { get; set; }
    public int MaxNumberOfPlayers { get; set; }
    public double PriceForEvent { get; set; }
    public string Street { get; set; } = null!;
    public string City { get; set; } = null!;
}