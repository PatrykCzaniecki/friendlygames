using AutoMapper;
using FriendlyGames.Api.Dtos;
using FriendlyGames.DataAccess;
using FriendlyGames.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FriendlyGames.Api.Services
{
    public class EventService : IEventService
    {
        private readonly FriendlyGamesDbContext _dbContext;
        private readonly IMapper _mapper;

        public EventService(FriendlyGamesDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IList<EventsDto>> GetEvents(int? categoryId, string? levelCategoryIds,
            string? surfaceCategoryIds, string? surroundingCategoryIds, string? payable)
        {

            var events = await FilterEvents(categoryId, levelCategoryIds, surfaceCategoryIds, surroundingCategoryIds,
                payable).ToListAsync();
            return _mapper.Map<IList<EventsDto>>(events);
        }

        private IQueryable<Event> FilterEvents(int? categoryId, string? levelCategoryIds,
            string? surfaceCategoryIds, string? surroundingCategoryIds, string? payable)
        {
            IQueryable<Event> events;
            if (categoryId != null)
            {
                events = _dbContext.Events.Where(x => x.EventCategoryId == categoryId)
                    .Include(x => x.Registrations)
                    .Include(x => x.EventCategory);
            }
            else
                events = _dbContext.Events
                    .Include(x => x.Registrations)
                    .Include(x => x.EventCategory);


            if (levelCategoryIds != null)
            {
                events = FilterByLevel(levelCategoryIds, events);
            }

            if (surfaceCategoryIds != null)
            {
                events = FilterBySurface(surfaceCategoryIds, events);
            }

            if (surroundingCategoryIds != null)
            {
                events = FilterBySurrounding(surroundingCategoryIds, events);
            }

            if (payable != null)
            {
                events = FilterByPayable(payable, events);
            }

            return events;

        }

        private IQueryable<Event> FilterByLevel(string levels, IQueryable<Event> events)

        {
            var idNumbers = ConvertStringToIntList(levels);
            return events.Where(x => idNumbers.Contains(x.LevelCategoryId));
         
        }

        private IQueryable<Event> FilterBySurface(string surface, IQueryable<Event> events)

        {
            var idNumbers = ConvertStringToIntList(surface);
            return events.Where(x => idNumbers.Contains(x.SurfaceCategoryId));
            
        }

        private IQueryable<Event> FilterBySurrounding(string surrounding, IQueryable<Event> events)

        {
            var idNumbers = ConvertStringToIntList(surrounding);
            return events.Where(x => idNumbers.Contains(x.SurroundingCategoryId));
            
        }

        private IQueryable<Event> FilterByPayable(string payable, IQueryable<Event> events)

        {
            if (payable.ToLower() == "true")
            {
                return events.Where(x => x.PriceForEvent > 0);
            }

            if (payable.ToLower() == "false")
            {
                return events.Where(x => x.PriceForEvent > 0);
            }
            return events;
            
        }

        private List<int> ConvertStringToIntList(string category)
        {
            return category.Split(',').Select(x => Convert.ToInt32(x)).ToList();
        }
    }
}
