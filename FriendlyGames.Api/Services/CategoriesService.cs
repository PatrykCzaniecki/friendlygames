using AutoMapper;
using FriendlyGames.Api.Dtos;
using FriendlyGames.Api.Services.Interfaces;
using FriendlyGames.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FriendlyGames.Api.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly FriendlyGamesDbContext _dbContext;
        private readonly IMapper _mapper;

        public CategoriesService(FriendlyGamesDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ActionResult<Dictionary<string, object>>> GetCategories()
        {
            var eventCategories = await _dbContext.EventCategories.ToListAsync();
            var levelCategories = await _dbContext.LevelCategories.ToListAsync();
            var surfaceCategories = await _dbContext.SurfaceCategories.ToListAsync();
            var surroundingCategories = await _dbContext.SurroundingCategories.ToListAsync();

            var dictionary = new Dictionary<string, object>
            {
                {
                    "eventCategory", eventCategories
                },
                {
                    "levelCategory", levelCategories
                },
                {
                    "surfaceCategory", surfaceCategories
                },
                {
                    "surroundingCategory", surroundingCategories
                }
            };

            return dictionary;
        }

        public async Task<IList<EventCategoryDto>> GetEventCategory()
        {
            var eventCategory = await _dbContext.EventCategories.ToListAsync();
            var eventCategoryMapper = _mapper.Map<IList<EventCategoryDto>>(eventCategory);

            return eventCategoryMapper;
        }
    }
}
