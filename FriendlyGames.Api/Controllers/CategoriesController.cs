using AutoMapper;
using FriendlyGames.Api.Dtos;
using FriendlyGames.DataAccess;
using FriendlyGames.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FriendlyGames.Api.Controllers.CategoryControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly FriendlyGamesDbContext _dbContext;
        private readonly ILogger<CategoriesController> _logger;
        private readonly IMapper _mapper;


        public CategoriesController(IMapper mapper, ILogger<CategoriesController> logger, FriendlyGamesDbContext dbContext)
        {
            _mapper = mapper;
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Dictionary<string, object>>> GetCategories()
        {
            _logger.LogInformation($"{nameof(GetCategories)} called...");

            try
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

                return Ok(dictionary);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"Something went wrong in {nameof(GetCategories)}");

                return Problem("Internal server error, please try again later...");
            }


        }
    }
}
