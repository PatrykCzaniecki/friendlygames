using AutoMapper;
using FriendlyGames.Api.Dtos;
using FriendlyGames.Api.Infrastructure;
using FriendlyGames.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FriendlyGames.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApiUser> _userManager;
        private readonly IMapper _mapper;
        private readonly ILogger<UsersController> _logger;
        private readonly IAuthenticationManager _authenticationManager;

        public UsersController(UserManager<ApiUser> userManager, IMapper mapper, ILogger<UsersController> logger, IAuthenticationManager authenticationManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _logger = logger;
            _authenticationManager = authenticationManager;
        }

        [HttpOptions]
        [Route("register")]
        //[Authorize(Roles="Adminstrator")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RegisterApiUser([FromBody] RegisterApiUserDto userDto)
        {
            _logger.LogInformation($"{nameof(RegisterApiUser)} called...");
            _logger.LogInformation($"Registration attempt for {userDto.Email}");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = _mapper.Map<ApiUser>(userDto);
            user.UserName = user.Email;

            var result = await _userManager.CreateAsync(user, userDto.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }

                return BadRequest(ModelState);
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

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await _authenticationManager.ValidateApiUser(userDto))
            {
                return Unauthorized(userDto);
            }

            return Accepted(new { Token = await _authenticationManager.CreateJwtToken() });
        }
    }
}
