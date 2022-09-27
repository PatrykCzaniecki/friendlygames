using FriendlyGames.Api.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FriendlyGames.Api.Services.Interfaces;

public interface ICategoriesService
{
    Task<ActionResult<Dictionary<string, object>>> GetCategories();
    Task<IList<EventCategoryDto>> GetEventCategory();
}