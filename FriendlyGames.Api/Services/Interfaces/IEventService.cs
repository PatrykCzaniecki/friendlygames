using FriendlyGames.Api.Dtos;

namespace FriendlyGames.Api.Services;

public interface IEventService
{
    Task<IList<EventsDto>> GetEvents(int? categoryId, string? levelCategoryIds,
        string? surfaceCategoryIds, string? surroundingCategoryIds, string? payable);
}