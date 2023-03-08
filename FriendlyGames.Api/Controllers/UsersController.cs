using AutoMapper;
using FriendlyGames.Api.Dtos;
using FriendlyGames.Api.Services;
using FriendlyGames.Api.Services.Interfaces;
using FriendlyGames.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FriendlyGames.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IAuthenticationManager _authenticationManager;
    private readonly ILogger<UsersController> _logger;
    private readonly IMapper _mapper;
    private readonly UserManager<ApiUser> _userManager;

    public UsersController(UserManager<ApiUser> userManager, IMapper mapper, ILogger<UsersController> logger,
        IAuthenticationManager authenticationManager)
    {
        _userManager = userManager;
        _mapper = mapper;
        _logger = logger;
        _authenticationManager = authenticationManager;
    }

    [HttpOptions]
    [Route("register")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> RegisterApiUser([FromBody] RegisterApiUserDto userDto)
    {
        _logger.LogInformation($"{nameof(RegisterApiUser)} called...");
        _logger.LogInformation($"Registration attempt for {userDto.Email}");

        if (!ModelState.IsValid) return BadRequest(ModelState);

        var user = _mapper.Map<ApiUser>(userDto);
        user.UserName = user.Email;

        var result = await _userManager.CreateAsync(user, userDto.Password);

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors) ModelState.AddModelError(error.Code, error.Description);

            return BadRequest(result.Errors);
        }

        await _userManager.AddToRolesAsync(user, userDto.Roles);

        return Accepted();
    }

    [HttpOptions]
    [Route("login")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> LoginApiUser([FromBody] LoginApiUserDto userDto)
    {
        _logger.LogInformation($"{nameof(LoginApiUser)} called...");
        _logger.LogInformation($"Login attempt for {userDto.Email}");

        if (!ModelState.IsValid) return BadRequest(ModelState);

        var errorString = "Zły email lub hasło";
        if (!await _authenticationManager.ValidateApiUser(userDto))
            return Unauthorized(JsonConvert.SerializeObject(errorString));

        return Accepted(new {Token = await _authenticationManager.CreateJwtToken()});
    }

    [Authorize(Roles = "User")]
    [HttpGet("GetUser")]
    public IActionResult GetUser()
    {
        var userData = new UserDataDto();
        foreach (var claim in User.Claims)
            switch (claim.Type)
            {
                case "userEmail":
                    userData.Email = claim.Value;
                    break;
                case "id":
                    userData.Id = claim.Value;
                    break;
                case "firstName":
                    userData.FirstName = claim.Value;
                    break;
                case "lastName":
                    userData.LastName = claim.Value;
                    break;
            }

        return new JsonResult(userData);
    }
}