using FriendlyGames.Api.Dtos;
using FriendlyGames.Domain.Models;

namespace FriendlyGames.Api.Services;

public interface IEventService
{
    Task<IList<EventsDto>> FilterByLevel(string levels, IList<EventsDto> events);
    Task<IList<EventsDto>> FilterBySurface(string surface, IList<EventsDto> events);

    Task<IList<EventsDto>> FilterBySurrounding(string surrounding, IList<EventsDto> events);

    Task<IList<EventsDto>> FilterByPayable(string payable, IList<EventsDto> events);

}