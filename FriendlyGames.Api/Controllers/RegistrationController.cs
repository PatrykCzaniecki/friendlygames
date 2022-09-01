using AutoMapper;
using FriendlyGames.Api.Dtos;
using FriendlyGames.DataAccess;
using FriendlyGames.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FriendlyGames.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RegistrationController : ControllerBase
{
    private readonly FriendlyGamesDbContext _dbContext;
    private readonly ILogger<EventsController> _logger;
    private readonly IMapper _mapper;

    public RegistrationController(IMapper mapper, ILogger<EventsController> logger, FriendlyGamesDbContext dbContext)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _logger = logger;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<RegistrationCreateUpdateDto>>> Get()
    {
        _logger.LogInformation($"{nameof(Get)} called...");

        try
        {
            var allRegistration = await _dbContext.Registrations
                .Include(x => x.User)
                .Include(x => x.RegistrationCategory)
                .Include(x => x.Event)
                .ThenInclude(x => x.Creator)
                .ToListAsync();
            var results = _mapper.Map<IList<RegistrationDto>>(allRegistration);
            return Ok(results);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, $"Something went wrong in {nameof(Get)}");

            return Problem("Internal server error, please try again later...");
        }
    }

    [HttpGet("{eventId}/{userId}", Name = "GetRegistration")]
    public async Task<ActionResult<EventsDto>> GetRegistration(int eventId, int userId)
    {
        _logger.LogInformation($"{nameof(GetRegistration)} called...");

        try
        {
            var registration = await _dbContext.Registrations
                .Include(x => x.User)
                .Include(x => x.RegistrationCategory)
                .Include(x => x.Event)
                .ThenInclude(x => x.Creator)
                .FirstOrDefaultAsync(x => x.EventId == eventId && x.UserId == userId);

            if (registration == null) return NotFound("Not found that specific registration");

            var result = _mapper.Map<RegistrationDto>(registration);

            return Ok(result);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, $"Something went wrong in {nameof(GetRegistration)}");

            return Problem("Internal server error, please try again later...");
        }
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateRegistration([FromBody] RegistrationCreateUpdateDto registrationCreateDto)
    {
        _logger.LogInformation($"{nameof(CreateRegistration)} called...");

        if (!ModelState.IsValid)
        {
            _logger.LogError($"Invalid POST attempt in {nameof(CreateRegistration)}");

            return BadRequest(ModelState);
        }

        try
        {
            var newRegistration = _mapper.Map<Registration>(registrationCreateDto);
            await _dbContext.Registrations.AddAsync(newRegistration);
            await _dbContext.SaveChangesAsync();


            return
                CreatedAtRoute("GetRegistration",
                    new {eventId = newRegistration.EventId, userId = newRegistration.UserId}, newRegistration);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, $"Something went wrong in {nameof(CreateRegistration)}");

            return Problem("Internal server error, please try again later...");
        }
    }

    [HttpDelete("{eventId}/{userId}", Name = "Delete")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete(int eventId, int userId)
    {
        _logger.LogInformation($"{nameof(Delete)} called...");

        if (eventId < 1 || userId < 1)
        {
            _logger.LogError($"Invalid DELETE attempt in {nameof(Delete)}");

            return BadRequest();
        }

        try
        {
            var registration = await _dbContext.Registrations
                .Include(x => x.User)
                .Include(x => x.RegistrationCategory)
                .Include(x => x.Event)
                .ThenInclude(x => x.Creator)
                .FirstOrDefaultAsync(x => x.EventId == eventId && x.UserId == userId);

            if (registration == null) return NotFound("There is no registration with these eventId and userId");

            _dbContext.Registrations.Remove(registration);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, $"Something went wrong in {nameof(Delete)}");

            return Problem("Internal server error, please try again later...");
        }
    }


    [HttpPut("{eventId}/{userId}", Name = "Update")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Update([FromBody] RegistrationCreateUpdateDto registrationUpdateDto, int eventId,
        int userId)
    {
        _logger.LogInformation($"{nameof(Update)} called...");

        if (!ModelState.IsValid)
        {
            _logger.LogError($"Invalid PUT attempt in {nameof(Update)}");
            return BadRequest(ModelState);
        }

        try
        {
            var registrationToEdit = await _dbContext.Registrations
                .FirstOrDefaultAsync(e => e.EventId == eventId || e.UserId == userId);

            if (registrationToEdit == null) return BadRequest("Submitted data is invalid!");
            _mapper.Map(registrationUpdateDto, registrationToEdit);

            await _dbContext.SaveChangesAsync();

            return Ok(registrationUpdateDto);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, $"Something went wrong in {nameof(Update)}");
            return Problem("Internal server error, please try again later...");
        }
    }
}