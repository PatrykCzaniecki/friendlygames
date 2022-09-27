using AutoMapper;
using FriendlyGames.Api.Dtos;
using FriendlyGames.Api.Services.Interfaces;
using FriendlyGames.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FriendlyGames.Api.Services;

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
        var eventCategories = await (_dbContext.EventCategories ?? throw new InvalidOperationException()).ToListAsync();
        var levelCategories = await (_dbContext.LevelCategories ?? throw new InvalidOperationException()).ToListAsync();
        var surfaceCategories =
            await (_dbContext.SurfaceCategories ?? throw new InvalidOperationException()).ToListAsync();
        var surroundingCategories =
            await (_dbContext.SurroundingCategories ?? throw new InvalidOperationException()).ToListAsync();

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
        var eventCategory = await (_dbContext.EventCategories ?? throw new InvalidOperationException()).ToListAsync();
        var eventCategoryMapper = _mapper.Map<IList<EventCategoryDto>>(eventCategory);

        return eventCategoryMapper;
    }
}