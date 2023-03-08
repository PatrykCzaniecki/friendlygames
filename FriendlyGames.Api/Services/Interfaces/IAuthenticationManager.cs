using FriendlyGames.Api.Dtos;

namespace FriendlyGames.Api.Services.Interfaces;

public interface IAuthenticationManager
{
    Task<bool> ValidateApiUser(LoginApiUserDto userDto);
    Task<string> CreateJwtToken();
}