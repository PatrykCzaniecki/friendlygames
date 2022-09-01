using AutoMapper;
using FriendlyGames.Api.Dtos;
using FriendlyGames.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FriendlyGames.Api.Controllers.CategoryControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SurroundingsController : ControllerBase
    {
        private readonly FriendlyGamesDbContext _dbContext;
        private readonly ILogger<SurroundingsController> _logger;
        private readonly IMapper _mapper;

        public SurroundingsController(IMapper mapper, ILogger<SurroundingsController> logger, FriendlyGamesDbContext dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet(Name = "GetSurroundings")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<SurroundingsDto>> GetSurroundings()
        {
            _logger.LogInformation($"{nameof(GetSurroundings)} called...");

            try
            {
                var surroundings = await _dbContext.SurroundingCategories.ToListAsync();

                //if (surroundings == null) return NotFound("Not found that surroundings");

                return Ok(surroundings);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"Something went wrong in {nameof(GetSurroundings)}");

                return Problem("Internal server error, please try again later...");
            }
        }
    }
}