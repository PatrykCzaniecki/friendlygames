using FriendlyGames.Api.Dtos;
using FriendlyGames.Domain.Models;

namespace FriendlyGames.Api.Services
{
    public class EventService : IEventService
    {
        public async Task<IList<EventsDto>> FilterByLevel(string levels, IList<EventsDto>events)

        {
            var idNumbers = ConvertStringToIntList(levels);
            var filteredEvents = events.Where(x => idNumbers.Contains(x.LevelCategoryId));
            return await Task.FromResult(filteredEvents.ToList());
        }

        public async Task<IList<EventsDto>> FilterBySurface(string surface, IList<EventsDto> events)

        {
            var idNumbers = ConvertStringToIntList(surface);
            var filteredEvents = events.Where(x => idNumbers.Contains(x.SurfaceCategoryId));
            return await Task.FromResult(filteredEvents.ToList());
        }

        public async Task<IList<EventsDto>> FilterBySurrounding(string surrounding, IList<EventsDto> events)

        {
            var idNumbers = ConvertStringToIntList(surrounding);
            var filteredEvents = events.Where(x => idNumbers.Contains(x.SurroundingCategoryId));
            return await Task.FromResult(filteredEvents.ToList());
        }

        public async Task<IList<EventsDto>> FilterByPayable(string payable, IList<EventsDto> events)

        {
            IEnumerable<EventsDto> filteredEvents = new List<EventsDto>();
            if (payable.ToLower() == "true")
            {
                filteredEvents = events.Where(x => x.PriceForEvent > 0);
            }
            else
            {
                filteredEvents = events.Where(x => x.PriceForEvent == 0);
            }
            ;
            return await Task.FromResult(filteredEvents.ToList());
        }

        private List<int> ConvertStringToIntList(string category)
        {
            var levelIds = new List<int>();
            foreach (var id in category)
            {
                levelIds.Add(Convert.ToInt32(Convert.ToString(id)));
            }

            return levelIds;
        }
    }
}
