using System.ComponentModel.DataAnnotations;
using FriendlyGames.Domain.Categories;
using System.ComponentModel.DataAnnotations.Schema;
using FriendlyGames.Domain.Enums;

namespace FriendlyGames.Domain.Models;

public class Event
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    [ForeignKey(nameof(CreatorId))]
    public User Creator { get; set; } = null!;
    public int CreatorId { get; set; }
    [ForeignKey(nameof(EventCategoryId))]
    public EventCategory EventCategory { get; set; }
    public int EventCategoryId { get; set; }
    public List<Registration> Registrations { get; set; } = new List<Registration>();

    public int LevelCategoryId { get; set; }
    
    [ForeignKey(nameof(LevelCategoryId))]
    public LevelCategory LevelCategory { get; set; }

    public int SurfaceCategoryId { get; set; }
    [ForeignKey(nameof(SurfaceCategoryId))]
    public SurfaceCategory SurfaceCategory { get; set; }

    public int SurroundingCategoryId { get; set; }
    [ForeignKey(nameof(SurroundingCategoryId))]
    public SurroundingCategory SurroundingCategory { get; set; }



}