using System.ComponentModel.DataAnnotations.Schema;
using FriendlyGames.Domain.Categories;
using FriendlyGames.Domain.Enums;
using FriendlyGames.Domain.Models;

namespace FriendlyGames.Api.Dtos
{
    public class EventCreateDto
    {
        public string Name { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

        public int CreatorId { get; set; }

        public int EventCategoryId { get; set; }

        public int LevelCategoryId { get; set; }


        public int SurfaceCategoryId { get; set; }
        

        public int SurroundingCategoryId { get; set; }
        
    }
}
