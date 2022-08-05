using AutoMapper;
using FriendlyGames.Api.Dtos;
using FriendlyGames.DataAccess;
using FriendlyGames.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FriendlyGames.Api.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class EventController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ILogger<EventController> _logger;
        private readonly FriendlyGamesDbContext _dbContext;

        public EventController(IMapper mapper, ILogger<EventController> logger, FriendlyGamesDbContext dbContext)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
            this._logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateEvent([FromBody] EventCreateDto eventCreateDto)
        {

            _logger.LogInformation($"{nameof(CreateEvent)} called...");

            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateEvent)}");

                return BadRequest(ModelState);
            }

            try
            {
                
                var newEvent = _mapper.Map<Event>(eventCreateDto);
                await _dbContext.Events.AddAsync(newEvent);
                await _dbContext.SaveChangesAsync();

                return Ok();

                /*return CreatedAtRoute("GetEvent", new { id = newEvent.Id }, newEvent);*/
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"Something went wrong in {nameof(CreateEvent)}");

                return Problem("Internal server error, please try again later...");
            }
        }
    }
}
