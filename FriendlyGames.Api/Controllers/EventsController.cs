using AutoMapper;
using FriendlyGames.Api.Dtos;
using FriendlyGames.DataAccess;
using FriendlyGames.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FriendlyGames.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventsController : ControllerBase
{
    private readonly FriendlyGamesDbContext _dbContext;
    private readonly ILogger<EventsController> _logger;
    private readonly IMapper _mapper;

    public EventsController(IMapper mapper, ILogger<EventsController> logger, FriendlyGamesDbContext dbContext)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _logger = logger;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<EventUpdateDto>>> GetEvents()
    {
        _logger.LogInformation($"{nameof(GetEvents)} called...");

        try
        {
            var allEvents = await _dbContext.Events.Include(x => x.Creator)
                .Include(x => x.EventCategory)
                .Include(x => x.Registrations)
                .Include(x => x.LevelCategory)
                .Include(x => x.SurfaceCategory)
                .Include(x => x.SurroundingCategory)
                .Include(x => x.Location)
                .ToListAsync();
            //var results = _mapper.Map<IList<EventUpdateDto>>(allEvents);
            return Ok(allEvents);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, $"Something went wrong in {nameof(GetEvents)}");

            return Problem("Internal server error, please try again later...");
        }
    }

    [HttpGet("{id:int}", Name = "GetEvent")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<EventUpdateDto>> GetEvent(int id)
    {
        _logger.LogInformation($"{nameof(GetEvent)} called...");

        try
        {
            var registrations = await _dbContext.Registrations.Include(x => x.RegistrationCategory)
                .Include(x => x.User)
                .Where(e => e.EventId == id).ToListAsync();

            var specificEvent = await _dbContext.Events.Include(x => x.Creator)
                .Include(x => x.EventCategory)
                .Include(x => x.Registrations)
                .Include(x => x.LevelCategory)
                .Include(x => x.SurfaceCategory)
                .Include(x => x.SurroundingCategory)
                .Include(x => x.Location)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (specificEvent == null) return NotFound("Not found that specific event");

            specificEvent.Registrations = registrations;

            //var result = _mapper.Map<EventUpdateDto>(specificEvent);

            return Ok(specificEvent);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, $"Something went wrong in {nameof(GetEvent)}");

            return Problem("Internal server error, please try again later...");
        }
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateEvent([FromBody] EventCreateUpdateDto eventCreateUpdateDto)
    {
        _logger.LogInformation($"{nameof(CreateEvent)} called...");

        if (!ModelState.IsValid)
        {
            _logger.LogError($"Invalid POST attempt in {nameof(CreateEvent)}");

            return BadRequest(ModelState);
        }

        try
        {
            var newEvent = _mapper.Map<Event>(eventCreateUpdateDto);
            await _dbContext.Events.AddAsync(newEvent);
            await _dbContext.SaveChangesAsync();

            return CreatedAtRoute("CreateEvent", new {id = newEvent.Id}, newEvent);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, $"Something went wrong in {nameof(CreateEvent)}");
            return Problem("Internal server error, please try again later...");
        }
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateEvent([FromBody] EventCreateUpdateDto eventUpdateDto, int id)
    {
        _logger.LogInformation($"{nameof(UpdateEvent)} called...");

        if (!ModelState.IsValid)
        {
            _logger.LogError($"Invalid PUT attempt in {nameof(CreateEvent)}");
            return BadRequest(ModelState);
        }

        try
        {
            var eventToEdit = await _dbContext.Events
                .FirstOrDefaultAsync(e => e.Id == id);

            if (eventToEdit == null) return BadRequest("Submitted data is invalid!");
            _mapper.Map(eventUpdateDto, eventToEdit);

            await _dbContext.SaveChangesAsync();

            return Ok(eventUpdateDto);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, $"Something went wrong in {nameof(UpdateEvent)}");
            return Problem("Internal server error, please try again later...");
        }
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteEvent(int id)
    {
        _logger.LogInformation($"{nameof(DeleteEvent)} called...");

        if (id < 1)
        {
            _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteEvent)}");

            return BadRequest();
        }

        try
        {
            var registrations = await _dbContext.Registrations.Include(x => x.RegistrationCategory)
                .Include(x => x.User)
                .Where(e => e.EventId == id).ToListAsync();

            var specificEvent = await _dbContext.Events.Include(x => x.Creator)
                .Include(x => x.EventCategory)
                .Include(x => x.Registrations)
                .Include(x => x.LevelCategory)
                .Include(x => x.SurfaceCategory)
                .Include(x => x.SurroundingCategory)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (specificEvent == null) return NotFound($"There is no country with id = {id}");

            foreach (var registration in registrations) _dbContext.Registrations.Remove(registration);
            _dbContext.Events.Remove(specificEvent);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, $"Something went wrong in {nameof(DeleteEvent)}");

            return Problem("Internal server error, please try again later...");
        }
    }
}