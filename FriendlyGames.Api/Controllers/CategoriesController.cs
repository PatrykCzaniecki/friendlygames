using AutoMapper;
using FriendlyGames.Api.Dtos;
using FriendlyGames.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FriendlyGames.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoriesService _categoriesService;
    private readonly ILogger<CategoriesController> _logger;
    private readonly IMapper _mapper;

    public CategoriesController(IMapper mapper, ILogger<CategoriesController> logger,
        ICategoriesService categoriesService)
    {
        _mapper = mapper;
        _logger = logger;
        _categoriesService = categoriesService;
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
            var categoriesDictionary = await _categoriesService.GetCategories();

            return Ok(categoriesDictionary);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, $"Something went wrong in {nameof(GetCategories)}");

            return Problem("Internal server error, please try again later...");
        }
    }

    [HttpGet("eventCategory", Name = "GetEventCategory")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<EventCategoryDto>> GetEventCategory()
    {
        _logger.LogInformation($"{nameof(GetEventCategory)} called...");

        try
        {
            var eventCategory = await _categoriesService.GetEventCategory();

            return Ok(eventCategory);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, $"Something went wrong in {nameof(GetCategories)}");

            return Problem("Internal server error, please try again later...");
        }
    }
}